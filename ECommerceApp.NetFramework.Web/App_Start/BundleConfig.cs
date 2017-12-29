using System.Web;
using System.Web.Optimization;

namespace ECommerceApp.NetFramework.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/modernizr-*",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",                 
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));
        }
    }
}
