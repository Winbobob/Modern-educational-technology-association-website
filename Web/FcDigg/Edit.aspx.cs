using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit :pages
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("login.aspx");
        }
        if (!this.IsPostBack)
        {
            ViewState["u"] = Request.UrlReferrer.ToString();

            if (Request["id"] != null)
            {
                int id = Convert.ToInt32(Request["id"]);
                var n = db.news.First(d => d.id == id);
                title1.Value = n.title;
                author.Value = n.author;
                cont.Value = n.cont;
                laiy.Value = n.laiy;
                tag.Value = n.tags;
                drop2.SelectedValue = n.cid.ToString();

            }
        }
        else
        {
            int id = Convert.ToInt32(Request["id"]);
            var n = db.news.First(d => d.id == id);
            n.title = title1.Value;
            n.author = author.Value;
            n.cont = cont.Value;
            n.laiy = laiy.Value;
            n.tags = tag.Value;
            n.ndate = DateTime.Now;
            n.cid = Convert.ToInt32(drop2.SelectedValue);
            if (!tool.StrIsNullOrEmpty(uploadavatar.Value))
            {
                string name = uploadavatar.PostedFile.FileName;
                name = name.Substring(name.LastIndexOf("\\") + 1);
                if (name.Contains("jpg") || name.Contains("png") || name.Contains("gif"))
                {
                    uploadavatar.PostedFile.SaveAs(Server.MapPath("/userfiles/images/" + name));
                    n.pic = "/userfiles/images/" + name;
                }
                else
                    n.pic = "";
            }

            db.SubmitChanges();
            Response.Redirect(ViewState["u"].ToString());
         }
        
        
    }
    public string shuchu(int n)
    {
        string str = "";
        for (int i = 1; i < n / 2; i++)
        {
            str += "　";
        }
        return str + "|—";
    }

    protected void drop2_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList drop = (DropDownList)sender;
            var cls_list = db.cls.OrderBy(d => d.jb);
            foreach (var c in cls_list)
            {
                drop.Items.Add(new ListItem(shuchu(c.jb.Length) + c.name, c.id.ToString()));
            }

        }
    }
}
