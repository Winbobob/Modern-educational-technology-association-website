using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///newsRepository 的摘要说明
/// </summary>
public class linkRepository:repository<link>
{

    public linkRepository(dbcms _db)
        : base(_db)
    {

    }

    public override IQueryable<link> get()
    {
        return from d in List()
               where d.state == true
               orderby d.display
               select d;
    }
}
