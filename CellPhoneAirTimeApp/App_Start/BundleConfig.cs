using System.Web.Optimization;

namespace CellPhoneAirTimeApp
{
    public class LessTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            //response.Content = dotless.Core.Less.Parse(response.Content);
            //response.ContentType = "text/css";
        }
    }

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Compile .less files and create a bundle for them.
            //var lessBundle = new Bundle("~/Content/less").Include(
            //    "~/assets/less/bootstrap.less",
            //     "~/assets/less/color.less",
            //     "~/assets/less/components.less",
            //     "~/assets/less/core.less");

            //lessBundle.Transforms.Add(new LessTransform());
            //lessBundle.Transforms.Add(new CssMinify());
            //bundles.Add(lessBundle);


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/css/icons/icomoon/styles.css",
                      "~/assets/css/bootstrap.css",
                      "~/assets/css/core.css",
                      "~/assets/css/components.css",
                      "~/assets/css/colors.css"));

            bundles.Add(new ScriptBundle("~/Content/angular").Include(
                "~/assets/js/core/libraries/angular.js"));

            bundles.Add(new ScriptBundle("~/Content/angular-route").Include(
                "~/assets/js/core/libraries/angular-route.js"));

            bundles.Add(new ScriptBundle("~/Content/core/js").Include(
                "~/assets/js/core/libraries/jquery.min.js",
                "~/assets/js/core/libraries/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Content/js/app").Include(
                "~/assets/js/core/app.js"));

            bundles.Add(new ScriptBundle("~/Content/js/libs").Include(
                "~/assets/js/plugins/forms/selects/select2.min.js"));

            //"~/assets/js/pages/my_settings.js",
            bundles.Add(new ScriptBundle("~/Content/js/my_settings").Include(
                "~/assets/js/plugins/forms/styling/uniform.min.js"));

            bundles.Add(new ScriptBundle("~/Content/js/users").Include(
                "~/assets/js/plugins/tables/datatables/datatables.min.js"));
        }
    }
}