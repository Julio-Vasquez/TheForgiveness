using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class ForgivenessController : Controller
    {
        private Services.forgivenessServicios ConceptVictimsrv = new Services.forgivenessServicios();
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
            return View();
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
        [PermissionAttributes(File = "GetForgiveness")]
        public ActionResult GetForgiveness()
        {

            ViewBag.rol = Session["Role"].ToString();
            return PartialView(ConceptVictimsrv.listConcVic());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetForgiveness")]
        public ActionResult SpecifyForgivenees(int? id)
        {
            if (id != null)
            {
                var dr = ConceptVictimsrv.ConVict(id);
                var model = new Models.conceptoVictimaModel(
                    int.Parse(dr["ID"].ToString()),                   
                    dr["Descripcion"].ToString()

                    );
                return View(model);
            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateForgiveness")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForgiveness(Models.conceptoVictimaModel cvm)
        {
            if (ModelState.IsValid)
            {
                if (ConceptVictimsrv.CreateSubject(cvm, int.Parse(Session["idAccount"].ToString())))
                    return RedirectToAction("CreateExperience", "Experience");
                else
                    return View(cvm);
            }
            return View();


        }
    }
}