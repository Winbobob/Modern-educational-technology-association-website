using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///newsRepository 的摘要说明
/// </summary>
public class clsRepository:repository<cls>
{

    public clsRepository(dbcms _db)
        : base(_db)
    {

    }

    public override IQueryable<cls> get()
    {
       return   List().Where(d=>d.jb.Length < 4 && d.display).OrderBy(d => d.sort);
    }
}
