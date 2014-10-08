using System;
namespace dbamet.Model
{
	/// <summary>
	/// UserList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserList
	{
		public UserList()
		{}
		#region Model
		private string _customid;
		private string _customname;
		private DateTime? _birth;
		private string _duty;
		private string _classname;
		private string _sex;
		private string _interest;
		private string _tel;
		private string _intro;
		private int _point=10;
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
		public string customName
		{
			set{ _customname=value;}
			get{return _customname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? birth
		{
			set{ _birth=value;}
			get{return _birth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string duty
		{
			set{ _duty=value;}
			get{return _duty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string className
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string interest
		{
			set{ _interest=value;}
			get{return _interest;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int point
		{
			set{ _point=value;}
			get{return _point;}
		}
		#endregion Model

	}
}

