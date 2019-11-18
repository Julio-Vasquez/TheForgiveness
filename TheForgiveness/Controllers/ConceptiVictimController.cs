﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;


namespace TheForgiveness.Controllers
{
    public class ConceptiVictimController : Controller
    {
        private Services.conceptoVictimaService ConceptVictimsrv = new Services.conceptoVictimaService();
        // GET: ConceptiVictim
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateConceptVictim")]
        public PartialViewResult CreateConceptVictim()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateConceptVictim")]
        public ActionResult UpdateConceptVictim(int? victimiologia, int? persona)
        {
            if (victimiologia == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteConceptVictim")]
        public ActionResult DeleteConceptVictim()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetConceptVictims")]
        public PartialViewResult GetConceptVictims()
        {
            return PartialView(ConceptVictimsrv.listConcVic());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetConceptVictims")]
        public ActionResult SpecifyConceptVictims()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateConceptVictims")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuthors(Models.conceptoVictimaModel cvm)
        {
            if (ModelState.IsValid)
            {
                if (ConceptVictimsrv.CreateSubject(cvm, int.Parse(Session["idAccount"].ToString())))
                    return RedirectToAction("getConceptVictim");
                else
                    return View(cvm);
            }
            return View();


        }

    }
}