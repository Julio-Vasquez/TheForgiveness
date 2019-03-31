using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class SharedController : Controller
    {
        private Util.Util util = new Util.Util();
        // GET: Shared
        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult NoFound()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                ViewBag.dinMen = util.getMenu(Session["username"].ToString());
                ViewBag.Rol = util.getRole(Session["username"].ToString());
                return View();
            }
            return RedirectToAction("Error404", "Shared");
        }

        public ActionResult DashBoard()
        {
            return RedirectToAction("Login", "Home");
        }

    }
}