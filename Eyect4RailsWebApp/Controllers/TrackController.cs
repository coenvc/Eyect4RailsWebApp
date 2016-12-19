using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Logic;

namespace Eyect4RailsWebApp.Controllers
{
    public class TrackController : Controller
    {
        private TrackLogic Logic = new TrackLogic();
        // GET: Track
        [HttpGet]
        public ActionResult Index()
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
        public ActionResult Edit(Track track)
        {
            Logic.Update(track.Id,track);
            return RedirectToAction("Details", new {id = track.Id});
        }


    }
}