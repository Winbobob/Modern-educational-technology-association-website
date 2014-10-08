using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class Admin_admincaiji : pages
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            caiji cj = new caiji();
            string str = cj.GetHtmlSource(listurl.Text);
            ArrayList urllist = new ArrayList();
            str = cj.webCode(str, split(listlink.Text)[0], split(listlink.Text)[1]);
            urllist = cj.webCodeReturnList(str, split(linkurl.Text)[0], split(linkurl.Text)[1]);
            foreach (string item in urllist)
            {

                string strcont = cj.GetHtmlSource(item);
                newsRepository nr = new newsRepository(db);
                news n = new news();
                try
                {
                    n.id = db.news.Max(d => d.id) + 1;
                }
                catch
                {
                    n.id = 1;
                }
                n.title =tool.RemoveHtml(cj.webCode(strcont, split(t_title.Text)[0], split(t_title.Text)[1]));
                if (!tool.StrIsNullOrEmpty(n.title))
                {
                    if (tool.StrIsNullOrEmpty(t_author.Text))
                    {
                        n.author = "";
                    }
                    else
                        n.author =cj.webCode(strcont, split(t_author.Text)[0], split(t_author.Text)[1]);
                    if (tool.StrIsNullOrEmpty(t_laiy.Text))
                    {
                        n.laiy = "";
                    }
                    else
                        n.laiy = tool.RemoveHtml(cj.webCode(strcont, split(t_laiy.Text)[0], split(t_laiy.Text)[1]));
                    if (tool.StrIsNullOrEmpty(t_cont.Text))
                    {
                        n.cont = "";
                    }
                    else
                        n.cont = tool.GetTextFromHTML(cj.webCode(strcont, split(t_cont.Text)[0], split(t_cont.Text)[1]));
                    if (!tool.StrIsNullOrEmpty(n.cont))
                    {
                        n.pic = "";
                        n.hit = 0;
                        n.ding = 0;
                        n.ping = 0;
                        n.tags = "";
                        n.uid = Convert.ToInt32(User.Identity.Name);
                        n.cid = Convert.ToInt32(drop2.SelectedValue);
                        n.ndate = DateTime.Now;
                        db.news.InsertOnSubmit(n);
                        db.SubmitChanges();
                    }
                }

            }
            
                tj.Text = "采集成功";
           
        }
    }
    private string[] split(string s)
    {
        return s.Split('|');
    }
    public string shuchu(int n)
    {
        string str = "";
        for (int i = 1; i < n / 2; i++)
        {
            str += "　";
        }
        return str + "|-";
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
