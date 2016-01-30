using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC4.Repository
{
    public interface IStructure<T> where T : class
    {

        IEnumerable<T> GetLibraryPages();
        IEnumerable<T> GetChatList();
        IEnumerable<T> GetRecentAlerts();

        object UpdateLibPage(T entity);
        object StopChat(int id);
        object DeleteLibPage(int id);
        object AddLibPage(T entity);
        object AddAlert(T entity);
        object StartChat();
        object EditAlert(int id);
        object EditPostAlert(T entity);
        
    }
}
