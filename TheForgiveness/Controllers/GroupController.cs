using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class GroupController : Controller
    {

        private Services.grupoService Groupssrv = new Services.grupoService();
        // GET: Profile
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateGroup")]
        public PartialViewResult CreateGroup()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateGroup")]
        public ActionResult UpdateGroup(int? id)
        {
            return View();
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteGroup")]
        public ActionResult DeleteGroup()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetGroup")]
        public PartialViewResult GetGroup()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(Groupssrv.listGrups());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetGroup")]
        public ActionResult SpecifyGroup()
        {

            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateGroup")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(Models.grupoModel gm)
        {
            if (ModelState.IsValid)
            {
                if (Groupssrv.CreateGrups(gm))
                    return RedirectToAction("GetGroup");
                else
                    return View(gm);
            }
            return View();


        }
    }
}