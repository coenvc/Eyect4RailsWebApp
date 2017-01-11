using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.ViewModels;

namespace Eyect4RailsWebApp.Controllers
{
    public class SectorController : Controller
    {
        // GET: Sector
       SectorLogic logic = new SectorLogic();
        IOLogic Logic = new IOLogic();
        CreateEditTramViewModel CETVM = new CreateEditTramViewModel();

        public ActionResult Index()
        {
            List<Sector> sectors = logic.GetAll();
            return View(sectors);
        }

        // GET: Sector/Details/5
        public ActionResult Details(int id)
        {
            Sector sector = logic.GetById(id);
            return View(sector);
        }

        // GET: Sector/Create
        public ActionResult Create()
        {
            CETVM = Logic.GetCETViewModel(1);
            return View(CETVM);
        }

        // POST: Sector/Create
        [HttpPost]
        public ActionResult Create(CreateEditTramViewModel CETVM)
        {
            try
            {
                CETVM.Sector.TrackId = CETVM.Track.Id;
                logic.Insert(CETVM.Sector);

                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // GET: Sector/Edit/5
        public ActionResult Edit(int id)
        {
            CETVM = Logic.GetCETViewModel(1);
            CETVM.Sector = logic.GetById(id);
            return View(CETVM);
        }

        // POST: Sector/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreateEditTramViewModel CETVM)
        {
            try
            {
                CETVM.Sector.TrackId = CETVM.Track.Id;
                CETVM.Sector.TramId = CETVM.Tram.Id;
                logic.Update(id, CETVM.Sector);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sector/Delete/5
        public ActionResult Delete(int id)
        {
            return View(logic.GetById(id));
        }

        // POST: Sector/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Sector sector)
        {
            try
            {
                logic.Delete(sector.Id);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
