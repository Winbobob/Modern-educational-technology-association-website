using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///newsRepository 的摘要说明
/// </summary>
public class pingRepository:repository<ping>
{

    public pingRepository(dbcms _db)
        : base(_db)
    {

    }

    public override IQueryable<ping> get()
    {
        return List().OrderByDescending(d =>d.pdate);
    }
}
