using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class MunicipalityController : Controller
    {
        private Util.Util util = new Util.Util();
        private Services.municipioService dps = new Services.municipioService();

        #region HTTPMethod Get
        // GET: Municipality
        [HttpGet]
        public ActionResult CreateMunicipality()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                Models.municipioModel dpm = new Models.municipioModel();
                dpm.Departamento = dps.Deparmentos();
                return View(dpm);
            }
            return RedirectToAction("Error404", "Shared");
        }


        [HttpGet]
        public ActionResult UpdateMunicipality(int? id)
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                if (id != null)
                {
                    var res = dps.Municipality(id);
                    Models.municipioModel dpm = new Models.municipioModel(int.Parse(res["ID"].ToString()), res["Municipio"].ToString(), int.Parse(res["Departamento"].ToString()));
                    dpm.Departamento = dps.Deparmentos();
                    return View(dpm);
                }
                return RedirectToAction("GetMunicipalities");
            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult GetMunicipalities()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                Services.departamentoService ss = new Services.departamentoService();
                ViewBag.Departamentos = ss.queryDepartamento();
                return View(dps.listMunicipality());
            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult DeleteMunicipality()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult SpecifyMunicipality(int? id)
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                if (id != null)
                {
                    var res = dps.Municipality(id);
                    ViewBag.Departamento = dps.Departamento(int.Parse(res["Departamento"].ToString()));
                    return View(new Models.municipioModel(int.Parse(res["ID"].ToString()), res["Municipio"].ToString(), int.Parse(res["Departamento"].ToString())));
                }
                return RedirectToAction("GetMunicipalities");
            }
            return RedirectToAction("Error404", "Shared");
        }

        #endregion


        #region HTTP METHOD POST 
        [HttpPost]
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