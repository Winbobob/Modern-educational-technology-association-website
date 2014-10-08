using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            using (dbcms db = new dbcms())
            {
                var u1 = db.user.Where(d => d.id == Convert.ToInt32(Page.User.Identity.Name) && d.jb == 2);
                if (u1.Count() == 0)
                {
                    Response.Redirect("/default.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("/default.aspx");
        }
    }
}
//5/1/aspx