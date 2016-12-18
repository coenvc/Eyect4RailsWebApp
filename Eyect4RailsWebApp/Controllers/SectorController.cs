using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Controllers
{
    public class SectorController : Controller
    {
        // GET: Sector
       SectorLogic logic = new SectorLogic();
        
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
            return View();
        }

        // POST: Sector/Create
        [HttpPost]
        public ActionResult Create(Sector sector)
        {
            try
            {
                logic.Insert(sector);

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
            return View();
        }

        // POST: Sector/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Sector sector)
        {
            try
            {
                logic.Update(id, sector);

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
            return View();
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
