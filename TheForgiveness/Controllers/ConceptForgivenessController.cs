using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class ConceptForgivenessController : Controller
    {
        private Services.ConceptoAutosServicios Authoressrv = new Services.ConceptoAutosServicios();
        // GET: ConceptForgiveness

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateConcept")]
        public ActionResult CreateConcept()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetConcepts")]
        public ActionResult GetConcepts()
        {
            return View(Authoressrv.listConceptAut());

        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateConcept")]
        public ActionResult UpdateConcept()
        {
            return View();
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
        public ActionResult SpecifyConcept()
        {
            return View();
        }
    }
}