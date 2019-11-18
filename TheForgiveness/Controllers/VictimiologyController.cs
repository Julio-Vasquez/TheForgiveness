using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class VictimiologyController : Controller
    {
        private Services.victimiologiaSevice Victimiologysrv = new Services.victimiologiaSevice();
        // GET: Activities
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateVictimology")]
        public PartialViewResult CreateVictimology()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateVictimology")]
        public ActionResult UpdateVictimology(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteVictimology")]
        public ActionResult DeleteVictimology()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetVictimologys")]
        public PartialViewResult GetVictimologys()
        {
            return PartialView(Victimiologysrv.listVictimiologies());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetVictimologys")]
        public ActionResult SpecifyVictimologys()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateVictimology")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivities(Models.victimiologiaModel vm)
        {
            if (ModelState.IsValid)
            {
                if (Victimiologysrv.CreateVictimiologies(vm))
                    return RedirectToAction("GetVictimologys");
                else
                    return View(vm);
            }
            return View();


        }
    }
}