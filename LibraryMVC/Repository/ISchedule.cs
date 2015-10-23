using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC4.Repository
{
    public interface ISchedule<T> where T : class
    {
        IEnumerable<T> GetAdminWorkshops();  
    }
}
