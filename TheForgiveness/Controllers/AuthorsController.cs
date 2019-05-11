using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class AuthorsController : Controller
    {
        private Util.Util util = new Util.Util();
        // GET: Profile
        [HttpGet]
        public ActionResult CreateAuthors()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdateAuthors()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteAuthors()
        {
            return View();
        }
    }
}