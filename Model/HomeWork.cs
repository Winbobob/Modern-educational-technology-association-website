using System;
namespace dbamet.Model
{
	/// <summary>
	/// HomeWork:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HomeWork
	{
		public HomeWork()
		{}
		#region Model
		private string _customid;
		private string _hwid;
		private string _hwname;
		private string _hwpath;
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
		public string hwId
		{
			set{ _hwid=value;}
			get{return _hwid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hwName
		{
			set{ _hwname=value;}
			get{return _hwname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hwPath
		{
			set{ _hwpath=value;}
			get{return _hwpath;}
		}
		#endregion Model

	}
}

