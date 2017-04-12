using System.Web;
using System.Web.Optimization;

namespace ExcellProtecaoVeicular.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/Scripts/jqueryMaskedInput").Include(
                "~/Scripts/jquery.maskedinput*"));
            bundles.Add(new ScriptBundle("~/Scripts/jqueryvalidate").Include(
                "~/Scripts/jquery.validade*"));
            bundles.Add(new ScriptBundle("~/Scripts/classie").Include(
                "~/Scripts/classie*"));
            bundles.Add(new ScriptBundle("~/Scripts/wow").Include(
                "~/Scripts/wow*"));
            bundles.Add(new ScriptBundle("~/Scripts/jqueryisotope").Include(
                "~/Scripts/jquery.isotope*"));
            bundles.Add(new ScriptBundle("~/Scripts/modernizar").Include(
                "~/Scripts/modernizr-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap*"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css").Include("~/Content/responsive.css").Include("~/Content/style.css"));
            
        }
    }
}