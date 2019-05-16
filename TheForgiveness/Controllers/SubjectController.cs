using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class SubjectController : Controller
    {
        private Services.asignaturaService asigs = new Services.asignaturaService();

        // GET: Subject
        #region HTTPMETHOD GET

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSubject")]
        public ActionResult CreateSubject()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSubject")]
        public ActionResult UpdateSubject(int? id)
        {
            if (id != null)
            {
                var res = asigs.Subject(id);
                return View(new Models.asignaturaModel(int.Parse(res["ID"].ToString()), res["Nombre"].ToString()));
            }
            return Redirect("GetSubjects");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSubjects")]
        public ActionResult GetSubjects()
        {
            return View(asigs.listSubject());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteSubject")]
        public ActionResult DeleteSubject()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SpecifySubject(int? id)
        {
            if (id != null)
            {
                var res = asigs.Subject(id);
                return View(new Models.asignaturaModel(int.Parse(res["ID"].ToString()), res["Nombre"].ToString()));
            }
            return Redirect("GetSubjects");
        }
        #endregion

        #region HTTPMETHOD POST
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSubject")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubject(Models.asignaturaModel asig)
        {
            if (ModelState.IsValid)
                if (asigs.CreateSubject(asig))
                    return RedirectToAction("Index", "DashBoard");
            return View(asig);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSubject")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSubject(Models.asignaturaModel asign)
        {
            if (ModelState.IsValid)
                if (asigs.UpdateSubject(asign))
                    return RedirectToAction("Index", "DashBoard");
            return View(asign);
        }
        #endregion
    }
}