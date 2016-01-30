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
        IEnumerable<T> GetSpecPage(int? id);
        IEnumerable<T> GetSpecGuides();
        IEnumerable<T> GetSpecListDropDown(int id);
        IEnumerable<T> GetHeaderDropDown();
        IEnumerable<T> GetTabs();
        T HeaderPage(int id);
        T ResourcePage(int id);
        T EditResourcePage(int id);
        T GetHeader(int id);
        T GetGuideBody(int guideId, int headerId);
                    
        int GetCount(int id);

        object AddSpec(T entity);
        object AddHeader(T entity);
        object AddResource(T entity);
        object AddTab(string id);
        object AddNewTab(int guideId, int tabId);
        object EditResource(T entity);
        object UpdateHeader(T Entity);
        object DeleteResource(int id);
        object DeleteHeader(int id);
        object DeleteTab(int guideId, int headerId);
        object UpdateDisplay(bool boolId, int id);
    }
}
