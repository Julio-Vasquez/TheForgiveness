using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class DocumentController : Controller
    {
        private Services.TypeDocService dps = new Services.TypeDocService();
        #region HTTPMethod Get
        // GET: document
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateDocument")]
        public PartialViewResult CreateDocument()
        {
            return PartialView();
        }


        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateDocument")]
        public ActionResult UpdateDocument(int? id)
        {
            if (id != null)
            {
                var res = dps.Documents(id);
                return View(new Models.TypeDocModel(int.Parse(res["ID"].ToString()), res["TipoDocumento"].ToString()));
            }
            return Redirect("GetDocuments");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetDocuments")]
        public ActionResult GetDocuments()
        {
            return PartialView(dps.listDocument());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteDocument")]
        public ActionResult DeleteDocument(int? id)
        {
            if (id != null) 
            {
                var res = dps.Documents(id);
                return View(new Models.TypeDocModel(int.Parse(res["ID"].ToString()), res["TipoDocumento"].ToString()));
            }
            return RedirectToAction("GetDocuments");
        }

        [HttpGet]
        [StatesLogging]
        /*SI puede entrar al ver, teoricamente puede ver detalladamente*/
        [PermissionAttributes(File = "GetDocuments")]
        public ActionResult SpecifyDocument(int? id)
        {
            if (id != null)
            {
                var res = dps.Documents(id);
                return View(new Models.TypeDocModel(int.Parse(res["ID"].ToString()), res["TipoDocumento"].ToString()));
            }
            return RedirectToAction("GetDocuments");
        }

        #endregion


        #region HTTP METHOD POST 
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateDocument")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDocument(Models.TypeDocModel dpm)
        {
            if (ModelState.IsValid)
            {
                if (dps.CreateDocument(dpm))
                    return RedirectToAction("GetDocuments");
            }
            return View(dpm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateDocument")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDocument(Models.TypeDocModel dpm, int id)
        {
            if (ModelState.IsValid) 
            {
                if (dps.UpdateDocument(dpm))
                    return RedirectToAction("GetDocuments");
            }
            
            return View(dpm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateDocument")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDocument(int id)
        {
            if (dps.DeleteDocument(id)) 
            {
                return RedirectToAction("GetDocuments");
            }
            var res = dps.Documents(id);
            return View(new Models.TypeDocModel(int.Parse(res["ID"].ToString()), res["TipoDocumento"].ToString()));

        }
        #endregion

    }
}