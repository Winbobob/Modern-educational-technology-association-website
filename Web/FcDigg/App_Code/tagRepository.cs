using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///newsRepository 的摘要说明
/// </summary>
public class tagRepository:repository<tag>
{

    public tagRepository(dbcms _db)
        : base(_db)
    {

    }
     
    public override IQueryable<tag> get()
    {
        return List().OrderByDescending(d => d.hits);
    }
}
