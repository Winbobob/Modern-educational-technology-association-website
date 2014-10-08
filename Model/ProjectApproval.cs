using System;
namespace dbamet.Model
{
	/// <summary>
	/// ProjectApproval:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProjectApproval
	{
		public ProjectApproval()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _proposer;
		private string _category;
		private string _content;
		private DateTime? _applydate;
		private DateTime? _passdate;
		private string _pass;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string proposer
		{
			set{ _proposer=value;}
			get{return _proposer;}
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
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? applydate
		{
			set{ _applydate=value;}
			get{return _applydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? passdate
		{
			set{ _passdate=value;}
			get{return _passdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pass
		{
			set{ _pass=value;}
			get{return _pass;}
		}
		#endregion Model

	}
}

