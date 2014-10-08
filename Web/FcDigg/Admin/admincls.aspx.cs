using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admincls : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string shuchu(int n)
    {
        string str = "";
        for (int i = 1; i < n/2; i++)
        {
            str += "　";
        }
        return str+"|-";
    }
    protected void drop_init(object sender, EventArgs e)
    {
        DropDownList drop = (DropDownList)sender;
        drop.Items.Add(new ListItem("顶级","0"));

        using (dbcms db = new dbcms())
        {
            var cls_list = db.cls.OrderBy(d => d.jb);
            foreach (var c in cls_list)
            {
                drop.Items.Add(new ListItem(shuchu(c.jb.Length) + c.name, c.id.ToString()));
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Insert")
        {
            using (dbcms db = new dbcms())
            {
                cls c1 = new cls();
                var footer = ((GridView)sender).FooterRow;
                c1.name= ((TextBox)footer.Cells[1].FindControl("t1")).Text;
                c1.keywords = ((TextBox)footer.Cells[1].FindControl("t2")).Text;
                c1.description = ((TextBox)footer.Cells[1].FindControl("t3")).Text;
                string jb= ((DropDownList)footer.Cells[1].FindControl("drop")).Text;
                try
                {
                    c1.sort = Convert.ToInt32(((TextBox)footer.Cells[1].FindControl("t5")).Text);

                }
                catch
                {
                    c1.sort = null;
                }
                clsRepository cr = new clsRepository(db);
                c1.id = cr.MaxId() + 1;
                
                if (jb != "0")
                    c1.jb = db.cls.Where(d => d.id == Convert.ToInt32(jb)).First().jb + c1.id + "|";
                else
                {
                    c1.jb = c1.id + "|";
                }
                c1.display = true;
                db.cls.InsertOnSubmit(c1);
                db.SubmitChanges();
                GridView1.DataBind();

            }
        }
    }
}
