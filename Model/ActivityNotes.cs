using System;
namespace dbamet.Model
{
	/// <summary>
	/// ActivityNotes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ActivityNotes
	{
		public ActivityNotes()
		{}
		#region Model
		private int _id;
		private string _activityid;
		private string _title;
		private string _place;
		private string _leader;
		private string _content;
		private DateTime? _opentime;
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
		public string activityid
		{
			set{ _activityid=value;}
			get{return _activityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string place
		{
			set{ _place=value;}
			get{return _place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string leader
		{
			set{ _leader=value;}
			get{return _leader;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? openTime
		{
			set{ _opentime=value;}
			get{return _opentime;}
		}
		#endregion Model

	}
}

