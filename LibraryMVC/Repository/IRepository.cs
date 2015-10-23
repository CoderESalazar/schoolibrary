using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMVC4.Models;


namespace LibraryMVC4.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(int id);        
        IEnumerable<T> GetAll();
        T GetById(int? id);
        IEnumerable<T> List(string id);
        IEnumerable<T> GetSite(int id);
        IEnumerable<T> GetList(string m, string p);
        T GetById(int id);
        
        object Edit(T entity);
        object Add(T entity);
        object Delete(T entity);



    
    }
}
