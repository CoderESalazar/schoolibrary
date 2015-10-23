using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC4.Repository
{
    public interface IGuides<T> where T : class
    {
        IEnumerable<T> GetGuideTabs(int id);
        IEnumerable<T> GetSpecTitleList();
        IEnumerable<T> GetCourseGuides();
        IEnumerable<T> GetGuidesWithBody(int id);
        IEnumerable<T> GetGuidesWOutBody(int id);
        IEnumerable<T> GetSpecPage(int id);
        int GetCount(int id);
        
    }
}
