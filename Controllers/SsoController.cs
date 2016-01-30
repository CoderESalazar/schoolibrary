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
    /// <summary>
    /// SSO Controller class will be responsible for handling security integration between Proxy and CourseRoom
    /// </summary>
    /// <remarks>
    /// After many weeks of trying to understand the mixed technologies of the library (MVC and EZproxy) and how to best make it work with MVC forms authentication, it
    /// was finally realized that we need to make sure that only the MVC part of the library communicates with CourseRoom for authentication and that this library MVC
    /// already knows what information the proxy needs. Meanwhile, CourseRoom should just understand how to do forms authentication with any application regardless of
    /// library and should not have any special knowledge about some remote system. We learned that Compass had special library code for connectivity which in hindsight
    /// should never have been there. Hence, to ensure proper separation of concern, this SSO controller class is provided.
    /// 
    /// Below is a conceptual diagram of how we see the interaction between the various SSO players
    /// 
    /// <![CDATA[
    ///         user -->  library <--> proxy ---> database URL  <-- user
    ///                           <--> CourseRoom
    /// ]]> 
    /// 
    /// To make this all work the following setup is require
    /// 
    /// 1. The web.config file of the library needs the following settings (sample values are provided)
    /// <![CDATA[
    ///     <appSettings>
    ///         <add key="Log_Environment" value="qa"/>
    ///         <add key="Log_Project" value="Other"/>
    ///         <add key="CourseRoomLoginUrl" value="http://beta2-my.ncu.edu/Account/LogOn?ReturnSite=qa-library.ncu.edu" />
    ///         <add key="CourseRoomLogoutUrl" value="http://beta2-my.ncu.edu/Account/LogOff?ReturnSite=qa-library.ncu.edu&amp;ReturnUrl=/Home/Index" />
    ///         ...
    ///     </appSettings>
    ///     
    ///     <authentication mode="Forms">
    ///         <forms loginUrl="http://beta2-my.ncu.edu/Account/logon?ReturnSite=qa-library.ncu.edu" timeout="2880" cookieless="UseCookies" domain="ncu.edu" enableCrossAppRedirects="true" path="/" slidingExpiration="true" name=".NcuAuth" />
    ///     </authentication>
    ///     
    ///     <machineKey decryption="Auto" decryptionKey="B8317A18E2E49670FB395EEACFD0B161FC7AB689B2AEA159,IsolateApps" validation="SHA1" validationKey="5D5ECD048862186AF47D7B53E64E7A3F015F440CA647C5F0E5EC20E4CD28661FC763AFA1A4991EA5DBBDDB31776B2945D9CF80614548AE9C8CF6CAF092C8E4CA,IsolateApps"/>
    /// ]]> 
    /// 
    /// 2. The possible values for the machineKey is environment specific and must be one of the following values below
    /// <![CDATA[
    ///     Beta Environment:       <machineKey decryption="Auto" decryptionKey="B8317A18E2E49670FB395EEACFD0B161FC7AB689B2AEA159,IsolateApps" validation="SHA1" validationKey="5D5ECD048862186AF47D7B53E64E7A3F015F440CA647C5F0E5EC20E4CD28661FC763AFA1A4991EA5DBBDDB31776B2945D9CF80614548AE9C8CF6CAF092C8E4CA,IsolateApps"/>
    ///     Debug Environment:      <machineKey decryption="Auto" decryptionKey="514C3A7D626A1EA930DEEE85505891760761BF8F139CF12B,IsolateApps" validation="SHA1" validationKey="816735CA3C59E77033F449CD07520FFBAD3760CC39418D2C97A837685F4BA84E8B1170AAAE53E606AC82E41CA8C7BF5C29455CA6A8D9FFAC14FAE5EFDD2552A5,IsolateApps"/>
    ///     Release Environment:    <machineKey decryption="Auto" decryptionKey="9FF12E185413C32D647F71B8DB8F0013E914A06BFF3DB951,IsolateApps" validation="SHA1" validationKey="F1EB4B59FAC02CF48B24966BEFF16ABE9C829BAC3FB9EC538E4EF79BC9B1A1737118C29F58E7D7E3E3D7858487ECDA15C7EB0D9B9120D58B778C105BCA3D5146,IsolateApps"/>
    ///     UAT Environment:        <machineKey decryption="Auto" decryptionKey="7FE724CD9EA5F14DE67094B76C48AF2547CB89A04E928B55,IsolateApps" validation="SHA1" validationKey="0D52A1ACA42E6F722F44E31FE377A83D6DC6DD0EDD28CAF4412AC08F72E9B59502CC71A9100E3ED7188357E5931024E8A49101787A2F8607B62965D5AB22E630,IsolateApps"/>
    /// ]]> 
    /// 
    /// 3. The proxy user file needs to have the following entry
    /// <![CDATA[
    ///     someuser:somepass:cgi=http://qa-library.ncu.edu/SSO/Authenticate?ReturnSite=proxy3.ncu.edu&ReturnUrl=^U
    /// ]]> 
    ///     where the ^U causes the proxy to placed the full URL where the user desires to be redirect too - like one of the databases selected   
    ///    
    /// 4. NCU development staff has provided the following DLL components for
    ///     log4net.dll                     Needed for the NCU common logger
    ///     Ncu.Component.Schools.dll       Standard component which wraps school business rules
    ///     Ncu.logging.Logger.dll          Standard NCU common logger
    /// 
    /// </remarks>
    public class SsoController : Controller
    {
        /// <summary>
        /// Determines if authentication with CourseRoom has already occurred or not. If already authenticated with CourseRoom, then return back to proxy
        /// the necessary authentication URL it needs to finish user request. If not authenticated with CourseRoom, then proceed to authenticate with CourseRoom.
        /// </summary>
        /// <returns>ActionResult object</returns>
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
                        return PartialView("_proxyError");
                    }
                    else
                    {
                        string returnSite = GetQueryValue(httpContext, QS_PARM_SITE);
                        string returnUrl = GetQueryValueToEndOfQS(httpContext, QS_PARM_RETURN_URL);

                        // Construct the authentication URL expected by the proxy
                        string redirectUrl = CreateProxySSOUrl(userId, returnSite, returnUrl);

                        return Redirect(redirectUrl);
                    }
                }
                else
                {
                    string returnSite = GetQueryValueToParmOfQS(httpContext, QS_PARM_SITE);
                    string returnUrl = GetQueryValueToEndOfQS(httpContext, QS_PARM_RETURN_URL);
                    if (string.IsNullOrEmpty(returnUrl)) returnUrl = GetQueryValueToEndOfQS(httpContext, QS_PARM_ALTERNATE_RETURN_URL);      // In case ^U is not use in the proxy!

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
        /// Gets a query string parameter value by removing data spill over into other parameters due to incorrect characters supplied by third party vendor
        /// like ClearSolutions which we are not able to tell them to change their code!!
        /// </summary>
        /// <remarks>
        /// This routine to be used when the queryName is not properly terminated with an ampersand in a query string (QS)
        /// </remarks>
        /// <param name="context">Reference to a HtptContext object</param>
        /// <param name="queryName">Query string parameter name</param>
        /// <returns>Query string parameter value</returns>
        private string GetQueryValueToParmOfQS(HttpContext context, string queryName)
        {
            string queryValue = string.Empty;

            if ((context != null) && HttpRequestExists(context) && (context.Request.QueryString != null))
            {
                queryValue = context.Request.QueryString[queryName];

                queryValue = CompensateForImproperParmeterOfQS(queryValue);
            }

            return queryValue;
        }

        /// <summary>
        /// Gets a query string parameter value by assuming that the parameter is the last one in the query string and that all characters to the end belongs to it! This
        /// routine is needed since the third party vendor ClearSolutions fails to encode the additional query parameters it attaches!!
        /// </summary>
        /// <remarks>
        /// This routine to be used when the queryName is the expected last parameter of a query string (QS)
        /// </remarks>
        /// <param name="context">Reference to a HtptContext object</param>
        /// <param name="queryName">Query string parameter name</param>
        /// <returns>Query string parameter value</returns>
        private string GetQueryValueToEndOfQS(HttpContext context, string queryName)
        {
            int startIndex = 0;
            string queryValue = string.Empty;
            string queryString = string.Empty;

            if ((context != null) && HttpRequestExists(context) && (context.Request.QueryString != null))
            {
                queryString = HttpUtility.UrlDecode(context.Request.QueryString.ToString());

                queryName = queryName + "=";

                // Check that we are in range!
                startIndex = queryString.IndexOf(queryName, StringComparison.CurrentCultureIgnoreCase) + queryName.Length;
                if ((startIndex >= 0) && (startIndex < queryString.Length))
                {
                    queryValue = queryString.Substring(startIndex);
                }

                queryValue = HttpUtility.UrlEncode(queryValue);
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
            const string URL_FORMAT = "{0}&ReturnUrl=Sso%2FAuthenticate%3FReturnSite%3d{1}%26ReturnUrl%3d{2}";      // Encoding apply so that CR SSO does not interpret it but returns it back!!

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

                if ( (personTypes != null) && (personTypes.Count == 1) && (personTypes.Contains(PersonTypes.Alumni)) )
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Compensates for the possibility that the QS parameter value was properly parsed
        /// </summary>
        /// <remarks>
        /// It appears some third party vendors like ClearSolutions do not properly format their ReturnSite/ReturnUrl information correctly!
        /// </remarks>
        /// <param name="valueInQuestion">QA parameter value in question</param>
        /// <returns>Proper QA parameter value</returns>
        private string CompensateForImproperParmeterOfQS(string valueInQuestion)
        {
            const string EQUAL = "=";

            int startPos = -1;
            int endPos = -1;
            string queryValue = string.Empty;

            // Does queryValue have other query parameters embedded in it such as ReturnUrl?
            if (!string.IsNullOrEmpty(valueInQuestion))
            {
                endPos = valueInQuestion.IndexOf(EQUAL);
                if (endPos > 0)
                {
                    // Find the first non-character that should have been an ampersand...
                    for (int index = endPos - 1; index >= 0; --index)
                    {
                        if (!Char.IsLetterOrDigit(valueInQuestion[index]))
                        {
                            startPos = index;
                            break;
                        }
                    }

                    // If we found the starting position of non-character then it is really the length of the desire characters we want!
                    if (startPos >= 0)
                    {
                        queryValue = valueInQuestion.Substring(0, startPos);
                    }
                }
                else
                {
                    queryValue = valueInQuestion;
                }
            }

            return queryValue;
        }

        #endregion

    }
}
