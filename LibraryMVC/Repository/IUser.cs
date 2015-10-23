using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMVC4.Models;

namespace LibraryMVC4.Repository
{
    public interface IUser<T> where T : class 
    {
        T GetUserInfo();
        T LibAdminGroup();    

    }
}
