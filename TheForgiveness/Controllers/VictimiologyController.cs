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
        [PermissionAttributes(File = "CreateVictimiology")]
        public PartialViewResult CreateVictimiology()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateVictimiology")]
        public ActionResult UpdateVictimiology(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteVictimiology")]
        public ActionResult DeleteVictimiology()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetVictimiologies")]
        public PartialViewResult GetVictimiology()
        {
            return PartialView(Victimiologysrv.listVictimiologies());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetVictimiology")]
        public ActionResult SpecifyGetVictimiologies()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateVictimiologies")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivities(Models.victimiologiaModel vm)
        {
            if (ModelState.IsValid)
            {
                if (Victimiologysrv.CreateVictimiologies(vm))
                    return RedirectToAction("getVictimiology");
                else
                    return View(vm);
            }
            return View();


        }
    }
}