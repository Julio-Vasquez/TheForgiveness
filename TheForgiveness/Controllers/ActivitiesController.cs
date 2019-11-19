
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
        [PermissionAttributes(File = "CreateActivity")]
        public PartialViewResult CreateActivity()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateActivity")]
        public ActionResult UpdateActivity(int? id)
        {
            return View();
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteActivity")]
        public ActionResult DeleteActivity()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetActivities")]
        public PartialViewResult GetActivities()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(Activisrv.listActivities());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetActivities")]
        public ActionResult SpecifyAtivities ()
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