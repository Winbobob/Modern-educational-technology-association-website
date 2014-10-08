using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajaxding : pages
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
       
        int nid = Convert.ToInt32(Request["nid"]);
        newsRepository nr = new newsRepository(db);
        
        var n1 = nr.get(nid);
        if (n1 != null)
        {
            n1.ding += 1;
            if (User.Identity.IsAuthenticated)
            {
                dings ding = new dings();
                try
                {
                    ding.id = db.dings.Max(d => d.id) + 1;

                }
                catch
                {
                    ding.id = 1;
                }
                ding.nid = n1.id;
                ding.uid = Convert.ToInt32(User.Identity.Name);
                db.dings.InsertOnSubmit(ding);
            }
            db.SubmitChanges();
            Response.Write(n1.ding);
            tool.WriteCookie("ip"+n1.id, tool.GetIP()+"|"+n1.id,24);   
        }
    }
}
