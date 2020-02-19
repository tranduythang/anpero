using System.Web;
using System.Web.Optimization;

namespace AnperoFrontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/global.js").Include(
              "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/bootstrap.min.js",                                          
              "~/Scripts/jquery.cokie.min.js"
          ));
            bundles.Add(new StyleBundle("~/bundles/global.css").Include(
                  "~/assets/css/fonts.css",
                  "~/assets/css/styles.css"
           ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
