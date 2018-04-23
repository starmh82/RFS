using System.Web;
using System.Web.Optimization;

namespace RFS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Content/dist/js/adminlte.js",
                      "~/Content/dist/js/demo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/bower_components/font-awesome/css/font-awesome.css",
                      "~/Content/bower_components/Ionicons/css/ionicons.css",
                      "~/Content/dist/css/AdminLTE.css",
                      "~/Content/dist/css/skins/_all-skins.css" ,
                      "~/Content/dist/css/MyCss.css"));


            // Morris.js Charts
            bundles.Add(new StyleBundle("~/bundles/morris").Include(
                "~/Content/bower_components/morris.js/morris.css"));

            bundles.Add(new ScriptBundle("~/bundles/morris.js").Include(
                "~/Content/bower_components/raphael/raphael.js",
                "~/Content/bower_components/morris.js/morris.js"));

            // iCheck : CUSTOMIZED CHECKBOXES AND RADIO BUTTONS FOR JQUERY & ZEPTO
            bundles.Add(new StyleBundle("~/bundles/icheck").Include(
               "~/Content/plugins/iCheck/square/blue.css"));

            bundles.Add(new ScriptBundle("~/bundles/icheck.js").Include(
                "~/Content/plugins/iCheck/icheck.min.js"));

            //Pace Automatic Page Load Progress
            bundles.Add(new StyleBundle("~/bundles/pace").Include(
               "~/Content/plugins/pace/pace.css"));

            bundles.Add(new ScriptBundle("~/bundles/pace.js").Include(
                "~/Content/plugins/pace/pace.min.js"));


            // Enables bundling and minification and overrides any setting in the Web.config file
            //BundleTable.EnableOptimizations = true;

        }
    }
}
