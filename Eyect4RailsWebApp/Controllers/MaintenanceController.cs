﻿using System;
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
        private MaintenanceLogic logic = new MaintenanceLogic();
        private IOLogic IOLogic = new IOLogic();

        // GET: Maintenance
        public ActionResult Index()
        {
            Employee employee = (Employee) Session["LoggedInEmployee"];

            List<Maintenance> maintenances = logic.GetByEmployeeId(employee.Id);

            return View(maintenances);
        }

        public ActionResult All()
        {
            List<Maintenance> maintenances = logic.GetAll();

            return View(maintenances);
        }

        public ActionResult Open()
        {
            List<Maintenance> maintenances = logic.GetAll(false);

            return View(maintenances);
        }

        public ActionResult Assign(int id)
        {
            return View(logic.Assign(id));
        }

        [HttpPost]
        public ActionResult Assign(int id, viewmodel_Maintenance viewmodel)
        {
            try
            {
                logic.Assign(id, viewmodel.SelectedId_Employee);
                
                return RedirectToAction("Open");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Details/5
        public ActionResult Details(int id)
        {
            return View(logic.GetById(id));
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            return View(logic.Create());
        }

        // POST: Maintenance/Create
        [HttpPost]
        public ActionResult Create(viewmodel_Maintenance viewmodel, FormCollection collection)
        {
            try
            {

                logic.Create(viewmodel.SelectedId_Tram, (int)viewmodel.Maintenance.Task, viewmodel.Maintenance.ScheduledDate);

                return RedirectToAction("Open");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Complete/5
        public ActionResult Complete(int id)
        {
            return View(logic.Edit(id));
        }

        // POST: Maintenance/Complete/5
        [HttpPost]
        public ActionResult Complete(int id, viewmodel_Maintenance viewmodel)
        {
            try
            {
                Maintenance maintenance = viewmodel.Maintenance;
                maintenance.Id = id;
                maintenance.Completed = true;

                logic.Complete(maintenance);

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
            return View(logic.Edit(id));
        }

        // POST: Maintenance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, viewmodel_Maintenance viewmodel)
        {
            try
            {
                Maintenance maintenance = viewmodel.Maintenance;

                // Maxvalue will be handled as null by the database layer
                if (maintenance.Completed == false)
                {
                    maintenance.AvailableDate = DateTime.MaxValue;
                }

                logic.Edit(id, viewmodel.SelectedId_Employee, viewmodel.SelectedId_Tram, (int)viewmodel.Maintenance.Task, viewmodel.Maintenance);

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
            var maintenance = logic.GetById(id);

            return View(maintenance);
        }

        // POST: Maintenance/Delete/5
        [HttpPost]
        public ActionResult Delete(Maintenance maintenance)
        {
            try
            {
                logic.Delete(maintenance.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return Index();
            }
        }
    }
}
