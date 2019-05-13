using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class DepartmentController : Controller
    {
        private Util.Util util = new Util.Util();
        private Services.departamentoService dps = new Services.departamentoService();

        #region HTTPMethod Get
        // GET: Department
        [HttpGet]
        public ActionResult CreateDepartment()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                Models.departamentoModel dpm = new Models.departamentoModel();
                dpm.Pais = dps.Paises();
                return View(dpm);
            }
            return RedirectToAction("Error404", "Shared");
        }


        [HttpGet]
        public ActionResult UpdateDepartment(int? id)
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                if (id != null)
                {
                    var res = dps.Department(id);
                    Models.departamentoModel dpm = new Models.departamentoModel(int.Parse(res["ID"].ToString()), res["Departamento"].ToString(), int.Parse(res["Pais"].ToString()));
                    dpm.Pais = dps.Paises();
                    return View(dpm);
                }
                return RedirectToAction("GetDeparments");
            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult GetDepartments()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View(dps.listDepartment());
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult DeleteDepartment()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult SpecifyDepartment(int? id)
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                if (id != null)
                {
                    var res = dps.Department(id);
                    ViewBag.Pais = dps.Pais(int.Parse(res["Pais"].ToString()));
                    return View(new Models.departamentoModel(int.Parse(res["ID"].ToString()), res["Departamento"].ToString(), int.Parse(res["Pais"].ToString())));
                }
                return RedirectToAction("GetDepartments");
            }
            return RedirectToAction("Error404", "Shared");
        }

        #endregion


        #region HTTP METHOD POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(Models.departamentoModel dpm)
        {
            if (ModelState.IsValid)
            {
                if (dps.CreateDepartment(new Models.departamentoModel(dpm.Departamento, int.Parse(Request.Form["Pais"]))))
                    return RedirectToAction("Index", "DashBoard");
            }
            return View(dpm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDepartment(Models.departamentoModel dpm, int id)
        {
            dpm.PaisFK = int.Parse(Request.Form["Pais"].ToString());
            if (dps.UpdateDepartment(dpm))
                return RedirectToAction("Index", "DashBoard");
            return View(dpm);
        }
        #endregion
    }
}