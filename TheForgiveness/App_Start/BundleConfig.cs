using System.Web;
using System.Web.Optimization;

namespace TheForgiveness
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            #region bundle Css
            bundles.Add(new StyleBundle("~/DashBoardCSS").Include(
                "~/Assets/Css/DashBoard/jquery.steps.min.css",
                "~/Assets/Css/DashBoard/steps.min.css",
                "~/Assets/Css/DashBoard/bootstrap.min.css",
                "~/Assets/Css/DashBoard/Icons.min.css",
                "~/Assets/Css/DataTable/jquery.dataTables.min.css"
                ));

            bundles.Add(new StyleBundle("~/LoginCss").Include(
                "~/Assets/Css/Login/Style.css",
                "~/Assets/Css/Login/validation.css"
                ));

            bundles.Add(new StyleBundle("~/SignUpCss").Include(
                "~/Assets/Css/SignUp/bootstrap.min.css",
                "~/Assets/Css/SignUp/wizard.min.css"
                ));
            #endregion bundle Css

            #region bundle JS
            bundles.Add(new ScriptBundle("~/LoginJs").Include(
                "~/Assets/Js/Login/validationFunctions.js",
                "~/Assets/Js/Login/validation.js"
                ));

            bundles.Add(new ScriptBundle("~/SignUpJs").Include(
                "~/Assets/Js/SignUp/jquery-2.2.4.min.js",
                "~/Assets/Js/SignUp/bootstrap.min.js",
                "~/Assets/Js/SignUp/jquery.bootstrap.wizard.min.js",
                "~/Assets/Js/SignUp/wizard.js",
                "~/Assets/Js/SignUp/jquery.validate.min.js"
                ));

            bundles.Add(new ScriptBundle("~/DashBoardJS").Include(
                "~/Assets/Js/DashBoardP/popper.min.js",
                "~/Assets/Js/DashBoardP/bootstrap.min.js",
                "~/Assets/Js/DashBoardP/perfect-scrollbar.jquery.min.js",
                "~/Assets/Js/DashBoardP/sparkline.min.js",
                "~/Assets/Js/DashBoardP/waves.min.js",
                "~/Assets/Js/DashBoardP/sidebarmenu.min.js",
                "~/Assets/Js/DashBoardP/custom.min.js",
                "~/Assets/Js/DashBoardP/jquery.steps.min.js",
                "~/Assets/Js/sweetalert2.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Validation").Include(
                "~/Assets/Js/Validation/respond.min.js",
                "~/Assets/Js/Validation/jquery.validate.min.js",
                "~/Assets/Js/Validation/jquery.unobtrusive-ajax.min.js",
                "~/Assets/Js/Validation/jquery.validate.unobtrusive.min.js",
                "~/Assets/Js/DataTable/jquery.dataTables.min.js"
                ));

            bundles.Add(new ScriptBundle("~/JQRequired").Include(
                    "~/Assets/Js/Validation/jquery-3.3.1.min.js"
                ));

            #endregion bundle JS
            BundleTable.EnableOptimizations = true;
        }
    }
}
