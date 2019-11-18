using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class ConceptController : Controller
    {
        private Services.conceptoServicios Conceptsrv = new Services.conceptoServicios();
        // GET: Concept
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateConcept")]
        public PartialViewResult CreateConcept()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateConcept")]
        public ActionResult UpdateConcept(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteConcept")]
        public ActionResult DeleteConcept()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetConcepts")]
        public ActionResult GetConcepts()
        {
            
           
            return View(Conceptsrv.listConc());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetConcepts")]
        public ActionResult SpecifyConcepts()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateConcepts")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuthors(Models.conceptoModel cm)
        {
            if (ModelState.IsValid)
            {
                if (Conceptsrv.CreateConcept(cm))
                    return RedirectToAction("getConcept");
                else
                    return View(cm);
            }
            return View();


        }
    }
}