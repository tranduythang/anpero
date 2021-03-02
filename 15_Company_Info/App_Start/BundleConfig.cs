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
                        "~/assets/lib/jquery/jquery-1-11-2.js"
                        ));




            bundles.Add(new ScriptBundle("~/bundles/global.js").Include(
                      "~/wp-content/themes/archi-3.0.1/js/total12513.js",
                      "~/wp-content/themes/archi-3.0.1/js/classie2513.js",
                      "~/wp-content/themes/archi-3.0.1/js/wow.min2513.js",
                      "~/wp-content/themes/archi-3.0.1/js/enquire.min2513.js",
                      "~/wp-content/themes/archi-3.0.1/js/jquery.mb.YTPlayer.min2513.js",
                      "~/wp-content/themes/archi-3.0.1/js/typed2513.js",
                      "~/wp-content/themes/archi-3.0.1/js/designesia2513.js",
                      "~/wp-content/plugins/js_composer/assets/js/dist/js_composer_front.min1eb7.js",
                      "~/wp-content/plugins/js_composer/assets/lib/vc_waypoints/vc-waypoints.min1eb7.js",
                       "~/Scripts/Anpero.Common.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
             "~/wp-includes/css/dist/block-library/style.min2513.css",
              "~/wp-content/themes/archi-3.0.1/css/bootstrap2513.css",
              "~/wp-content/themes/archi-3.0.1/css/animate2513.css",
              "~/wp-content/themes/archi-3.0.1/css/owl.carousel2513.css",
              "~/wp-content/themes/archi-3.0.1/css/owl.theme2513.css",
              "~/wp-content/themes/archi-3.0.1/css/owl.transitions2513.css",
              "~/wp-content/themes/archi-3.0.1/fonts/font-awesome/css/font-awesome2513.css",
              "~/wp-content/themes/archi-3.0.1/css/jquery.mb.YTPlayer.min2513.css",
              "~/wp-content/themes/archi-3.0.1/styleba8c.css",
              "~/wp-content/themes/archi-3.0.1/css/light2513.css",
              "~/wp-content/themes/archi-3.0.1/css/bg2513.css",
              "~/wp-content/themes/archi-3.0.1/css/rev-settings2513.css",
              "~/wp-content/themes/archi-3.0.1/framework/color2513.css",
              "~/wp-content/plugins/js_composer/assets/css/js_composer.min1eb7.css"
              
           ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
