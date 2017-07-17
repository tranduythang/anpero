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
                        "~/assets/lib/jquery/jquery-1.11.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(                      
                       "~/Scripts/jquery.cokie.min.js",
                       "~/Scripts/ShoppingCart.js",
                         "~/Scripts/Anpero.Common.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(

           ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
