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
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Error404()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult NoFound()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                return View();
            }
            return RedirectToAction("Error404", "Shared");
        }
        [HttpGet]
        public ActionResult DashBoard()
        {
            return RedirectToAction("Login", "Home");
        }

    }
}