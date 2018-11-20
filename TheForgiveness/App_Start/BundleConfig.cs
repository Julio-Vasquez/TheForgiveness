﻿using System.Web;
using System.Web.Optimization;

namespace TheForgiveness
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/DashBoardCSS").Include(
                "~/Assets/Css/DashBoard/jquery.steps.min.css",
                "~/Assets/Css/DashBoard/steps.min.css",
                "~/Assets/Css/DashBoard/bootstrap.min.css"
                ));

            bundles.Add(new ScriptBundle("~/DashBoardJS").Include(
                "~/Assets/Js/DashBoardP/popper.min.js",
                "~/Assets/Js/DashBoardP/bootstrap.min.js",
                "~/Assets/Js/DashBoardP/perfect-scrollbar.jquery.min.js",
                "~/Assets/Js/DashBoardP/sparkline.min.js",
                "~/Assets/Js/DashBoardP/waves.min.js",
                "~/Assets/Js/DashBoardP/sidebarmenu.min.js",
                "~/Assets/Js/DashBoardP/custom.min.js",
                "~/Assets/Js/DashBoardP/jquery.steps.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Validation").Include(
                "~/Assets/Js/Validation/jquery-3.3.1.min.js",
                "~/Assets/Js/Validation/respond.min.js",
                "~/Assets/Js/Validation/jquery.validate.min.js",
                "~/Assets/Js/Validation/jquery.validate.unobtrusive.min.js"
                ));
        }
    }
}
