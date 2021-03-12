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
              "~/assets/components/base/core.min.js",
              "~/assets/components/base/script.js",
              "~/Scripts/js-cokie.js",
              "~/Scripts/Anpero.Common.js"
              
          ));
        bundles.Add(new StyleBundle("~/bundles/global.css").Include(
                "~/assets/components/base/base.css"

         ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
