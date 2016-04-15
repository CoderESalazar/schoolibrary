using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LibraryMVC4.Repository
{
    public interface IHome<T> where T : class
    {
        IEnumerable<T> GetBlogPosts();
        IEnumerable<T> GetFAQList();
        IEnumerable<T> SumResourceMonth(string id);
        
        T ResourceOfMonth();
        T GetChat();
        T GetDirMessage();
        T GetAlert();

        object AddUserPost(T entity);
        object AddResoureofMonth(T entity);
        object AddRadioId(T entity, int id);
        JsonResult FindFaqs(string search, int results);  

    }
}
