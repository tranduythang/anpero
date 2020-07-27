using System.Web.Optimization;

namespace _12_Theme_Multi_Product_Option_2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/js").Include(                
                 "~/Scripts/jquery.cokie.min.js",
                 "~/Content/theme/js/bootstrap.min.js",
                 "~/Content/theme/js/owl.carousel.min.js",
                 "~/Content/theme/js/javascript.js",
                 "~/Scripts/Anpero.Common.js",
                 "~/Scripts/ShoppingCart.js"
             ));

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                "~/Content/theme/css/bootstrap.min.css",
                "~/Content/theme/css/font-awesome.min.css",
                "~/Content/theme/css/swiper-bundler.min.css",
                "~/Content/theme/css/style.css",
                "~/Content/css/dev-style.css"
            ));
        }
    }
}
