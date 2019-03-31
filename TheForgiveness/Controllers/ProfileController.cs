using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class ProfileController : Controller
    {
        private Util.Util util = new Util.Util();
        // GET: Profile
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Profile()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                if (ViewBag.dinMen.Rows.Count > 0)
                {
                    return View();
                }
                return RedirectToAction("NoFound", "Shared");
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
        }

        [HttpGet]
        public ActionResult UpdateUser()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UpdatePerfil()
        {
            return View();
        }

        [HttpGet]
        public ActionResult User()
        {
            return View();
        }

        
    }
}