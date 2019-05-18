using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class MunicipalityController : Controller
    {
        private Services.municipioService dps = new Services.municipioService();

        #region HTTPMethod Get
        // GET: Municipality
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateMunicipality")]
        public PartialViewResult CreateMunicipality()
        {
            Models.municipioModel dpm = new Models.municipioModel();
            dpm.Departamento = dps.Deparmentos();
            return PartialView(dpm);
        }


        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateMunicipality")]
        public ActionResult UpdateMunicipality(int? id)
        {
            if (id != null)
            {
                var res = dps.Municipality(id);
                Models.municipioModel dpm = new Models.municipioModel(int.Parse(res["ID"].ToString()), res["Municipio"].ToString(), int.Parse(res["Departamento"].ToString()));
                dpm.Departamento = dps.Deparmentos();
                return View(dpm);
            }
            return Redirect("GetMunicipalities");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetMunicipalities")]
        public PartialViewResult GetMunicipalities()
        {
            Services.departamentoService ss = new Services.departamentoService();
            ViewBag.Departamentos = ss.queryDepartamento();
            return PartialView(dps.listMunicipality());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteMunicipality")]
        public ActionResult DeleteMunicipality()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetMunicipalities")]
        public ActionResult SpecifyMunicipality(int? id)
        {
            if (id != null)
            {
                var res = dps.Municipality(id);
                ViewBag.Departamento = dps.Departamento(int.Parse(res["Departamento"].ToString()));
                return View(new Models.municipioModel(int.Parse(res["ID"].ToString()), res["Municipio"].ToString(), int.Parse(res["Departamento"].ToString())));
            }
            return Redirect("GetMunicipalities");
        }

        #endregion


        #region HTTP METHOD POST 
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateMunicipality")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMunicipality(Models.municipioModel dpm)
        {
            if (ModelState.IsValid)
            {
                if (dps.CreateMunicipality(new Models.municipioModel(dpm.Municipio, int.Parse(Request.Form["Departamento"]))))
                    return RedirectToAction("Index", "DashBoard");
            }
            return View(dpm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateMunicipality")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMunicipality(Models.municipioModel dpm, int id)
        {
            dpm.DepartamentoFK = int.Parse(Request.Form["Departamento"].ToString());
            if (dps.UpdateDepartment(dpm))
                return RedirectToAction("Index", "DashBoard");
            return View(dpm);
        }
        #endregion
    }
}