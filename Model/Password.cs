using System;
namespace dbamet.Model
{
	/// <summary>
	/// Password:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Password
	{
		public Password()
		{}
		#region Model
		private string _customid;
		private string _password;
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
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		#endregion Model

	}
}

