using System.Web.Optimization;

namespace WebApplication {
    public class BundleConfig {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-2.2.3.js",
                        "~/scripts/jquery.bootgrid.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/index").Include(
                      "~/scripts/index.js",
                      "~/scripts/googleApi.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/jquery.bootgrid.min.css",
                      "~/Content/index.css"));
        }
    }
}