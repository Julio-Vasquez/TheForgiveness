using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class StageController : Controller
    {
        // GET: Stage
        public ActionResult GetStages()
        {
            return View();
        }
    }
}