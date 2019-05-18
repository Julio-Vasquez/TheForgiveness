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
        private Services.tipoDocumentoService dps = new Services.tipoDocumentoService();

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
                Models.tipodocumentoModel dpm = new Models.tipodocumentoModel(int.Parse(res["ID"].ToString()), res["TipoDocumento"].ToString());
                return View(dpm);
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
        public ActionResult DeleteDocument()
        {
            return View();
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
                return View(new Models.tipodocumentoModel(int.Parse(res["ID"].ToString()), res["TipoDocumento"].ToString()));
            }
            return Redirect("GetDocuments");
        }

        #endregion


        #region HTTP METHOD POST 
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateDocument")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDocument(Models.tipodocumentoModel dpm)
        {
            if (ModelState.IsValid)
            {
                if (dps.CreateDocument(dpm))
                    return RedirectToAction("Index", "DashBoard");
            }
            return View(dpm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateDocument")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDocument(Models.tipodocumentoModel dpm, int id)
        {
            if (dps.UpdateDepartment(dpm))
                return RedirectToAction("Index", "DashBoard");
            return View(dpm);
        }
        #endregion

    }
}