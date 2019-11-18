using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class EvaluationController : Controller
    {
        private Services.evaluacionService Evaluacionsrv = new Services.evaluacionService();
        // GET: Activities
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateEvaluation")]
        public PartialViewResult CreateEvaluation()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateEvaluation")]
        public ActionResult UpdateEvaluation(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteEvaluation")]
        public ActionResult DeleteEvaluation()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetEvaluations")]
        public PartialViewResult GetEvaluation()
        {
            return PartialView(Evaluacionsrv.listEvaluacion());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetEvaluations")]
        public ActionResult SpecifyEvaluations()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateEvaluations")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivities(Models.evaluacionModel em)
        {
            if (ModelState.IsValid)
            {
                if (Evaluacionsrv.CreateActivities(em))
                    return RedirectToAction("getActivity");
                else
                    return View(em);
            }
            return View();


        }
    }
}
