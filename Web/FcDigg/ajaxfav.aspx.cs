using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajaxfav : pages
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!tool.StrIsNullOrEmpty(Request["nid"]))
            {
                int nid = Convert.ToInt32(Request["nid"]);
                int uid = Convert.ToInt32(User.Identity.Name);
                if (db.favorite.Where(d => d.nid == nid && d.uid == uid).Count() == 0)
                {
                    favorite f = new favorite();
                    favoriteRepository fr = new favoriteRepository(db);
                    f.id = fr.MaxId() + 1;
                    f.nid = nid;
                    f.uid = uid;
                    fr.Add(f);
                }
                else
                {
                    Response.Write("已经被收藏");
                }
                Response.Write("添加成功");
            }
        }
        else
        {
            Response.Write("1");
        }
    }
}
