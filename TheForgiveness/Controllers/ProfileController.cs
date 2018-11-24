using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult UpdateUser()
        {
            return View();
        }

        public ActionResult UpdatePerfil()
        {
            return View();
        }

        public ActionResult User()
        {
            return View();
        }

        
    }
}