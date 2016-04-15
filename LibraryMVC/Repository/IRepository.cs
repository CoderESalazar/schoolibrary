using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMVC4.Models;
using System.Web.Mvc;

namespace LibraryMVC4.Repository
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> List(int id);        
        IEnumerable<T> GetAll();        
        IEnumerable<T> List(string id);
        IEnumerable<T> GetSite(int id);
    
        T GetById(int? id);
        T GetById(int id);
        
        object Edit(T entity);
        object Add(T entity);
        object Delete(T entity);        
    }
}
