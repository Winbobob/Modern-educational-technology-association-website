using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///newsRepository 的摘要说明
/// </summary>
public class newsRepository:repository<news>
{

    public newsRepository(dbcms _db)
        : base(_db)
    {

    }
     
    public override IQueryable<news> get()
    {
        return List().OrderByDescending(d => d.ndate);
    }
    
}
