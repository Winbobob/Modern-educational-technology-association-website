using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///newsRepository 的摘要说明
/// </summary>
public class userRepository:repository<user>
{

    public userRepository(dbcms _db)
        : base(_db)
    {

    }
     
    public override IQueryable<user> get()
    {
        return List().OrderByDescending(d =>d.id);
    }
}
