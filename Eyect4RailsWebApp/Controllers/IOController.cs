using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Controllers
{
    public class IOController : Controller
    {
        // GET: IO
        private IOLogic Logic = new IOLogic(); 
        [HttpGet]
        public ActionResult List()
        {
            return View(Logic.GetAll());
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(Logic.GetById(id));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Logic.GetById(id)); 
        }

        [HttpPost] 
        public ActionResult Edit(Tram tram)
        {
            Logic.Update(tram.Id, tram);

            return View(Logic.GetById(tram.Id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(Logic.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Tram tram)
        {
            Logic.Delete(id);

            return View(tram); 
        }

        [HttpPost]
        public ActionResult GetTramLocation(int id)
        {
            return PartialView("_Tram");
        }
    }
}