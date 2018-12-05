using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class DashBoardController : Controller
    {
        private Util.Util util = new Util.Util();
        // GET: Profile
        public ActionResult Index()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                ViewBag.dinMen = util.getMenu(Session["username"].ToString());
                ViewBag.Rol = util.getRole(Session["username"].ToString());
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }

        }

        public ActionResult Crearstudent()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                ViewBag.dinMen = util.getMenu(Session["username"].ToString());
                ViewBag.Rol = util.getRole(Session["username"].ToString());
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }

        }

        public ActionResult CreateStudent()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                ViewBag.dinMen = util.getMenu(Session["username"].ToString());
                ViewBag.Rol = util.getRole(Session["username"].ToString());
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }

        }
    }
}