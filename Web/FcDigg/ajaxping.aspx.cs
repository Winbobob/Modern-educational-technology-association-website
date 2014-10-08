using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajaxping :pages
{
    
    public ping ping1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (User.Identity.IsAuthenticated)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            ping1 = new ping();
            ping1.nid = Convert.ToInt32(Request["nid"]);
            pingRepository pr = new pingRepository(db);
            if (Request["action"].ToString() == "list")
            {
                Response.Write(list());
            }else if(Request["action"]=="dele")
            {
                 db.ping.DeleteAllOnSubmit(db.ping.Where(d=>d.id==Convert.ToInt32(Request["id"])));
                 db.SubmitChanges();
                 Response.Write(list());

            }
            else if (Request["action"].ToString() == "add")
            {

                ping1.id = pr.MaxId() + 1;
                ping1.cont = Server.UrlDecode(Request["cont"].ToString());
                ping1.uid = Convert.ToInt32(User.Identity.Name);
                ping1.pdate = DateTime.Now;
                ping1.ip = tool.GetIP();
                db.ping.InsertOnSubmit(ping1);
                db.SubmitChanges();
                var d1 = db.ping.First(d => d.id == ping1.id);
                d1.news.ping += 1;
                db.SubmitChanges();
                Response.Write(list());
            }
        }
        else
        {
            Response.Write(1);
        }
    }
    public string list()
    {
        var ping2 = db.ping.Where(d => d.nid == ping1.nid).OrderByDescending(d=>d.pdate).Take(4);
        string str = "";
        foreach (var d in ping2)
        {
            str += "<div id='comment_" + d.id + "' class='comment_body'>";
            str += "<div id='comment_head_" + d.id + "' class='comment_head'>";
            str += "<div class='comment_digg'><!--mamage-->";
            str += "<span  onclick=dele('"+d.id+"') class='altspan'>[删除]</span>";
            str += "<span onclick=editcomment('4') class='altspan'>[编辑]</span></div>";
            str += "<div class='comment_userimg'><strong><a href=user.aspx?id=1>" + d.user.name + "</a></strong>&nbsp;发表于" + d.pdate + " IP:" + d.ip + "</div></div>";
            str += "<div class='comment_user_img'><img src='" + d.user.photo + "' alt='" + d.user.name + "' />&nbsp;</div>";
            str += "<div id='comment_content_4' class='comment_content'>" + d.cont + "</div></div>";
        }
        return str+"<div class='clear'></div>";
    }
}
