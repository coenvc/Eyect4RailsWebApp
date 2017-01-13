using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.ViewModels;
using Microsoft.Ajax.Utilities;

namespace Eyect4RailsWebApp.Controllers
{
    public class TramController : Controller
    {
        // GET: Tram
        IOLogic logic = new IOLogic();
        CreateEditTramViewModel CETVM = new CreateEditTramViewModel();

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
            CETVM = logic.GetCETViewModel(1);
            return View(CETVM);
        }

        // POST: Tram/Create
        [HttpPost]
        public ActionResult Create(CreateEditTramViewModel CETVM)
        {
            try
            {
                CETVM.Tram.RemiseId = CETVM.Remise.Id;
                logic.Insert(CETVM.Tram);

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
           CETVM = logic.GetCETViewModel(1);
            CETVM.Tram = logic.GetById(id);
            return View(CETVM);
        }

        // POST: Tram/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult Edit(int id, CreateEditTramViewModel CETVM)
        {
          
            
            try
            {
                CETVM.Tram.RemiseId = CETVM.Remise.Id;
                logic.Update(CETVM.Tram.Id, CETVM.Tram);

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
            return View(logic.GetById(id));
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

        [HttpGet]
        public ActionResult Park()
        {
            return View(logic.GetAll());
        }

        [HttpPost]
        public ActionResult Park(FormCollection collection)
        {
            int test = Convert.ToInt32(collection["tramvalues"]);
            bool dirty = Convert.ToBoolean(Convert.ToInt32(collection["dirty"]));
            bool defective = Convert.ToBoolean(Convert.ToInt32(collection["defective"]));
            Tram t= logic.GetAll().FirstOrDefault(x=> x.TramNumber == test);
            t.Defective = defective;
            t.Filthy = dirty;

            return Redirect("/Track/Details/" + logic.AssignTramToSector(t.Id));
      //      return RedirectToAction ("Details", "Track", logic.AssignTramToSector(t.Id)); 
        } 

       
    }
}
