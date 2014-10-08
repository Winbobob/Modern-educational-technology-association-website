using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

public interface Irepository<T> where T:class
{
     Table<T> List();
     void Add(T t);
     void Add(IEnumerable<T> t);
     void Edit(T t);
     void Delete(T t);
     void Delete(IEnumerable<T> t);
     T get(object id);
     IQueryable<T> get(T t);
     IQueryable<T> get();
     int MaxId();
    
}
/// <summary>
///repository 的摘要说明
/// </summary>
public class repository<T> : Irepository<T> where T:class 
{
    public dbcms db;
    public repository()
    {
        db = new dbcms();
    }
    public repository(dbcms _db)
    {
        db = _db;
    }
    public virtual Table<T> List()
    {
        return db.GetTable<T>();
    }
    public virtual void Add(T t)
    {
        List().InsertOnSubmit(t);
        db.SubmitChanges();
    }
    public virtual void Add(IEnumerable<T> t)
    {
        db.InsertAll<T>(t);
    }
    public virtual void Edit(T t)
    {
        List().Attach(t,true);
        db.SubmitChanges();
    }
    public virtual void Delete(T t)
    {
        List().DeleteOnSubmit(t);
        db.SubmitChanges();
    }
    public virtual void Delete(IEnumerable<T> t)
    {
        db.DeleteAll<T>(t);
    }
    public virtual IQueryable<T> get(T t)
    {
        return db.Find<T>(t);
    }
    public virtual T get(object id)
    {
        try
        {
            return db.FindKey<T>(Convert.ToInt32(id));
        }
        catch
        {
            return null;
        }
    }
    public virtual IQueryable<T> get()
    {
        return List().AsQueryable();
    }
    public virtual int MaxId()
    {
        int id = 0;
        try
        {
            id = db.ExecuteCommand("select max(id) from " + typeof(T).Name);
        }
        catch
        {
            id = 0;
        }
        return id;
    }

}
 
