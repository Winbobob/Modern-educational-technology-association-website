using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class cate : pages
{
    public news tou;
    public IEnumerable<news> tuij;
    public IEnumerable<news> zuix;
    public IEnumerable<tag> tags;
    public IEnumerable<ping> pings;
   
    public IEnumerable<news> hots;
    public IEnumerable<cls> clss;
    public IEnumerable<news> art;
    public List<cls> dh;
    public string pagestr;
    public int cid;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        tou = db.news.OrderByDescending(d => d.ndate).First();
        tuij = db.news.OrderByDescending(d => d.id).Skip(1).Take(5).ToList();
        zuix = db.news.OrderByDescending(d => d.ndate).Skip(0).Take(10).ToList();
        tags = db.tag.ToList();
        pings = db.ping.Take(10).ToList();
        hots = (from d in db.news
                where Convert.ToDateTime(d.ndate).AddDays(7) > DateTime.Now
                select d).Take(10).ToList();
       
        int curpage = 1;
        if (!tool.StrIsNullOrEmpty(Request.QueryString["page"]))
        {
            curpage = Convert.ToInt32(Request.QueryString["page"]);
        }
        cid = 0;
        newsRepository nr = new newsRepository(db);
        var list = nr.List().AsQueryable();
        if (!tool.StrIsNullOrEmpty(Request.QueryString["id"]))
        {
           
            cid = Convert.ToInt32(Request.QueryString["id"]);
            
            var c1 = db.cls.First(d => d.id == cid);
            var s = db.she.First();
            HtmlMeta key = new HtmlMeta();
            key.Name = "Keywords";
            key.Content = s.Keywords + "|" + s.Keywords;
            Header.Controls.Add(key);
            HtmlMeta desc = new HtmlMeta();
            desc.Name = "Description";
            desc.Content = c1.description + "|" + s.Description;
            Header.Controls.Add(desc);
            Header.Title = c1.name+"|"+s.title;
            list = list.Where(d => d.cls.jb.Contains(c1.jb));
            clss = from d in db.cls
                   where d.jb.Substring(0,c1.jb.Length)==c1.jb && d.jb!=c1.jb
                   select d;
            var cls_s = c1.jb.Split('|');
            dh = new List<cls>();
            foreach (var i in cls_s)
            {
                try
                {
                    var d1 = db.cls.First(d => d.id == Convert.ToInt32(i));
                    dh.Add(d1);
                }
                catch
                {
                }
            }
            
           
        }

        int pagesize = 10;
      
        int day = 0;
        if (!tool.StrIsNullOrEmpty(Request.QueryString["viewday"]))
        {
            day = Convert.ToInt32(Request.QueryString["viewday"]);
        }

        if (day != 0)
            list = list.Where(d => DateTime.Now.AddDays(-day) <= Convert.ToDateTime(d.ndate));
        art = list.OrderByDescending(d=>d.ndate).Skip((curpage - 1)).Take(pagesize);
        int pagecount = list.Count() % pagesize == 0 ? list.Count() / pagesize : list.Count() / pagesize + 1;

        pagestr = tool.GetPageNumbers(curpage, pagecount, Request.RawUrl.ToString(), 5, "");


        

    }
   
}
