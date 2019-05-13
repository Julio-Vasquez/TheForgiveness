using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class DocumentController : Controller
    {
        private Util.Util util = new Util.Util();
        private Services.tipoDocumentoService dps = new Services.tipoDocumentoService();

        #region HTTPMethod Get
        // GET: document
        [HttpGet]
        public ActionResult CreateDocument()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }


        [HttpGet]
        public ActionResult UpdateDocument(int? id)
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                if (id != null)
                {
                    var res = dps.Documents(id);
                    Models.tipodocumentoModel dpm = new Models.tipodocumentoModel(int.Parse(res["ID"].ToString()), res["TipoDocumento"].ToString());
                    return View(dpm);
                }
                return RedirectToAction("GetDocuments");
            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult GetDocuments()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View(dps.listDocument());
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult DeleteDocument()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View();
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        public ActionResult SpecifyDocument(int? id)
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                if (id != null)
                {
                    var res = dps.Documents(id);
                    return View(new Models.tipodocumentoModel(int.Parse(res["ID"].ToString()), res["TipoDocumento"].ToString()));
                }
                return RedirectToAction("GetDocuments");
            }
            return RedirectToAction("Error404", "Shared");
        }

        #endregion


        #region HTTP METHOD POST 
        [HttpPost]
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