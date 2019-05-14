using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class AuthorsController : Controller
    {
        private Util.Util util = new Util.Util();
        private Services.autoresService Authoressrv = new Services.autoresService();
        // GET: Profile
        [HttpGet]
        public ActionResult CreateAuthors()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
        }

        public ActionResult UpdateAuthors(int? id)
        {
            //if (util.testcontrol(Convert.ToString(Session["control"]))) {
            //    if (id != null) {
            //        var res = Authoressrv.where()
            //        return View(new Models.autoresModel(datos));
            //    }
            //    return RedirectToAction("GetAuthor");
            //}
           return RedirectToAction("Error404", "Shared");
        }

        public ActionResult DeleteAuthors()
        {
            return View();
        }
        public ActionResult GetAuthors()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View(Authoressrv.listAuthors());
            return RedirectToAction("Error404", "Shared");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuthors(Models.autoresModel am)
        {
            if (ModelState.IsValid)
            {
                if (Authoressrv.createAuthores(am))
                    return RedirectToAction("getAuthor");
                else
                    return View(am);
            }
            return View();
                

        }
    }
}