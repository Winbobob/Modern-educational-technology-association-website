using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
public class pages : System.Web.UI.Page
{
    public dbcms db;

    protected override void OnLoad(EventArgs e)
    {
        if (db == null)
        db = new dbcms();
        base.OnLoad(e);
    }
    public override void Dispose()
    {
        if (db!=null)
            db.Dispose();
        base.Dispose();
    }
}
public class masters : System.Web.UI.MasterPage
{
    public dbcms db;

    protected override void OnLoad(EventArgs e)
    {
        if(db==null)
        db = new dbcms();
        base.OnLoad(e);
    }
    public override void Dispose()
    {
        if (db != null)
            db.Dispose();
        base.Dispose();
    }
}
  