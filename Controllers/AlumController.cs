using Ncu.Common.Utilities.Enums;
using Ncu.Component.Membership.Br;
using Ncu.Logging.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC4.Controllers
{
    public class AlumController : Controller
    {
        //
        // GET: /Alum/

        public ActionResult Authenticate()
        {
            const string COOKIE_SSO_USER_ID = "sLetMeIn";
            const string QS_PARM_SITE = "ReturnSite";
            const string QS_PARM_RETURN_URL = "ReturnUrl";
            const string QS_PARM_ALTERNATE_RETURN_URL = "url";

            try
            {
                HttpContext httpContext = System.Web.HttpContext.Current;

                // Have we already authenticated with CourseRoom? If we have the desire cookie created by CourseRoom then we have!
                if (CookieExists(httpContext, COOKIE_SSO_USER_ID))
                {
                    string userId = ExtractUserId(GetCookieValue(httpContext, COOKIE_SSO_USER_ID));

                    // Is this an alumni?
                    if (IsOnlyAlumni(userId))
                    {
                        string returnSite = GetQueryValue(httpContext, QS_PARM_SITE);
                        string returnUrl = GetQueryValue(httpContext, QS_PARM_RETURN_URL);

                        // Construct the authentication URL expected by the proxy
                        string redirectUrl = CreateProxySSOUrl(userId, returnSite, returnUrl);

                        return Redirect(redirectUrl);

                    }

                    else
                    {

                        return PartialView("_proxyError");

                    }

                }
                else
                {
                    string returnSite = GetQueryValue(httpContext, QS_PARM_SITE);
                    string returnUrl = GetQueryValue(httpContext, QS_PARM_RETURN_URL);
                    if (string.IsNullOrEmpty(returnUrl)) returnUrl = GetQueryValue(httpContext, QS_PARM_ALTERNATE_RETURN_URL);      // In case ^U is not use in the proxy!

                    // Construct the authentication URL expected by CourseRoom
                    string redirectUrl = CreateCourseRoomSSOUrl(returnSite, returnUrl);

                    return Redirect(redirectUrl);
                }
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(ExceptionLogger.SeverityLevels.fatal, exception, "Next action is to re-throw this exception object");

                // Re-throw exception maintaining the current exception stack!
                throw;
            }
        }


        #region Private Support Methods

        /// <summary>
        /// Safe version of testing if HttpRequest object exists on targeted HttpContext provided.
        /// </summary>
        /// <remarks>
        /// ASP.NET will throw an exception if you try to use this property when the HttpRequest object is not available. 
        /// For example, this would be true in the Application_Start method of the Global.asax file, or in a method that is called from the Application_Start method. 
        /// At that time no HTTP request has been created yet. 
        /// 
        /// Information above from: http://msdn.microsoft.com/en-us/library/system.web.httpcontext.request.aspx
        /// </remarks>
        /// <param name="context">Reference to a HtptContext object</param>
        /// <returns>True HttpRequest object exists</returns>
        private bool HttpRequestExists(HttpContext context)
        {
            bool exists = true;

            exists = (context.Request != null) ? true : false;

            return exists;
        }

        /// <summary>
        /// Gets a query string parameter value 
        /// </summary>
        /// <param name="context">Reference to a HtptContext object</param>
        /// <param name="queryName">Query string parameter name</param>
        /// <returns>Query string parameter value</returns>
        private string GetQueryValue(HttpContext context, string queryName)
        {
            string queryValue = string.Empty;

            if ((context != null) && HttpRequestExists(context) && (context.Request.QueryString != null))
            {
                queryValue = context.Request.QueryString[queryName];
            }

            return queryValue;
        }

        /// <summary>
        /// Safely checks if cookie exists
        /// </summary>
        /// <param name="httpContext">Reference to a HttpContext object</param>
        /// <param name="name">Cookie name</param>
        /// <returns>True if cookie exists</returns>
        private bool CookieExists(HttpContext httpContext, string name)
        {
            bool exists = false;

            HttpCookie cookie = httpContext.Request.Cookies[name];

            exists = (cookie != null);

            return exists;
        }

        /// <summary>
        /// Safely gets a cookie value
        /// </summary>
        /// <param name="httpContext">Reference to a HttpContext object</param>
        /// <param name="name">Cookie name</param>
        /// <returns>Cookie value</returns>
        private string GetCookieValue(HttpContext httpContext, string name)
        {
            string value = string.Empty;

            HttpCookie cookie = httpContext.Request.Cookies[name];

            value = (cookie != null) ? cookie.Value : string.Empty;

            return value;
        }

        /// <summary>
        /// Safely gets a scheme
        /// </summary>
        /// <param name="context">Reference to a HtptContext object</param>
        /// <returns>HTTP scheme</returns>
        private string GetScheme(HttpContext context)
        {
            string scheme = string.Empty;

            if ((context != null) && HttpRequestExists(context) && (context.Request.Url != null))
            {
                scheme = context.Request.Url.Scheme;
            }

            return scheme;
        }

        /// <summary>
        /// Extracts a user id from the cookie value generated by CourseRoom of the form: UserId=###
        /// </summary>
        /// <param name="cookieValue">Cookie value</param>
        /// <returns>User identifier code</returns>
        private string ExtractUserId(string cookieValue)
        {
            const string COOKIE_SSO_PARM_LABEL = "UserId=";

            string userId = string.Empty;

            if (!string.IsNullOrEmpty(cookieValue))
            {
                int index = COOKIE_SSO_PARM_LABEL.Length;
                userId = cookieValue.Substring(index);
            }

            return userId;
        }

        /// <summary>
        /// Creates the Proxy SSO return URL path
        /// </summary>
        /// <param name="userId">User identifier code</param>
        /// <param name="returnSite">Return site host name</param>
        /// <param name="returnUrl">Return URL relative path</param>
        /// <returns>Redirect URL to use</returns>
        private string CreateProxySSOUrl(string userId, string returnSite, string returnUrl)
        {
            const string SLASH = "/";
            const string HOST_PREFIX = "://";
            const string URL_FORMAT = "login?loguser={0}&user=someuser&pass=somepass&url={1}";

            string redirectUrl = string.Empty;
            HttpContext httpContext = System.Web.HttpContext.Current;

            if (!string.IsNullOrEmpty(returnSite) && !string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = HttpUtility.UrlDecode(returnUrl);
                string validUserId = !string.IsNullOrEmpty(userId) ? userId : string.Empty;

                redirectUrl = GetScheme(httpContext) + HOST_PREFIX + returnSite + (returnSite.EndsWith(SLASH) ? string.Empty : SLASH) + string.Format(URL_FORMAT, validUserId, returnUrl);
            }
            else if (!string.IsNullOrEmpty(returnSite))
            {
                redirectUrl = GetScheme(httpContext) + HOST_PREFIX + returnSite;
            }

            return redirectUrl;
        }

        /// <summary>
        /// Creates the CourseRoom SSO return URL path
        /// </summary>
        /// <param name="returnSite">Return site host name</param>
        /// <param name="returnUrl">Return URL relative path</param>
        /// <returns>Redirect URL to use</returns>
        private string CreateCourseRoomSSOUrl(string returnSite, string returnUrl)
        {
            const string CR_LOGIN_URL_SETTING = "CourseRoomLoginUrl";
            const string URL_FORMAT = "{0}&ReturnUrl=Alum%2FAuthenticate%3FReturnSite%3d{1}%26ReturnUrl%3d{2}";      // Encoding apply so that CR SSO does not interpret it but returns it back!!

            string courseRoomLoginUrl = ConfigurationManager.AppSettings[CR_LOGIN_URL_SETTING];
            string redirectUrl = string.Format(URL_FORMAT, courseRoomLoginUrl, returnSite, returnUrl);

            return redirectUrl;
        }

        /// <summary>
        /// Check if user is an alumni
        /// </summary>
        /// <param name="userId">User identifier code</param>
        /// <returns>True if alumni</returns>
        private bool IsOnlyAlumni(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                List<PersonTypes> personTypes = LoginInfo.GetActiveRoles(userId);

                if ((personTypes != null) && (personTypes.Count == 1) && (personTypes.Contains(PersonTypes.Alumni)))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

    }
}
