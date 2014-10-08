using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_adminlink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Insert")
        {
            using (dbcms db = new dbcms())
            {
                link link1 = new link();
                var footer = ((GridView)sender).FooterRow;
                try
                {
                    link1.id = db.link.Max(d => d.id)+1 ;
                }
                catch
                {
                    link1.id = 1;
                }
                 link1.name = ((TextBox)footer.Cells[1].FindControl("name")).Text;
                link1.url = ((TextBox)footer.Cells[2].FindControl("url")).Text;
                link1.logo = ((TextBox)footer.Cells[3].FindControl("logo")).Text;
                link1.demo = ((TextBox)footer.Cells[4].FindControl("demo")).Text;
                 try
                {
                    link1.display =Convert.ToInt32(((TextBox)footer.Cells[5].FindControl("dispaly")).Text);
                }
                catch
                {
                    link1.display = 0;
                }
                link1.state = true;
                db.link.InsertOnSubmit(link1);
                db.SubmitChanges();
               
                GridView1.DataBind();
            }
        }
    }
}
