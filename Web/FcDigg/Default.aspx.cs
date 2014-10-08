using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class _Default : pages
{
    public news tou;
    public IEnumerable<news> tuij;
    public IEnumerable<news> zuix;
    public IEnumerable<tag> tags;
    public IEnumerable<ping> pings;
  
    public IEnumerable<news> hots;
    public IEnumerable<user> users;
    public IEnumerable<news> art;
    public string hd_img;
    public string hd_link;
    public string hd_title;
    public string pagestr;
    protected void Page_Load(object sender, EventArgs e)
    {
        var s = db.she.First(); 
        HtmlMeta key = new HtmlMeta();
        key.Name = "Keywords";
        key.Content = s.Keywords;
        Header.Controls.Add(key);
        HtmlMeta desc = new HtmlMeta();
        desc.Name = "Description";
        desc.Content = s.Description;
        Header.Controls.Add(desc);
        Header.Title = s.title;
        newsRepository nr = new newsRepository(db);
         Session["code"] = Session.SessionID;
         tou = nr.get().First();
         tuij = nr.List().OrderByDescending(d=>d.hit).Skip(1).Take(5).ToList();
         zuix = nr.get().Skip(0).Take(10).ToList();
         tagRepository tr = new tagRepository(db);
         tags = tr.get();
         pingRepository pr=new pingRepository(db);
         pings = pr.get().Take(10);
         hots = nr.get().Where(d => Convert.ToDateTime(d.ndate).AddDays(7) > DateTime.Now).Take(10);
         userRepository ur = new userRepository(db);
         users = ur.get().Take(12);
         
         int curpage = 1;
         if (!tool.StrIsNullOrEmpty(Request.QueryString["page"]))
         {
             curpage = Convert.ToInt32(Request.QueryString["page"]);
         }
         

         int pagesize = 10;
         var list = nr.List().AsQueryable();
         if (!tool.StrIsNullOrEmpty(Request.QueryString["tag"]))
         {

            list=list.Where(d => d.tags.Contains(Request.QueryString["tag"].ToString()));
         }
         int day =0;
         if (!tool.StrIsNullOrEmpty(Request.QueryString["viewday"]))
         {
             day = Convert.ToInt32(Request.QueryString["viewday"]);
         }
        
         
         if(day!=0)
         list = list.Where(d => DateTime.Now.AddDays(-day)<=Convert.ToDateTime(d.ndate));
         art = list.OrderByDescending(d=>d.ndate).Skip((curpage - 1)*pagesize).Take(pagesize);
         int pagecount = list.Count() % pagesize == 0 ? list.Count() / pagesize : list.Count() / pagesize + 1;
         
        pagestr = tool.GetPageNumbers(curpage, pagecount,Request.RawUrl.ToString(), 5, "");

        if (!tool.StrIsNullOrEmpty(Request["verifyhash1"]) && !tool.StrIsNullOrEmpty(Request["username"])&&Session["code1"]!=null)
        {
            if (Request["verifyhash1"].ToString() == Session["code1"].ToString())
            {

                var u1 = db.user.Where(d => d.name == Convert.ToString(Request["username"].Trim())
                    && d.pwd == Convert.ToString(Request["password"].Trim()));
                if (u1.Count() > 0)
                {
                    var u = u1.First();
                    if (Convert.ToInt32(Request["persistent"]) == 1)
                    {
                        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(u.id.ToString(), true);
                    }
                    else
                    {
                        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(u.id.ToString(), false);
                    }
                     
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dd", "alert('密码错误或用户名错误')", true);
                }
            }
        }
        Session["code1"] = Session.SessionID;

        // 图片幻灯
        var hd = (from d in db.news
                  where d.pic != null && d.pic.Trim() != ""
                  orderby d.ndate descending
                  select d).Take(4);
        hd_img = "";
        hd_link = "";
        hd_title = "";
        foreach (var item in hd)
        {

            hd_img += item.pic + "|";
            hd_link += "show.aspx?id=" + item.id + "|";
            hd_title += item.title + "|";
        }
        hd_img = tool.sub(hd_img, hd_img.Length - 1);
        hd_link = tool.sub(hd_link, hd_link.Length - 1);
        hd_title = tool.sub(hd_title, hd_title.Length - 1);
        
    }
  
}
