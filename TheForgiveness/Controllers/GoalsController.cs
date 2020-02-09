using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class GoalsController : Controller
    {
        private Services.GoalsService Goalssrv = new Services.GoalsService();
        // GET: Activities
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateGoal")]
        public PartialViewResult CreateGoal()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateGoal")]
        public ActionResult UpdateGoal(int? id)
        {
            return View();
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteGoal")]
        public ActionResult DeleteAtivity()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetGoals")]
        public PartialViewResult GetGoal()
        {
            return PartialView(Goalssrv.listgoals());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetGoals")]
        public ActionResult SpecifyGetGoals()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateGoals")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivities(Models.GoalsModel mm)
        {
            if (ModelState.IsValid)
            {
                if (Goalssrv.CreateGoals(mm))
                    return RedirectToAction("getGoal");
                else
                    return View(mm);
            }
            return View();


        }
    }
}