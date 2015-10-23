using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC4.Repository
{
    public interface IFaq<T> where T : class
    {
        T GetByFaq(int id);
      
        IEnumerable<T> BrowseByCat(string id);
        
        object AddUserFeedback(string c, int d);

    }
}
