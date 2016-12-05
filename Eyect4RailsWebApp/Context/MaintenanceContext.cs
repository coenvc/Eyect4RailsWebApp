using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.IRepository;

namespace Eyect4RailsWebApp.Context
{
    public class MaintenanceContext:IMaintenanceRepository
    {
        IMaintenanceRepository Context;

        public MaintenanceContext(IMaintenanceRepository context)
        {
            this.Context = context;
        }


        public bool Insert(Maintenance entity)
        {
            if (Context.Insert(entity) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(int id, Maintenance entity)
        {
            Context.Update(id, entity);
        }

        public bool Delete(int id)
        {
            if (Context.Delete(id) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    

        public Maintenance GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Maintenance> GetAll()
        {
            return Context.GetAll();
        }

        public List<Maintenance> GetAll(bool completed)
        {
            return Context.GetAll(completed);
        }

        public List<Maintenance> GetByEmployeeId(int id)
        {
            return Context.GetByEmployeeId(id);
        }

        public List<Maintenance> GetByEmployeeId(int id, bool completed)
        {
            return Context.GetByEmployeeId(id, completed);
        }

        public List<Maintenance> GetByTramId(int id)
        {
            return Context.GetByTramId(id);
        }

        public List<Maintenance> GetByTramId(int id, bool completed)
        {
            return Context.GetByTramId(id, completed);
        }

        public void Assign(Maintenance maintenance, Employee employee)
        {
            Context.Assign(maintenance, employee);
        }

        public void Complete(Maintenance maintenance, Employee employee)
        {
            Context.Complete(maintenance, employee);
        }
    }
}