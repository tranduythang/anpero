using System.Web;
using System.Web.Optimization;

namespace AnperoFrontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/vendor/jquery-224.js"));

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
              "~/assets/css/owl.carousel.min.css",
              "~/assets/css/style.css",
              "~/assets/css/responsive.css"
           ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
