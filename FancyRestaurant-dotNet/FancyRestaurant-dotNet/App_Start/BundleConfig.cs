using System.Web;
using System.Web.Optimization;

namespace FancyRestaurant.App_Start
{
   public class BundleConfig
   {
      public static void RegisterBundles(BundleCollection bundles)
      {
         bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/scripts/jquery-3.1.0.min.js"));

         bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/scripts/bootstrap.min.js"));

         bundles.Add(new StyleBundle("~/Content/css")
            .Include("~/Content/bootswatch/spacelab/bootstrap.min.css",
            "~/Content/font-awesome.min.css",
            "~/Content/css/site.css"));
      }
   }
}
