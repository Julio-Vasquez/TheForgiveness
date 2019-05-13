using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class ConceptForgivenessController : Controller
    {
        private Util.Util util = new Util.Util();
        private Services.ConceptoAutosServicios Authoressrv = new Services.ConceptoAutosServicios();
        // GET: ConceptForgiveness
        public ActionResult CreateConcept()
        {
            return View();
        }
        public ActionResult GetConcept()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View(Authoressrv.listConceptAut());
            return RedirectToAction("Error404", "Shared");
        }
        public ActionResult UpdateConcept()
        {
            return View();
        }
        public ActionResult DeleteConcept()
        {
            return View();
        }
    }
}