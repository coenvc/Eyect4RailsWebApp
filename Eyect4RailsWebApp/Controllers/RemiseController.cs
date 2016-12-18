using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;

namespace Eyect4RailsWebApp.Controllers
{
    public class RemiseController : Controller
    {
        private RemiseLogic RemiseLogic = new RemiseLogic(new MSSQLRemiseRepository());
        
        // GET: Remise
        public ActionResult Index()
        {
            List<Remise> remises = RemiseLogic.GetAll();

            return View(remises);
        }

        // GET: Remise/Details/5
        public ActionResult Details(int id)
        {
            Remise remise = RemiseLogic.GetById(id);

            if (remise.Name == null)
            {
                throw new HttpException(404, "Remise could not be found");
            }

            return View(remise);
        }

        // GET: Remise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Remise/Create
        [HttpPost]
        public ActionResult Create(Remise remise)
        {
            try
            {
                RemiseLogic.Insert(remise);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Remise/Edit/5
        public ActionResult Edit(int id)
        {
            Remise remise = RemiseLogic.GetById(id);

            if (remise.Name == null)
            {
                throw new HttpException(404, "Film could not be found.");
            }

            return View(remise);
        }

        // POST: Remise/Edit/5
        [HttpPost]
        public ActionResult Edit(Remise remise)
        {
            try
            {
                RemiseLogic.Update(remise.Id, remise);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Remise/Delete/5
        public ActionResult Delete(int id)
        {
            Remise remise = RemiseLogic.GetById(id);

            if (remise.Name == null)
            {
                throw new HttpException(404, "Film could not be found.");
            }

            return View(remise);
        }

        // POST: Remise/Delete/5
        [HttpPost]
        public ActionResult Delete(Remise remise)
        {
            try
            {
                RemiseLogic.Delete(remise.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
