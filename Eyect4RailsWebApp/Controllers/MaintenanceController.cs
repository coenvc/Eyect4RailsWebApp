using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;
using Eyect4RailsWebApp.ViewModels;

namespace Eyect4RailsWebApp.Controllers
{
    public class MaintenanceController : Controller
    {
        private MaintenanceLogic MaintenanceLogic = new MaintenanceLogic(new MSSQLMaintenanceRepository());

        // GET: Maintenance
        public ActionResult Index()
        {
            var maintenances = MaintenanceLogic.GetAll();

            return View(maintenances);
        }

        public ActionResult Open()
        {
            var maintenances = MaintenanceLogic.GetAll(false);

            return View(maintenances);
        }

        public ActionResult Assign(int id)
        {
            // TODO: Get a list of possible employees from the logic

            EmployeeContext ec = new EmployeeContext(new MSSQLEmployeeRepository());

            var maintenance = MaintenanceLogic.GetById(id);
            var employees = ec.GetAll();

            var viewmodel = new AssignMaintenanceToEmployee(maintenance, employees);

            return View(viewmodel);
        }

        // GET: Maintenance/Details/5
        public ActionResult Details(int id)
        {
            var maintenance = MaintenanceLogic.GetById(id);

            return View(maintenance);
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintenance/Create
        [HttpPost]
        public ActionResult Create(Maintenance maintenance)
        {
            try
            {
                MaintenanceLogic.Insert(maintenance);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Edit/5
        public ActionResult Edit(int id)
        {
            var maintenance = MaintenanceLogic.GetById(id);

            if (maintenance.Id == null)
            {
                throw new HttpException(404, "Maintenance could not be found.");
            }
            
            return View(maintenance);
        }

        // POST: Maintenance/Edit/5
        [HttpPost]
        public ActionResult Edit(Maintenance maintenance)
        {
            try
            {
                MaintenanceLogic.Update(maintenance.Id, maintenance);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Delete/5
        public ActionResult Delete(int id)
        {
            var maintenance = MaintenanceLogic.GetById(id);

            return View(maintenance);
        }

        // POST: Maintenance/Delete/5
        [HttpPost]
        public ActionResult Delete(Maintenance maintenance)
        {
            try
            {
                MaintenanceLogic.Delete(maintenance.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
