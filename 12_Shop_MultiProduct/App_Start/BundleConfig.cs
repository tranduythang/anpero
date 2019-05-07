using System.Web.Optimization;

namespace AnperoFrontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/js").Include(
                "~/Html/js/jquery-1.10.2.min.js",
                "~/Html/js/bootstrap.min.js",
                "~/Html/js/javascript.js",
                "~/Html/js/owl.carousel.min.js",
                //"~/Html/js/bootstrap-datetimepicker.js",
                "~/Scripts/jquery.cokie.min.js",
                "~/Scripts/Anpero.Common.js",
                "~/Scripts/ShoppingCart.js"
            ));

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                "~/Html/css/bootstrap.min.css",
                "~/Html/css/style.css",
                "~/Html/css/font-awesome.min.css"
            ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
