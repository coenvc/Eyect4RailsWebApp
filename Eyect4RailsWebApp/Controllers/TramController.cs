using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Controllers
{
    public class TramController : Controller
    {
        // GET: Tram
        TramLogic logic = new TramLogic();

        public ActionResult Index()
        {
            List<Tram> trams = logic.GetAll();
            return View(trams);
        }

        // GET: Tram/Details/5
        public ActionResult Details(int id)
        {
            Tram tram = logic.GetById(id);
            return View(tram);
        }

        // GET: Tram/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tram/Create
        [HttpPost]
        public ActionResult Create(Tram tram)
        {
            try
            {
                logic.Insert(tram);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tram/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tram/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tram tram)
        {
            try
            {
                logic.Update(id, tram);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tram/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tram/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Tram tram)
        {
            try
            {
                logic.Delete(tram.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
