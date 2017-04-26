using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ExcellProtecaoVeicular.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryMaskedInput").Include(
                "~/Scripts/jquery.maskedinput*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidate").Include(
                "~/Scripts/jquery.validade*"));
            bundles.Add(new ScriptBundle("~/bundles/classie").Include(
                "~/Scripts/classie*"));
            bundles.Add(new ScriptBundle("~/bundles/wow").Include(
                "~/Scripts/wow*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryisotope").Include(
                "~/Scripts/jquery.isotope*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizar").Include(
                "~/Scripts/modernizr-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap*"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css", "~/Content/responsive.css", "~/Content/style.css"));
        }
    }
}