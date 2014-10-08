using System;
namespace dbamet.Model
{
	/// <summary>
	/// Activity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Activity
	{
		public Activity()
		{}
		#region Model
		private string _courseid;
		private string _coursename;
		private string _courseintro;
		/// <summary>
		/// 
		/// </summary>
		public string courseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string courseName
		{
			set{ _coursename=value;}
			get{return _coursename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string courseIntro
		{
			set{ _courseintro=value;}
			get{return _courseintro;}
		}
		#endregion Model

	}
}

