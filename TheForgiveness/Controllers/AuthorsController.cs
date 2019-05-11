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

        public ActionResult CreateAuthors()
        {
            return View();
        }

        public ActionResult UpdateAuthors()
        {
            return View();
        }

        public ActionResult DeleteAuthors()
        {
            return View();
        }
        public ActionResult GetAuthors()
        {
            return View();
        }
    }
}