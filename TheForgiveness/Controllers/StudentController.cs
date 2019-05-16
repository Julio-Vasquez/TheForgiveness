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
        public ActionResult CreateStudent()
        {
            return View();
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
        public ActionResult GetStudents()
        {
            return View();
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
        public ActionResult SpecifyStudent()
        {
            return View();
        }

        #endregion
    }
}