using System.Web;
using System.Web.Optimization;

namespace LibraryMVC4
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-migrate-{version}.js",
                        "~/Scripts/library.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.unobtrusive*",
                       "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui*"));

            bundles.Add(new StyleBundle("~/bundles/themes/baseAll").IncludeDirectory("~/Content/themes/base", "*.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/content").Include(
                        "~/Content/jquery-ui*",
                        "~/Content/webgrid.css",
                        "~/Content/PagedList.css",
                        "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap").IncludeDirectory("~/Content/bootstrap", "*.css"));

        }
    }
}