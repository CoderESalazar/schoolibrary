using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMVC4.Models;

namespace LibraryMVC4.Repository
{
    public interface IWl<T> where T : class
    {
        object AddHeader(T entity);
        object EditHeader(T entity);
        object DeleteHeader(T entity);
        object EditPageTitle(T entity);
        object DeleteWlPage(T entity);
        object AddWlPage(T entity);

        T EditTitle(int id);

        int GetCounts(int id);

    }
}
