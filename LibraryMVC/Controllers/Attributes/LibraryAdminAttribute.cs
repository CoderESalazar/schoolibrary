using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;
using LibraryMVC4.Security;
using LibraryMVC4.Repository;

namespace LibraryMVC4.Controllers.Attributes
{
    public class LibraryAdminAttribute : ActionFilterAttribute
    {     

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //so the logic will be in here. 
            //let me go ahead and set this up so I can put a debugger on this. 
            UserRepository libUser = new UserRepository();
            var myAdmin = libUser.LibAdminGroup();            

            //this not authorized. You are just not logged in w/out userid

            if (LibSecurity.UserId != null)
            {
                if (myAdmin != null)
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "Error";
                    result.ViewBag.ErrorMessage = "You are not authorized to use view this page.";
                    filterContext.Result = result;
                }
            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";
                result.ViewBag.ErrorMessage = "You are not authenticated. Please login and try again.";
                filterContext.Result = result;
            }

        }
    }
}