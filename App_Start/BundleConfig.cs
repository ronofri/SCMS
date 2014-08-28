using System.Web;
using System.Web.Optimization;

namespace SCMS
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/bootstrap-datepicker.js",

                       "~/Scripts/bootstrap3-typeahead.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/bootstrap.css",
                //"~/Content/bootstrap.min.css",
                        "~/Content/bootstrap-responsive.css",
                //"~/Content/bootstrap-responsive.min.css",
                        "~/Content/bootstrap-theme.css",//,
                        "~/Content/datepicker.css",
                        "~/Content/datepicker3.css"
                //"~/Content/bootstrap-theme.min.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new LessBundle("~/Content/less").Include("~/Content/*.less"));


            bundles.Add(new ScriptBundle("~/bundles/ganttjs").Include(
                        "~/Scripts/jquery.cookie.js",
                //"~/Scripts/jquery.fn.gantt.min.js",
                        "~/Scripts/jquery.fn.gantt.js"));

            bundles.Add(new StyleBundle("~/Content/ganttcss").Include(
                       "~/Content/style.css"));
        }
    }
}