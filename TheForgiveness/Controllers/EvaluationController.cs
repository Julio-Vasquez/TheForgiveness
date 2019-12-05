using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class EvaluationController : Controller
    {
        private Services.evaluacionService Evaluacionsrv = new Services.evaluacionService();
        // GET: Activities
       

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetEvaluations")]
        public PartialViewResult GetEvaluations()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(Evaluacionsrv.listEvaluacion());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetEvaluations")]
        public ActionResult SpecifyEvaluations()
        {
            return View();
        }

    }
}
