using System.Web;
using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/libraries/jquery-3.3.1.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/system-monitor").Include(
                "~/Scripts/system-monitor.js"));
        }
    }
}
