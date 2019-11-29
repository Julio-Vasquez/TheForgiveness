using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;


namespace TheForgiveness.Controllers
{
    public class PerceptionController : Controller
    {
        private Services.percepcionService percepservice = new Services.percepcionService();
        // GET: ConceptiVictim
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreatePerception")]
        public PartialViewResult CreatePerception()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdatePerception")]
        public ActionResult UpdatePerception(int? victimiologia, int? persona)
        {
            return View();
            if (victimiologia == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeletePerception")]
        public ActionResult DeletePerception()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetPerception")]
        public PartialViewResult GetPerception()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(percepservice.listConcVic());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetPerception")]
        public ActionResult SpecifyPerception()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreatePerception")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuthors(Models.percepcionPostconfictoModel cvm)
        {
            if (ModelState.IsValid)
            {
                if (percepservice.CreateSubject(cvm, int.Parse(Session["idAccount"].ToString())))
                    return RedirectToAction("CreateForgiveness", "Forgiveness");
                else
                    return View(cvm);
            }
            return View();


        }

    }
}