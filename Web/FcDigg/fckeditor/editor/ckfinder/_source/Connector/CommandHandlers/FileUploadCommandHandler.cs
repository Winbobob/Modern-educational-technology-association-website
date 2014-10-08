/*
 * CKFinder
 * ========
 * http://www.ckfinder.com
 * Copyright (C) 2007-2008 Frederico Caldeira Knabben (FredCK.com)
 *
 * The software, this file and its contents are subject to the CKFinder
 * License. Please read the license.txt file before using, installing, copying,
 * modifying or distribute this file or part of its contents. The contents of
 * this file is part of the Source Code of CKFinder.
 */

using System;
using System.Web;
using System.Text.RegularExpressions;

namespace CKFinder.Connector.CommandHandlers
{
	internal class FileUploadCommandHandler : CommandHandlerBase
	{
		public FileUploadCommandHandler()
			: base()
		{
		}

		public override void SendResponse( System.Web.HttpResponse response )
		{
			int iErrorNumber = 0;
			string sFileName = "";

			try
			{
				this.CheckConnector();
				this.CheckRequest();

				if ( !this.CurrentFolder.CheckAcl( AccessControlRules.FileUpload ) )
				{
					ConnectorException.Throw( Errors.Unauthorized );
				}

				HttpPostedFile oFile = HttpContext.Current.Request.Files[ "NewFile" ];

				if ( oFile != null )
				{
					sFileName = System.IO.Path.GetFileName( oFile.FileName );
					if ( Connector.CheckFileName( sFileName ) && !Config.Current.CheckIsHiddenFile( sFileName ) )
					{
						// Replace dots in the name with underscores (only one dot can be there... security issue).
						if ( Config.Current.ForceSingleExtension )
							sFileName = Regex.Replace( sFileName, @"\.(?![^.]*$)", "_", RegexOptions.None );

						if ( !Config.Current.CheckSizeAfterScaling && this.CurrentFolder.ResourceTypeInfo.MaxSize > 0 && oFile.ContentLength > this.CurrentFolder.ResourceTypeInfo.MaxSize )
							ConnectorException.Throw( Errors.UploadedTooBig );

						string sExtension = System.IO.Path.GetExtension( oFile.FileName );
						sExtension = sExtension.TrimStart( '.' );

						if ( !this.CurrentFolder.ResourceTypeInfo.CheckExtension( sExtension ) )
							ConnectorException.Throw( Errors.InvalidExtension );

						if ( Config.Current.CheckIsNonHtmlExtension( sExtension ) && !this.CheckNonHtmlFile( oFile ) )
							ConnectorException.Throw( Errors.UploadedWrongHtmlFile );

						// Map the virtual path to the local server path.
						string sServerDir = this.CurrentFolder.ServerPath;

						string sFileNameNoExt = System.IO.Path.GetFileNameWithoutExtension( sFileName );

						int iCounter = 0;

						while ( true )
						{
							string sFilePath = System.IO.Path.Combine( sServerDir, sFileName );

							if ( System.IO.File.Exists( sFilePath ) )
							{
								iCounter++;
								sFileName =
									sFileNameNoExt +
									"(" + iCounter + ")" +
									System.IO.Path.GetExtension( oFile.FileName );

								iErrorNumber = Errors.UploadedFileRenamed;
							}
							else
							{
								oFile.SaveAs( sFilePath );

								if ( Config.Current.SecureImageUploads && ImageTools.IsImageExtension( sExtension ) && !ImageTools.ValidateImage( sFilePath ) )
								{
									System.IO.File.Delete( sFilePath );
									ConnectorException.Throw( Errors.UploadedCorrupt );
								}

								Settings.Images imagesSettings = Config.Current.Images;

								if ( imagesSettings.MaxHeight > 0 && imagesSettings.MaxWidth > 0 )
								{
									ImageTools.ResizeImage( sFilePath, sFilePath, imagesSettings.MaxWidth, imagesSettings.MaxHeight, true, imagesSettings.Quality );

									if ( Config.Current.CheckSizeAfterScaling && this.CurrentFolder.ResourceTypeInfo.MaxSize > 0 )
									{
										long fileSize = new System.IO.FileInfo( sFilePath ).Length;
										if ( fileSize > this.CurrentFolder.ResourceTypeInfo.MaxSize )
										{
											System.IO.File.Delete( sFilePath );
											ConnectorException.Throw( Errors.UploadedTooBig );
										}
									}
								}

								break;
							}
						}
					}
					else
						ConnectorException.Throw( Errors.InvalidName );
				}
				else
					ConnectorException.Throw( Errors.UploadedCorrupt );
			}
			catch ( ConnectorException connectorException )
			{
				iErrorNumber = connectorException.Number;
			}
			catch
			{
				iErrorNumber = Errors.Unknown;
			}

			response.Clear();

			response.Write( "<script type=\"text/javascript\">" );
			response.Write( this.GetJavaScriptCode( iErrorNumber, sFileName, this.CurrentFolder.Url + sFileName ) );
			response.Write( "</script>" );

			response.End();
		}

		protected virtual string GetJavaScriptCode( int errorNumber, string fileName, string fileUrl )
		{
			switch ( errorNumber )
			{
				case Errors.None:
				case Errors.UploadedFileRenamed:
					return "window.parent.OnUploadCompleted(" + errorNumber + ",'" + fileName.Replace( "'", "\\'" ) + "') ;";
				default:
					return "window.parent.OnUploadCompleted(" + errorNumber + ") ;";
			}
		}

		private bool CheckNonHtmlFile( HttpPostedFile file )
		{
			byte[] buffer = new byte[ 1024 ];
			file.InputStream.Read( buffer, 0, 1024 );

			string firstKB = System.Text.ASCIIEncoding.ASCII.GetString( buffer );

			if ( Regex.IsMatch( firstKB, @"<!DOCTYPE\W*X?HTML", RegexOptions.IgnoreCase | RegexOptions.Singleline ) )
				return false;

			if ( Regex.IsMatch( firstKB, @"<(?:body|head|html|img|pre|script|table|title)", RegexOptions.IgnoreCase | RegexOptions.Singleline ) )
				return false;

			//type = javascript
			if ( Regex.IsMatch( firstKB, @"type\s*=\s*[\'""]?\s*(?:\w*/)?(?:ecma|java)", RegexOptions.IgnoreCase | RegexOptions.Singleline ) )
				return false;

			//href = javascript
			//src = javascript
			//data = javascript
			if ( Regex.IsMatch( firstKB, @"(?:href|src|data)\s*=\s*[\'""]?\s*(?:ecma|java)script:", RegexOptions.IgnoreCase | RegexOptions.Singleline ) )
				return false;

			//url(javascript
			if ( Regex.IsMatch( firstKB, @"url\s*\(\s*[\'""]?\s*(?:ecma|java)script:", RegexOptions.IgnoreCase | RegexOptions.Singleline ) )
				return false;

			return true;
		}
	}
}
