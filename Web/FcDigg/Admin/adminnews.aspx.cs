using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_adminnews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     }
    public string clsname(object id)
    {
        using (dbcms db = new dbcms())
        {
            string str = "";
            try
            {
                str= db.cls.First(d => d.id == Convert.ToInt32(id)).name;
            }
            catch
            {
                str= "";
            }
            return str;
        }
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
    protected void drop_Init(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DropDownList drop = (DropDownList)sender;
            drop.Items.Add(new ListItem("顶级", ""));
            using (dbcms db = new dbcms())
            {
                var cls_list = db.cls.OrderBy(d => d.jb);
                foreach (var c in cls_list)
                {
                     
                    drop.Items.Add(new ListItem(shuchu(c.jb.Length) + c.name, c.id.ToString()));
                }
            }
        }
    }
    protected void LinqDataSource2_Inserting(object sender, LinqDataSourceInsertEventArgs e)
    {
        news n = (news)e.NewObject;
     
     
        dbcms db=new dbcms();
        try
        {
            n.id = db.news.Max(d => d.id) + 1;
        }
        catch
        {
            n.id = 1;
        }
        n.ndate = DateTime.Now;
        n.ping = 0;
        n.hit = 0;
       
    }
    
    protected void load(object sender, EventArgs e)
    {
        var grid = (GridView)sender;
        ScriptManager.RegisterClientScriptInclude(grid,grid.GetType(),"dd","news.js");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "dd", "lhgdialog.opendlg('内容页为外部连接的窗口', '../admin/newsAdd.aspx?id="+GridView1.SelectedValue+"', 640, 540, false, true);", true);
    }
   
    protected void button1_Click(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
}
