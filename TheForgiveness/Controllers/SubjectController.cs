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
        private Services.SubjectService asigs = new Services.SubjectService();

        // GET: Subject
        #region HTTPMETHOD GET

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSubject")]
        public PartialViewResult CreateSubject()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSubject")]
        public ActionResult UpdateSubject(int? id)
        {
            if (id != null)
            {
                var res = asigs.Subject(id);
                return View(new Models.SubjectModel(int.Parse(res["ID"].ToString()), res["Nombre"].ToString()));
            }
            return Redirect("GetSubjects");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSubjects")]
        public PartialViewResult GetSubjects()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(asigs.listSubject());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteSubject")]
        public ActionResult DeleteSubject(int? id)
        {
            if (id != null) 
            {
                ViewBag.rol = Session["Role"].ToString();
                var res = asigs.Subject(id);
                return View(
                        new Models.SubjectModel(
                            int.Parse(res["ID"].ToString()),
                            res["Nombre"].ToString()
                            )
                    );
            }
            return RedirectToAction("DeleteSubject");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSubjects")]
        public ActionResult SpecifySubject(int? id)
        {
            if (id != null)
            {
                ViewBag.rol = Session["Role"].ToString();
                var res = asigs.Subject(id);
                return View(new Models.SubjectModel(int.Parse(res["ID"].ToString()), res["Nombre"].ToString()));
            }
            return RedirectToAction("GetSubjects");
        }
        #endregion

        #region HTTPMETHOD POST
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSubject")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubject(Models.SubjectModel asig)
        {
            if (ModelState.IsValid)
            {
                if (asigs.CreateSubject(asig))
                    return RedirectToAction("GetSubjects");
                else
                    return View(asig);
            }
            return View(asig);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSubject")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSubject(Models.SubjectModel asign)
        {
            if (ModelState.IsValid)
                if (asigs.UpdateSubject(asign))
                    return RedirectToAction("GetSubjects");
            return View(asign);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteSubject")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubject(int id)
        {

            if (asigs.DeleteSubject(id))
            {
                return RedirectToAction("GetSubjects");
            }
            else 
            {
                var res = asigs.Subject(id);
                return View(
                        new Models.SubjectModel(
                            int.Parse(res["ID"].ToString()),
                            res["Nombre"].ToString()
                            )
                    );
            }
    
        }
        #endregion
    }
}