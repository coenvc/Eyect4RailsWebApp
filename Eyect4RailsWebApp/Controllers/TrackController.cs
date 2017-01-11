using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.ViewModels;

namespace Eyect4RailsWebApp.Controllers
{
    public class TrackController : Controller
    {
        private TrackLogic Logic = new TrackLogic();
        CreateEditTramViewModel CETVModel = new CreateEditTramViewModel();
        IOLogic logic = new IOLogic();


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
            CETVModel = logic.GetCETViewModel(1);
            return View(CETVModel);
        }

        // POST: Track/Create
        [HttpPost]
        public ActionResult Create(CreateEditTramViewModel CETVModel)
        {
            try
            {
                Logic.Insert(CETVModel.Track);

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
            CETVModel = logic.GetCETViewModel(1);
            CETVModel.Track = Logic.GetById(id);
            return View(CETVModel);
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
        public ActionResult Delete(int id, Track track)
        {
            return View(track);
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
