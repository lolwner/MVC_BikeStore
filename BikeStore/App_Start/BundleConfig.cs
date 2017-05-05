using System.Web;
using System.Web.Optimization;

namespace BikeStore
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/AdminPanel/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/buttons.css",
                      "~/Content/calendar.css",
                      "~/Content/forms.css",
                      "~/Content/stats.css",
                      "~/Content/AdminPanel/styles.css"));

            bundles.Add(new StyleBundle("~/Content/KendoGrid/css").Include(
                      "~/Content/KendoGrid/bootstrap.min.css",
                      "~/Content/KendoGrid/kendo.common.min.css",
                      "~/Content/KendoGrid/kendo.default.min.css",
                      "~/Content/KendoGrid/kendo.rtl.min.css",
                      "~/Content/KendoGrid/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/index.run").Include(
                        "~/Scripts/index.run.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/KendoGrid/jquery.min.js",
                        "~/Scripts/KendoGrid/jszip.min.js",
                        "~/Scripts/KendoGrid/kendo.all.min.js",
                        "~/Scripts/KendoGrid/ModeratorGrid.js"));
        }
    }
}
