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
        private Services.ConceptForgivenessService con = new Services.ConceptForgivenessService();
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
            return PartialView(con.listConceptAut());

        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateConcept")]
        public ActionResult UpdateConcept(int? id)
        {
            if (id != null) 
            {
                var dr = con.SpecifyData(id);
                var model = new Models.ConceptForgivenessModel(
                    dr["Publicacion"].ToString(),
                    dr["Titulo"].ToString(),
                    dr["Descripcion"].ToString()
                );
                ViewBag.autor = con.Authors();
                return View(model);
            }
            return RedirectToAction("GetConcepts");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteConcept")]
        public ActionResult DeleteConcept(int? id)
        {
            if (id != null)
            {
                var dr = con.SpecifyData(id);
                var model = new Models.ConceptForgivenessModel(
                    dr["Publicacion"].ToString(),
                    dr["Titulo"].ToString(),
                    dr["Descripcion"].ToString()
                );
                ViewBag.autor = dr["Autor"].ToString();
                return View(model);
            }
            return RedirectToAction("GetConcepts");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetConcepts")]
        public ActionResult SpecifyConcept(int? id)
        {
            //especifico este es el controller
            if (id != null) {
                ViewBag.rol = Session["Role"].ToString();
                var dr = con.SpecifyData(id);
                var model = new Models.ConceptForgivenessModel(
                    dr["Publicacion"].ToString(),
                    dr["Titulo"].ToString(),
                    dr["Descripcion"].ToString()
                    );
                ViewBag.autor = dr["Autor"].ToString();
                return View(model);
            }
            return RedirectToAction("GetConcepts");
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteConcept")]
        public ActionResult DeleteConcept(int id) 
        {
            if (con.DeleteConcepto(id)) 
            {
                return RedirectToAction("GetConcepts");
            }
            var dr = con.SpecifyData(id);
            var model = new Models.ConceptForgivenessModel(
                dr["Publicacion"].ToString(),
                dr["Titulo"].ToString(),
                dr["Descripcion"].ToString()
            );
            ViewBag.autor = dr["Autor"].ToString();
            return View(model);
        }


        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateConcept")]
        public ActionResult UpdateConcept(Models.ConceptForgivenessModel cfm)
        {
            if (con.UpdateConcept(cfm)) 
            {
                return RedirectToAction("GetConcepts");
            }
            ViewBag.autor = con.Authors();
            return View(cfm);
            
        }
    }
}