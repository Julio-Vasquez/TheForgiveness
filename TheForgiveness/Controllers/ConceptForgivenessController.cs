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
        private Services.ConceptForgivenessService Authoressrv = new Services.ConceptForgivenessService();
        // GET: ConceptForgiveness

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateConcept")]
        public PartialViewResult CreateConcept()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetConcepts")]
        public PartialViewResult GetConcepts()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(Authoressrv.listConceptAut());

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
        [PermissionAttributes(File = "GetConcepts")]
        public ActionResult SpecifyConcept(int? id)
        {
            //especifico este es el controller
            if (id != null) {
                ViewBag.rol = Session["Role"].ToString();
                var dr = Authoressrv.SpecifyData(id);
                var model = new Models.ConceptForgivenessModel(
                    dr["Publicacion"].ToString(),
                    dr["Titulo"].ToString(),
                    dr["Descripcion"].ToString()
                    );
                ViewBag.autor = dr["Autor"].ToString();
                return View(model);
            }
            return RedirectToAction("Error404", "Shared");
        }
    }
}