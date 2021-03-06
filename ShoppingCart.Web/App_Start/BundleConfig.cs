﻿using System.Web;
using System.Web.Optimization;

namespace ShoppingCart.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Lib/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Lib/bootstrap.js",
                      "~/Scripts/Lib/respond.js"));


            bundles.Add(new ScriptBundle("~/bundles/shocartgeneral").Include(
                        "~/Scripts/Lib/jquery-{version}.js",
                        "~/Scripts/Lib/jquery.validate.js",
                        "~/Scripts/Lib/bootstrap.js",
                        "~/Scripts/Lib/respond.js",
                        "~/Scripts/Lib/knockout-{version}.js",
                        "~/Scripts/Lib/knockout.mapping-latest.js"
                        ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme-paper.css",
                      "~/Content/site.css"));
        }
    }
}
