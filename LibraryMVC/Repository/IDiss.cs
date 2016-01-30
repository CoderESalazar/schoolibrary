using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC4.Repository
{
    public interface IDiss<T> where T : class
    {
        IEnumerable<T> GetSchoolPrograms();
        IEnumerable<T> GetDissByProg(string id);
        IEnumerable<T> GetChairName(string id);
        IEnumerable<T> GetDissSearch(string a, string b);

        T GetAbstract(int id);       

    }
}
