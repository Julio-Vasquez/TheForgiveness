using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class DepartmentController : Controller
    {
        private Services.departamentoService dps = new Services.departamentoService();

        #region HTTPMethod Get
        // GET: Department
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateDepartment")]
        public PartialViewResult CreateDepartment()
        {
            Models.departamentoModel dpm = new Models.departamentoModel();
            dpm.Pais = dps.Paises();
            return PartialView(dpm);
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateDepartment")]
        public ActionResult UpdateDepartment(int? id)
        {
            if (id != null)
            {
                var res = dps.Department(id);
                Models.departamentoModel dpm = new Models.departamentoModel(int.Parse(res["ID"].ToString()), res["Departamento"].ToString(), int.Parse(res["Pais"].ToString()));
                dpm.Pais = dps.Paises();
                return View(dpm);
            }
            return RedirectToAction("GetDepartments");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetDepartments")]
        public PartialViewResult GetDepartments()
        {
            return PartialView(dps.listDepartment());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteDepartment")]
        public ActionResult DeleteDepartment(int? id)
        {
            if (id != null) 
            {
                var res = dps.Department(id);
                return View(
                    new Models.departamentoModel(
                        int.Parse(res["ID"].ToString()),
                        res["Departamento"].ToString(),
                        int.Parse(res["Pais"].ToString())
                        )
                    );
            }
            return RedirectToAction("GetDepartments");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetDepartments")]
        public ActionResult SpecifyDepartment(int? id)
        {

            if (id != null)
            {
                var res = dps.Department(id);
                ViewBag.Pais = dps.Pais(int.Parse(res["Pais"].ToString()));
                return View(new Models.departamentoModel(int.Parse(res["ID"].ToString()), res["Departamento"].ToString(), int.Parse(res["Pais"].ToString())));
            }
            return RedirectToAction("GetDepartments");
        }

        #endregion


        #region HTTP METHOD POST 
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateDepartment")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(Models.departamentoModel dpm)
        {
            if (ModelState.IsValid)
            {
                if (dps.CreateDepartment(new Models.departamentoModel(dpm.Departamento, int.Parse(Request.Form["Pais"]))))
                    return RedirectToAction("GetDeparments", "Department");
            }
            return View(dpm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateDepartment")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDepartment(Models.departamentoModel dpm, int id)
        {
            dpm.PaisFK = int.Parse(Request.Form["Pais"].ToString());
            if (dps.UpdateDepartment(dpm))
                return Redirect("GetDepartments");
            return View(dpm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteDepartment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDepartment(int id)
        {
            if (dps.DeleteDepartment(id))
            {
                return Redirect("GetDepartments");
            }
            else 
            {
                var res = dps.Department(id);
                return View(
                    new Models.departamentoModel(
                        int.Parse(res["ID"].ToString()),
                        res["Departamento"].ToString(),
                        int.Parse(res["Pais"].ToString())
                        )
                    );
            }
        }
        #endregion
    }
}