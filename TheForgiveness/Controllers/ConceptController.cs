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
        [PermissionAttributes(File = "CreateForgiveness")]
        public PartialViewResult CreateForgiveness()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateForgiveness")]
        public ActionResult UpdateForgiveness(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteForgiveness")]
        public ActionResult DeleteForgiveness()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetForgivenees")]
        public ActionResult GetForgivenees()
        {
            
           
            return View(Conceptsrv.listConc());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetForgivenees")]
        public ActionResult SpecifyForgivenees()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateForgiveness")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForgiveness(Models.conceptoModel cm)
        {
            if (ModelState.IsValid)
            {
                if (Conceptsrv.CreateConcept(cm))
                    return RedirectToAction("GetForgivenees");
                else
                    return View(cm);
            }
            return View();


        }
    }
}