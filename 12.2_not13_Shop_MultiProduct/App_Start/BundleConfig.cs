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
                       "~/Scripts/Anpero.Common.js",
                       "~/assets/js/common.js",
                       "~/assets/assets.js",
                       "~/assets/shop.js",
                       "~/assets/scripts.js",
                       "~/assets/animate.js",
                       "~/Scripts/ShoppingCart.js"                         
                       ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/jquery.cokie.min.js",
                         "~/Scripts/Anpero.Common.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/assets/stylesheet/style.css"
                  


           ));
            BundleTable.EnableOptimizations = false;
        }
    }
}
