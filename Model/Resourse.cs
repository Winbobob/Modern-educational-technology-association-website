using System;
namespace dbamet.Model
{
	/// <summary>
	/// Resourse:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Resourse
	{
		public Resourse()
		{}
		#region Model
		private int _resourceid;
		private string _customid;
		private string _resourcename;
		private string _resourcepath;
		private string _resourcetype;
		private string _category;
		private string _size;
		private string _info;
		private DateTime? _uploadtime;
		private int? _downloadtimes=0;
		/// <summary>
		/// 
		/// </summary>
		public int resourceId
		{
			set{ _resourceid=value;}
			get{return _resourceid;}
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
		public string resourcePath
		{
			set{ _resourcepath=value;}
			get{return _resourcepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string resourceType
		{
			set{ _resourcetype=value;}
			get{return _resourcetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string size
		{
			set{ _size=value;}
			get{return _size;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string info
		{
			set{ _info=value;}
			get{return _info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? uploadTime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? downloadTimes
		{
			set{ _downloadtimes=value;}
			get{return _downloadtimes;}
		}
		#endregion Model

	}
}

