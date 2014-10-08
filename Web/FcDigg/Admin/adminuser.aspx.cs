using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_adminuser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Insert")
        {
            var footer = GridView1.FooterRow;
            using (dbcms db = new dbcms())
            {
                user u = new user();
                try
                {
                    u.id = db.user.Max(d => d.id) + 1;
                }
                catch
                {
                    u.id = 1;
                }
                u.name = ((TextBox)footer.Cells[1].FindControl("name")).Text;
                u.jb = 1;
                u.pwd = ((TextBox)footer.Cells[2].FindControl("pwd")).Text;
                u.email = ((TextBox)footer.Cells[1].FindControl("email")).Text;
                u.photo = ((TextBox)footer.Cells[1].FindControl("photo")).Text;
                db.user.InsertOnSubmit(u);
                user1 u1 = new user1();
                u1.uid = u.id;
                db.user1.InsertOnSubmit(u1);
               
                db.SubmitChanges();
                GridView1.DataBind();
            }
        }
    }
}
