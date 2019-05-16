using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class AuthorsController : Controller
    {
        private Services.autoresService Authoressrv = new Services.autoresService();
        // GET: Profile
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateAuthors")]
        public ActionResult CreateAuthor()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateAuthors")]
        public ActionResult UpdateAuthor(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteAuthors")]
        public ActionResult DeleteAuthor()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        public ActionResult GetAuthors()
        {
            return View(Authoressrv.listAuthors());
        }

        [HttpGet]
        [StatesLogging]
        public ActionResult SpecifyAuthors()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateAuthors")]
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