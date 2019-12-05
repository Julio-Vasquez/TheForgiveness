using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;
using Newtonsoft.Json;

namespace TheForgiveness.Controllers
{
    public class GroupController : Controller
    {

        private Services.grupoService Groupssrv = new Services.grupoService();
        private Services.asignaturaService signaturessrv = new Services.asignaturaService();
        private Services.perfilServices docentsrv = new Services.perfilServices();
        private Services.colegioService colsrv = new Services.colegioService();

        // GET: Profile
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateGroup")]
        public PartialViewResult CreateGroup()
        {
            ViewData["docentes"] = JsonConvert.SerializeObject(docentsrv.queryDocentes());
            ViewData["asignaturas"] = JsonConvert.SerializeObject(signaturessrv.listSubject());
            ViewData["colegios"] = JsonConvert.SerializeObject(colsrv.listSchools());
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
            ViewBag.rol = Session["Role"].ToString();
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateGroup")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(Models.grupoModel gm)
        {
            ViewData["docentes"] = JsonConvert.SerializeObject(docentsrv.queryDocentes());
            ViewData["asignaturas"] = JsonConvert.SerializeObject(signaturessrv.listSubject());
            ViewData["colegios"] = JsonConvert.SerializeObject(colsrv.listSchools());
            
                if (Groupssrv.CreateGrups(gm))
                    return RedirectToAction("GetGroup");
                else
                    return View(gm);
            
            return View();


        }
    }
}