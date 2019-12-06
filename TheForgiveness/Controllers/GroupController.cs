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
        private Services.grupopersonaService gruoppersrv = new Services.grupopersonaService();

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

            if (id != null)
            {
                System.Data.DataRow dr = Groupssrv.Groups(id);
                ViewData["iddocentes"] = dr["Docente"].ToString();
                ViewData["idasignaturas"] = dr["Asignatura"].ToString();
                ViewData["idcolegios"] = dr["Colegio"].ToString();
                ViewData["docentes"] = JsonConvert.SerializeObject(docentsrv.queryDocentes());
                ViewData["asignaturas"] = JsonConvert.SerializeObject(signaturessrv.listSubject());
                ViewData["colegios"] = JsonConvert.SerializeObject(colsrv.listSchools());
                Models.grupoModel gr = new Models.grupoModel(int.Parse(dr["ID"].ToString()), int.Parse(dr["Codigo"].ToString()), dr["Nombre"].ToString(), int.Parse(dr["AñoEscolar"].ToString()), int.Parse(dr["Docente"].ToString()), int.Parse(dr["Asignatura"].ToString()), int.Parse(dr["Colegio"].ToString()));
                return View(gr);
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
            
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
            return PartialView(Groupssrv.listGrups(int.Parse(Session["idAccount"].ToString())));
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetGroup")]
        public ActionResult SpecifyGroup(int id)
        {
            ViewBag.rol = Session["Role"].ToString();
            ViewBag.personas= gruoppersrv.querygrupopersona(id);
            System.Data.DataRow dr = Groupssrv.specifygrups(id);
            gupoextendido gr = new gupoextendido(int.Parse(dr["ID"].ToString()), int.Parse(dr["Codigo"].ToString()), dr["Nombre"].ToString(), int.Parse(dr["AñoEscolar"].ToString()), dr["Docente"].ToString(), dr["Asignatura"].ToString(),dr["Colegio"].ToString());
            return View(gr);
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