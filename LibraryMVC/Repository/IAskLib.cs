using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMVC4.Models;

namespace LibraryMVC4.Repository
{
    public interface IAskLib<T> where T : class
    {
        IEnumerable<T> GetAllUserQs();
        //T GetLibEmail(int id);
        T GetLibAnswer(int id);
        object AddAskLib(T entity);        

    }
}
