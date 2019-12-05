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
        [PermissionAttributes(File = "CreateAuthor")]
        public PartialViewResult CreateAuthor()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        public ActionResult DetailAutor(int? id)
        {
            return View();
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateAuthor")]
        public ActionResult UpdateAuthor(int? id)
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteAuthor")]
        public ActionResult DeleteAuthor()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetAuthors")]
        public PartialViewResult GetAuthors()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(Authoressrv.listAuthors());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetAuthors")]
        public ActionResult SpecifyAuthor(int? id)
        {
            if (id != null)
            {
                var dr = Authoressrv.Auth(id);
                var model = new Models.autoresModel(
                    dr["PriNombre"].ToString(),
                    dr["SegNombre"].ToString(),
                    dr["PriApellido"].ToString(),
                    dr["SegApellido"].ToString()
                    );
                return View(model);
            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateAuthor")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuthor(Models.autoresModel am)
        {
            if (ModelState.IsValid)
            {
                if (Authoressrv.createAuthores(am))
                    return RedirectToAction("GetAuthors");
                else
                    return View(am);
            }
            return View();


        }
    }
}