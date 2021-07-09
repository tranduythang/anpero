using System.Web.Optimization;

namespace AnperoFrontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //< add name = "scriptBundle" verb = "*" path = "/bundles/global.js" type = "System.Web.Optimization.BundleHandler, System.Web.Optimization" preCondition = "managedHandler" />

            //  < add name = "cssBundle" verb = "*" path = "/bundles/global.css" type = "System.Web.Optimization.BundleHandler, System.Web.Optimization" preCondition = "managedHandler" />
            bundles.Add(new ScriptBundle("~/bundles/global.js").Include(                  
                "~/theme/wp-includes/js/jquery/jquery-migrate.min.js",
                "~/theme/wp-content/plugins/ovic-toolkit/assets/js/jquery.magnific-popup.min.js",
                "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/bootstrap.min.js",
                "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/slick.min.js",
                "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/lazyload.min.js",
                "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/growl.min.js",
                "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/frontend.min.js",
                "~/Html/js/javascript.js"
            ));
            bundles.Add(new ScriptBundle("~/bundle/js").Include(
                "~/Html/js/jquery-1.10.2.min.js",
                "~/Html/js/bootstrap.min.js",                
                "~/Html/js/owl.carousel.min.js",
                //"~/Html/js/bootstrap-datetimepicker.js",
                "~/Scripts/jquery.cokie.min.js",
                "~/Scripts/Anpero.Common.js",
                //"~/Scripts/ShoppingCart.js",
                "~/Html/js/javascript.js"
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
