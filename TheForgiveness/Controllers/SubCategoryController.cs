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
        [PermissionAttributes(File = "CreateSubCategory")]
        public PartialViewResult CreateSubCategory()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSubCategory")]
        public ActionResult UpdateSubCategory(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteSubCategory")]
        public ActionResult DeleteSubCategory()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSubCategories")]
        public PartialViewResult GetSubCategory()
        {
            return PartialView(SubCategorysrv.listSubCategories());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSubCategories")]
        public ActionResult SpecifySubCategories()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSubCategories")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivities(Models.subcategoiaModel am)
        {
            if (ModelState.IsValid)
            {
                if (SubCategorysrv.CreateSubCategories(am))
                    return RedirectToAction("getSubCategory");
                else
                    return View(am);
            }
            return View();


        }
    }
}