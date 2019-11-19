using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class StudentController : Controller
    {
        private Util.Util util = new Util.Util();
        #region HTTPMethod Get

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateStudent")]
        public PartialViewResult CreateStudent()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateStudent")]
        public ActionResult UpdateStudent()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetStudents")]
        public PartialViewResult GetStudents()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteStudent")]
        public ActionResult DeleteStudent()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetStudents")]
        public ActionResult SpecifyStudent()
        {
            return View();
        }

        #endregion
    }
}