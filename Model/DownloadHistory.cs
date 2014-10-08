using System;
namespace dbamet.Model
{
	/// <summary>
	/// DownloadHistory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DownloadHistory
	{
		public DownloadHistory()
		{}
		#region Model
		private int _id;
		private string _customid;
		private string _resourcename;
		private DateTime _downloadtime;
		private int _resourceid;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customId
		{
			set{ _customid=value;}
			get{return _customid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string resourceName
		{
			set{ _resourcename=value;}
			get{return _resourcename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime downloadTime
		{
			set{ _downloadtime=value;}
			get{return _downloadtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int resourceId
		{
			set{ _resourceid=value;}
			get{return _resourceid;}
		}
		#endregion Model

	}
}

