using System;
namespace dbamet.Model
{
	/// <summary>
	/// Intro:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Intro
	{
		public Intro()
		{}
		#region Model
		private int _id;
		private string _type;
		private string _title;
		private string _introcontent;
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
		public string type
		{
			set{ _type=value;}
			get{return _type;}
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
		public string introcontent
		{
			set{ _introcontent=value;}
			get{return _introcontent;}
		}
		#endregion Model

	}
}

