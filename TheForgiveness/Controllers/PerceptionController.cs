using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;


namespace TheForgiveness.Controllers
{
    public class PerceptionController : Controller
    {
        private Services.PerceptionService percepservice = new Services.PerceptionService();
        // GET: ConceptiVictim
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreatePerception")]
        public PartialViewResult CreatePerception()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdatePerception")]
        public ActionResult UpdatePerception(int? id)
        {
            if (id != null) 
            {
                var res = percepservice.ConVict(id);
                return View(new Models.PerceptionModel(
                    int.Parse(res["ID"].ToString()),
                    res["Descripcion"].ToString(),
                    int.Parse(res["Usuario"].ToString())
                    ));;
            }
            return RedirectToAction("GetPerception");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetPerception")]
        public PartialViewResult GetPerception()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(percepservice.listConcVic(Session["Role"].ToString(),int.Parse(Session["idAccount"].ToString())));
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetPerception")]
        public ActionResult SpecifyPerception(int? id)
        {
            if (id != null) 
            {
                ViewBag.rol = Session["Role"].ToString();
                var res = percepservice.ConVict(id);
                return View(new Models.PerceptionModel(
                    int.Parse(res["ID"].ToString()),
                    res["Descripcion"].ToString(),
                    int.Parse(res["Usuario"].ToString())
                    )); ;
            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreatePerception")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePerception(Models.PerceptionModel cvm)
        {
            if (ModelState.IsValid)
            {
                if (percepservice.CreateSubject(cvm, int.Parse(Session["idAccount"].ToString())))
                    return RedirectToAction("CreateForgiveness", "Forgiveness");
                else
                    return View(cvm);
            }
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdatePerception")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePerception(Models.PerceptionModel cvm) 
        {
            if (ModelState.IsValid) 
            {
                if (percepservice.UpdateConVict(cvm))
                {
                    return RedirectToAction("GetPerception");
                }
                else
                {
                    return View(cvm);
                }
            }
            return View(cvm);
        }
    }
}