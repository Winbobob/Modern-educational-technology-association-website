using System;
namespace dbamet.Model
{
	/// <summary>
	/// Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin
	{
		public Admin()
		{}
		#region Model
		private string _uid;
		private string _upwd;
		/// <summary>
		/// 
		/// </summary>
		public string uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string upwd
		{
			set{ _upwd=value;}
			get{return _upwd;}
		}
		#endregion Model

	}
}

