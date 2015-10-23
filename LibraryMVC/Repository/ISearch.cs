using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC4.Repository
{
    public interface ISearch<T> where T : class
    {
        IEnumerable<T> GetUListNames(string id);
        IEnumerable<T> SearchByKeyWords(string a, string b, string c);
        IEnumerable<T> GetCourse(string id);
        T GetByQId(int id);  
        
    }
}
