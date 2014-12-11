using System.Web;
using System.Web.Optimization;

namespace VirtualDesign
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));*/

            #region scripts
            bundles.Add(new ScriptBundle("~/bundles/framework").Include(
                        "~/Content/assets/plugins/jquery-1.8.3.min.js",
                        "~/Content/assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js",
                        "~/Content/assets/plugins/boostrapv3/js/bootstrap.min.js",
                        "~/Content/assets/plugins/breakpoints.js",
                        "~/Content/assets/plugins/jquery-unveil/jquery.unveil.min.js",
                        "~/Content/assets/plugins/jquery-block-ui/jqueryblockui.js",
                        "~/Content/assets/plugins/jquery-lazyload/jquery.lazyload.min.js",
                        "~/Content/assets/plugins/jquery-scrollbar/jquery.scrollbar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Content/assets/plugins/jquery-slider/jquery.sidr.min.js",
                        "~/Content/assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Content/assets/plugins/pace/pace.min.js",
                        "~/Content/assets/plugins/jquery-numberAnimate/jquery.animateNumbers.js",
                        "~/Content/assets/plugins/jquery-ricksaw-chart/js/raphael-min.js",
                        "~/Content/assets/plugins/jquery-ricksaw-chart/js/d3.v2.js",
                        "~/Content/assets/plugins/jquery-ricksaw-chart/js/rickshaw.min.js",
                        "~/Content/assets/plugins/jquery-sparkline/jquery-sparkline.js",
                        "~/Content/assets/plugins/skycons/skycons.js",
                        "~/Content/assets/plugins/owl-carousel/owl.carousel.min.js",
                        "~/Content/assets/plugins/Mapplic/js/jquery.easing.js",
                        "~/Content/assets/plugins/Mapplic/js/jquery.mousewheel.js",
                        "~/Content/assets/plugins/Mapplic/js/hammer.js",
                        "~/Content/assets/plugins/Mapplic/mapplic/mapplic.js",
                        "~/Content/assets/plugins/jquery-flot/jquery.flot.js",
                        "~/Content/assets/plugins/jquery-flot/jquery.flot.resize.min.js",
                        "~/Content/assets/plugins/jquery-metrojs/MetroJs.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/template").Include(
                      "~/Content/assets/js/core.js",
                      "~/Content/assets/js/chat.js",
                      "~/Content/assets/js/demo.js",
                      "~/Content/assets/js/dashboard_v2.js"));

            #endregion

            #region Styles
            bundles.Add(new StyleBundle("~/Content/template").Include(
                      "~/Content/assets/css/style.css",
                      "~/Content/assets/css/responsive.css",
                      "~/Content/assets/css/custom-icon-set.css",
                      "~/Content/assets/css/magic_space.css"));

            bundles.Add(new StyleBundle("~/Content/framework").Include(
                      "~/Content/assets/plugins/boostrapv3/css/bootstrap.css",
                      "~/Content/assets/plugins/boostrapv3/css/bootstrap-theme.css",
                      "~/Content/assets/plugins/font-awesome/css/font-awesome.css",
                      "~/Content/assets/css/animate.css",
                      "~/Content/assets/plugins/jquery-scrollbar/jquery.scrollbar.css"));


            bundles.Add(new StyleBundle("~/Content/plugins").Include(
                     "~/Content/assets/plugins/jquery-metrojs/MetroJs.min.css",
                     "~/Content/assets/plugins/shape-hover/css/demo.css",
                     "~/Content/assets/plugins/shape-hover/css/component.css",
                     "~/Content/assets/assets/plugins/owl-carousel/owl.carousel.css",
                     "~/Content/assets/assets/plugins/owl-carousel/owl.theme.css",
                     "~/Content/assets/plugins/pace/pace-theme-flash.css",
                     "~/Content/assets/plugins/jquery-slider/css/jquery.sidr.light.css",
                     "~/Content/assets/plugins/jquery-ricksaw-chart/css/rickshaw.css",
                     "~/Content/assets/plugins/Mapplic/mapplic/mapplic.css"));
            #endregion
        }
    }
}
