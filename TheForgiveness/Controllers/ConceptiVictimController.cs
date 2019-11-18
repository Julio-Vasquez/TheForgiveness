using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;


namespace TheForgiveness.Controllers
{
    public class ConceptiVictimController : Controller
    {
        private Services.conceptoVictimaService ConceptVictimsrv = new Services.conceptoVictimaService();
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
            return PartialView(ConceptVictimsrv.listConcVic());
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
        public ActionResult CreateAuthors(Models.conceptoVictimaModel cvm)
        {
            if (ModelState.IsValid)
            {
                if (ConceptVictimsrv.CreateSubject(cvm, int.Parse(Session["idAccount"].ToString())))
                    return RedirectToAction("GetPerception");
                else
                    return View(cvm);
            }
            return View();


        }

    }
}