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
        public ActionResult Index()
        {
            return View(Logic.GetAll());
        }

        // GET: Track/Details/5
        public ActionResult Details(int id)
        {
            return View(Logic.GetById(id));
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        [HttpPost]
        public ActionResult Create(Track track)
        {
            try
            {
                Logic.Insert(track);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Logic.GetById(id));
        }

        // POST: Track/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Track track)
        {
            try
            {
                Logic.Update(id, track);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Logic.GetById(id));
        }

        // POST: Track/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Logic.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
