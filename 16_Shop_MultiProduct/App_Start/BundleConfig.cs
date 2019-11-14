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
              "~/theme/wp-includes/js/jquery/jquery-migrate.min.js",
              "~/theme/wp-content/plugins/ovic-toolkit/assets/js/jquery.magnific-popup.min.js",
              "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/bootstrap.min.js",
              "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/slick.min.js",
              "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/lazyload.min.js",
              "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/growl.min.js",
              "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/libs/chosen.min.js",
              "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/js/frontend.min.js",
              "~/Scripts/jquery.cokie.min.js",
              "~/Html/js/javascript.js"
          ));
            bundles.Add(new StyleBundle("~/bundles/global.css").Include(
                  "~/theme/wp-includes/css/dist/block-library/style.min.css",
                  "~/theme/wp-includes/css/dist/block-library/theme.min.css",
                  "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/css/chosen.min.css",
                  "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/css/animate.min.css",
                  "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/css/slick.min.css",
                  "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/css/growl.min.css",
                  "~/theme/wp-content/themes/gokko/assets/fonts/gokko/style.css",
                  "~/theme/wp-content/themes/gokko/assets/css/style.css",
                  "~/theme/wp-content/plugins/ovic-toolkit/includes/frontend/assets/css/frontend.css",
                  "~/theme/wp-content/plugins/js_composer/assets/css/js_composer.min.css",
                  "~/theme/wp-content/plugins/ovic-toolkit/includes/extends/megamenu/assets/css/megamenu-frontend.css",
                  "~/theme/wp-content/themes/gokko/style.css"
           ));
            BundleTable.EnableOptimizations = false;
        }
    }
}
