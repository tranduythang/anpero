using System.Web;
using System.Web.Optimization;

namespace AnperoFrontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery.cokie.min.js",
                        "~/assets/js/bootstrap.min.js",
                        "~/assets/js/javascript.js",
                        "~/assets/js/owl.carousel.min.js",
                         "~/Scripts/Anpero.Common.js",
                         "~/Scripts/ShoppingCart.js"                         
                       ));             
                bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/jquery.cokie.min.js",
                         "~/Scripts/Anpero.Common.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/assets/css/bootstrap.min.css",
                  "~/assets/css/style.css",
                  "~/assets/css/font-awesome.min.css"
           ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
