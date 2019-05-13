using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class SubjectController : Controller
    {
        private Util.Util util = new Util.Util();
        private Services.asignaturaService asigs = new Services.asignaturaService();

        // GET: Subject
        #region HTTPMETHOD GET
        [HttpGet]
        public ActionResult CreateSubject()
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
        public ActionResult UpdateSubject(int id)
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                var res = asigs.Subject(id);
                return View(new Models.asignaturaModel(int.Parse(res["ID"].ToString()), res["Nombre"].ToString()));
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
        }

        [HttpGet]
        public ActionResult GetSubjects()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                return View(asigs.listSubject());
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
        }

        [HttpGet]
        public ActionResult DeleteSubject()
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
        public ActionResult SpecifySubject(int? id)
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                if (id != null)
                {
                    var res = asigs.Subject(id);
                    return View(new Models.asignaturaModel(int.Parse(res["ID"].ToString()), res["Nombre"].ToString()));
                }
                else
                {
                    return RedirectToAction("GetSubjects");
                }   
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
        }
        #endregion

        #region HTTPMETHOD POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubject(Models.asignaturaModel asig)
        {
            if (ModelState.IsValid)
                if (asigs.CreateSubject(asig))
                    return RedirectToAction("Index", "DashBoard");
            return View(asig);
        }

        [HttpPost]
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