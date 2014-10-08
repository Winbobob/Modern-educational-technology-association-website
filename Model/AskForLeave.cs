using System;
namespace dbamet.Model
{
	/// <summary>
	/// AskForLeave:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AskForLeave
	{
		public AskForLeave()
		{}
		#region Model
		private int _id;
		private string _avtivetitle;
		private string _customid;
		private DateTime? _opentime;
		private DateTime? _submittime;
		private string _reason;
		private bool _pass= false;
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
		public string avtiveTitle
		{
			set{ _avtivetitle=value;}
			get{return _avtivetitle;}
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
		public DateTime? openTime
		{
			set{ _opentime=value;}
			get{return _opentime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? submitTIme
		{
			set{ _submittime=value;}
			get{return _submittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pass
		{
			set{ _pass=value;}
			get{return _pass;}
		}
		#endregion Model

	}
}

