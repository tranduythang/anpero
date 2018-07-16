using System.Web;
using System.Web.Optimization;

namespace AnperoFrontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                  "~/assets/js/vendor/jquery-224.js",
                  "~/assets/js/bootstrap-min.js",
                    "~/assets/js/mixitup-min.js",
                    "~/assets/js/pogo-slider.js",
                    "~/assets/js/ajaxchimp.js",
                    "~/assets/js/lightbox.js",
                     "~/assets/js/scrollUp-min.js",
                     "~/assets/js/wow-min.js",
                     "~/assets/js/arallax-113.js",
                     "~/assets/js/plugins.js",
                      "~/Scripts/Anpero.Common.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      
                       "~/Scripts/jquery.cokie.min.js",
                       "~/Scripts/ShoppingCart.js",
                         "~/Scripts/Anpero.Common.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/assets/css/font-awesome.min.css",
                       "~/assets/css/normalize.css",
                        "~/assets/css/pogo-slide.css",
                        "~/assets/css/bootstrap.min.css",
                        "~/assets/css/lightbox.css",
                        "~/assets/css/animate.css",
                         "~/assets/css/style.css",
                         "~/assets/css/ProductListStyle.css",
                        "~/assets/css/responsive.css"
           ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
