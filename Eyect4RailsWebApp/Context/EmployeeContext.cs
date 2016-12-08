using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Enums;

namespace Eyect4RailsWebApp.Context
{
    public class EmployeeContext:IEmployeeRepository
    {
        private IEmployeeRepository Context;

        public EmployeeContext(IEmployeeRepository context)
        {
            Context = context;
        }   
        public bool Insert(Employee entity)
        {
            return Context.Insert(entity);
        }

        public void Update(int id, Employee entity)
        {
            Context.Update(id, entity); 
        }

        public bool Delete(int id)
        {
            return Context.Delete(id);
        }

        public Employee GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Employee> GetAll()
        {
            return Context.GetAll();
        }

        public List<Employee> GetAllActive(bool active)
        {
            return Context.GetAllActive(active);
        }

        public Employee GetByRfid(string rfid)
        {
            return Context.GetByRfid(rfid);
        }
  
        public List<Employee> GetByFunction(Function function)
        {
            return Context.GetByFunction(function);
        }
        public Employee GetByUsernamePassword(string username, string password)
        {
            return Context.GetByUsernamePassword(username, password);
        }
    }
}