using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class StudentController : Controller
    {
        private Util.Util util = new Util.Util();
        #region HTTPMethod Get

        [HttpGet]
        public ActionResult CreateStudent()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult UpdateStudent()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult GetStudent()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult DeleteStudent()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult SpecifyStudent()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }

        #endregion
    }
}