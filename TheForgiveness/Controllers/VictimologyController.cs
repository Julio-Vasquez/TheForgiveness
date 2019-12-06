using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class VictimologyController : Controller
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
            if (id != null)
            {
                ViewBag.rol = Session["Role"].ToString();
                return View(Victimiologysrv.specify(id));
            }
            return RedirectToAction("GetVictimologys");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteVictimology")]
        public ActionResult DeleteVictimology(int? id)
        {
            if (id != null)
            {
                var res = Victimiologysrv.specify(id);
                return View(res);
            }
            return RedirectToAction("GetVictimologys");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetVictimologys")]
        public PartialViewResult GetVictimologys()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(Victimiologysrv.listVictimiologies());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetVictimologys")]
        public ActionResult SpecifyVictimologys(int? id)
        {
            if (id != null)
            {
                ViewBag.rol = Session["Role"].ToString();
                return View(Victimiologysrv.specify(id));
            }
            return Redirect("GetVictimologys");
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateVictimology")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVictimology(Models.victimiologiaModel vm)
        {
            if (ModelState.IsValid)
            {
                if (Victimiologysrv.CreateVictimiologies(vm))
                    return RedirectToAction("GetVictimologys");
                else
                    return View(vm);
            }
            return View(vm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateVictimology")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateVictimology(Models.victimiologiaModel vm)
        {
            if (ModelState.IsValid)
            {
                if (Victimiologysrv.UpdateVictimiology(vm))
                    return RedirectToAction("GetVictimologys");
                else
                    return View(vm);
            }
            return View(vm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteVictimology")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVictimology(int id)
        {

            if (Victimiologysrv.DeleteVictimology(id))
            {
                return RedirectToAction("GetVictimologys");
            }
            else
            {
                ViewBag.rol = Session["Role"].ToString();
                return View(Victimiologysrv.specify(id));
            }

        }
    }
}