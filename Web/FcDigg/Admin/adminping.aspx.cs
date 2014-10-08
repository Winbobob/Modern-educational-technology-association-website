using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_adminping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cb1_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("cb")).Checked = ((CheckBox)sender).Checked;
        }
    }
    protected void ping_dele_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((CheckBox)GridView1.Rows[i].Cells[0].FindControl("cb")).Checked)
            {
                using (dbcms db = new dbcms())
                {
                    var p_dele = db.ping.First(d => d.id ==Convert.ToInt32(GridView1.DataKeys[i].Value));
                    db.ping.DeleteOnSubmit(p_dele);
                    db.SubmitChanges();
                    GridView1.DataBind();
                }
            }
        }
    }
}
