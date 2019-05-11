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
        private Services.usuarioService us = new Services.usuarioService();
        // GET: Profile
        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
        }

        [HttpGet]
        public ActionResult Profile()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                return View();
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

        #region POSTMethod
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(Models.PasswordModel pm)
        {
            if (ModelState.IsValid && us.ResetPassWordUser(pm, Session["username"].ToString()))
            {
                return RedirectToAction("Profile");
            }
            return View();
        }

        #endregion POSTMethod

    }
}