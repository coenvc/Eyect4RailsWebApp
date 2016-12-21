using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public viewmodel_Maintenance Create()
        {
            return new viewmodel_Maintenance(null, employeeContext.GetAll(), tramContext.GetAll());
        }

        public void Create(int tramId, int taskId, DateTime scheduled)
        {
            Tram tram = tramContext.GetById(tramId);

            Maintenance maintenance = new Maintenance(new Employee(), tram, scheduled, DateTime.MaxValue, false, (Tasks)taskId);

            Insert(maintenance);
        }

        public viewmodel_Maintenance Edit(int id)
        {
            return new viewmodel_Maintenance(maintenanceContext.GetById(id), employeeContext.GetAll(), tramContext.GetAll());
        }

        public void Edit(int id, int employeeId, int tramId, int taskId, Maintenance maintenance)
        {
            Employee employee = employeeContext.GetById(employeeId);
            Tram tram = tramContext.GetById(tramId);
            maintenance.Task = (Tasks)taskId;

            maintenance.Employee = employee;
            maintenance.Tram = tram;

            if (maintenance.Completed == false)
            {
                maintenance.AvailableDate = DateTime.MaxValue;
            }

            Update(id, maintenance);
        }


        public viewmodel_Maintenance Assign(int id)
        {
            return new viewmodel_Maintenance(maintenanceContext.GetById(id), employeeContext.GetAll(), tramContext.GetAll());
        }

        public void Assign(int id, int employeeId)
        {
            var employee = employeeContext.GetById(employeeId);

            Assign(id, employee);
        }
        
        /// 
        /// 
        /// Passthrough methods
        /// 
        /// 

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
            var maintenance = maintenanceContext.GetById(id);

            if (!(maintenance.Id >= 0))
            {
                throw new HttpException(404, "Maintenance could not be found.");
            }

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