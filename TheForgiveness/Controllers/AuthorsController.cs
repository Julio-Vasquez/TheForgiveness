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
        private Services.AuthorService Authoressrv = new Services.AuthorService();
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
        [PermissionAttributes(File = "UpdateAuthor")]
        public ActionResult UpdateAuthor(int? id)
        {
            if (id != null)
            {
                var res = Authoressrv.Auth(id);
                return View(new Models.AuthorModel(
                    int.Parse(res["ID"].ToString()),
                    res["PriNombre"].ToString(),
                    res["SegNombre"].ToString(),
                    res["PriApellido"].ToString(),
                    res["SegApellido"].ToString()
               ));
            }
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteAuthor")]
        public ActionResult DeleteAuthor(int? id)
        {
            if (id != null)
            {
                var dr = Authoressrv.Auth(id);
                var model = new Models.AuthorModel(
                    dr["PriNombre"].ToString(),
                    dr["SegNombre"].ToString(),
                    dr["PriApellido"].ToString(),
                    dr["SegApellido"].ToString()
                    );
                return View(model);
            }
            return RedirectToAction("GetAuthors");
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
                var model = new Models.AuthorModel(
                    int.Parse(dr["ID"].ToString()),
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
        public ActionResult CreateAuthor(Models.AuthorModel am)
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

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateAuthor")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAuthor(Models.AuthorModel am)
        {
            if (ModelState.IsValid)
            {
                if (Authoressrv.UpdateAuth(am))
                    return RedirectToAction("GetAuthors");
                else
                    return View(am);
            }
            return View(am);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteAuthor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuthor(int id)
        {

            if (Authoressrv.DeleteAuthor(id))
            {
                return RedirectToAction("GetAuthors");
            }
            else
            {
                var dr = Authoressrv.Auth(id);
                var model = new Models.AuthorModel(
                dr["PriNombre"].ToString(),
                dr["SegNombre"].ToString(),
                dr["PriApellido"].ToString(),
                dr["SegApellido"].ToString()
                );
                return View(model);
            }
            
        }
    }
}