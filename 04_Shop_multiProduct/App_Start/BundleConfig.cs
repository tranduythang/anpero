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
                        "~/assets/lib/jquery/jquery-1.11.2.min.js",
                        "~/Scripts/Anpero.Common.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/lib/bootstrap/js/bootstrap.min.js",
                      "~/assets/lib/select2/js/select2.min.js",
                       "~/assets/lib/jquery-bxslider/jquery-bxslider.min.js",
                       "~/assets/lib/owl-carousel/owl-carousel.min.js",
                       "~/assets/js/jquery.actual.min.js",
                       "~/assets/js/theme-script.js",                       
                       "~/Scripts/jquery.cokie.min.js",
                       "~/Scripts/Bootrap-notify.js",
                   
                       "~/Scripts/ShoppingCart.js",
                         "~/Scripts/Anpero.Common.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
             "~/assets/lib/bootstrap/css/bootstrap.min.css",
              "~/assets/lib/font-awesome/css/font-awesome.min.css",              
              "~/assets/lib/select2/css/select2.min.css",
              "~/assets/lib/owl-carousel/owl-carousel.css",
              "~/assets/lib/jquery-ui/jquery-ui.css",
              "~/assets/css/animate.css",
              "~/assets/css/reset.css",
              "~/assets/css/style.css",
              "~/assets/css/responsive.css"
           ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
