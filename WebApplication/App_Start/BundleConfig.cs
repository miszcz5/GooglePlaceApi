using System.Web.Optimization;

namespace WebApplication {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-2.2.3.js",
                        "~/scripts/jquery.bootgrid.min.js"));

            bundles.Add(new Bundle("~/bundles/index").Include(
                      "~/scripts/index.js",
                      "~/scripts/googleApi.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/jquery.bootgrid.min.css",
                      "~/Content/index.css"));
        }
    }
}