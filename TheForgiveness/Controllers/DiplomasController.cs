using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class DiplomasController : Controller
    {
        // GET: Diplomas
        public ActionResult GetDiplomas()
        {
            Services.DiplomaService ds = new Services.DiplomaService();
            
            ViewBag.Data = ds.GetDiploma(int.Parse(Session["idAccount"].ToString()));
            //need nombreEstudiante, tipoDOc, numeroDoc
            return View();
        }
    }
}