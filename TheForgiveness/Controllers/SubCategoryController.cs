using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class SubCategoryController : Controller
    {
        private Services.subcategoriaService SubCategorysrv = new Services.subcategoriaService();
        // GET: Activities
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSubcategory")]
        public PartialViewResult CreateSubcategory()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSubcategory")]
        public ActionResult UpdateSubcategory(int? id)
        {
            return View();
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteSubcategory")]
        public ActionResult DeleteSubcategory()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSubcategory")]
        public PartialViewResult GetSubcategory()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(SubCategorysrv.listSubCategories());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSubcategory")]
        public ActionResult SpecifySubcategory()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSubcategory")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivities(Models.subcategoiaModel am)
        {
            if (ModelState.IsValid)
            {
                if (SubCategorysrv.CreateSubCategories(am))
                    return RedirectToAction("GetSubcategory");
                else
                    return View(am);
            }
            return View();


        }
    }
}