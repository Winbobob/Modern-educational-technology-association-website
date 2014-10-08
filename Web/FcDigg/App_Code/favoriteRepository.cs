using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///newsRepository 的摘要说明
/// </summary>
public class favoriteRepository : repository<favorite>
{

    public favoriteRepository(dbcms _db)
        : base(_db)
    {

    }

    public override IQueryable<favorite> get()
    {
        return List().OrderByDescending(d =>d.id);
    }
}
