
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class ActivitiesController : Controller
    {
        private Services.actividadesService Activisrv = new Services.actividadesService();
        // GET: Activities
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateAtivity")]
        public PartialViewResult CreateAtivity()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateAtivity")]
        public ActionResult UpdateAtivity(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteAtivity")]
        public ActionResult DeleteAtivity()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetActivities")]
        public PartialViewResult GetAtivity()
        {
            return PartialView(Activisrv.listActivities());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetActivities")]
        public ActionResult SpecifyGetAtivities ()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateActivities")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivities(Models.actividadesModel am)
        {
            if (ModelState.IsValid)
            {
                if (Activisrv.CreateActivities(am))
                    return RedirectToAction("getActivity");
                else
                    return View(am);
            }
            return View();


        }
    }
}