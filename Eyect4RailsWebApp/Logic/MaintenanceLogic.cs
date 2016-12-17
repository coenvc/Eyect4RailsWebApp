using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.IRepository;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;
using Eyect4RailsWebApp.ViewModels;

namespace Eyect4RailsWebApp.Logic
{
    public class MaintenanceLogic : IMaintenanceRepository
    {
        private MaintenanceContext maintenanceContext = new MaintenanceContext(new MSSQLMaintenanceRepository());
        private TramContext tramContext = new TramContext(new MSSQLTramRepository());
        private EmployeeContext employeeContext = new EmployeeContext(new MSSQLEmployeeRepository());
        
        public CreateMaintenance CreateMaintenance()
        {
            List<Employee> employees = employeeContext.GetAll();
            List<Tram> trams = tramContext.GetAll();
            var tasks = new Dictionary<int, string>
            {
                {0, "Grote Schoonmaak" },
                {1, "Kleine Schoonmaak" },
                {2, "Grote Reparatie" },
                {3, "Kleine Reparatie"}
            };

            return new CreateMaintenance(employees, trams, tasks);
        }

        public void InsertNewTask(int employeeId, int tramId, int taskId, DateTime scheduled)
        {
            Employee employee = employeeContext.GetById(employeeId);
            Tram tram = tramContext.GetById(tramId);

            Maintenance maintenance = new Maintenance(employee, tram, scheduled, DateTime.MaxValue, false, (Tasks)taskId);

            Insert(maintenance);
            // Employee employee, Tram tram, DateTime scheduledDate, DateTime availableDate, bool completed, Tasks task
            //Medewerker_ID, Tram_ID, DatumTijdstip, BeschikbaarDatum, Taak_ID, Voltooid
        }

        public bool Insert(Maintenance entity)
        {
            return maintenanceContext.Insert(entity);
        }

        public void Update(int id, Maintenance entity)
        {
            maintenanceContext.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return maintenanceContext.Delete(id);
        }

        public Maintenance GetById(int id)
        {
            return maintenanceContext.GetById(id);
        }

        public List<Maintenance> GetAll()
        {
            return maintenanceContext.GetAll();
        }

        public List<Maintenance> GetAll(bool completed)
        {
            return maintenanceContext.GetAll(completed);
        }

        public List<Maintenance> GetByEmployeeId(int id)
        {
            return maintenanceContext.GetByEmployeeId(id);
        }

        public List<Maintenance> GetByEmployeeId(int id, bool completed)
        {
            return maintenanceContext.GetByEmployeeId(id, completed);
        }

        public List<Maintenance> GetByTramId(int id)
        {
            return maintenanceContext.GetByTramId(id);
        }

        public List<Maintenance> GetByTramId(int id, bool completed)
        {
            return maintenanceContext.GetByTramId(id, completed);
        }

        public void Assign(int id, Employee employee)
        {
            maintenanceContext.Assign(id, employee);
        }

        public void Complete(int id, Employee employee, DateTime completed)
        {
            maintenanceContext.Complete(id, employee, completed);
        }
    }
}