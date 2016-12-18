using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;

namespace Eyect4RailsWebApp.Logic
{
    public class EmployeeLogic:IEmployeeRepository
    {
        EmployeeContext Context = new EmployeeContext(new MSSQLEmployeeRepository());


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
            throw new NotImplementedException();
        }

        public Employee GetByRfid(string rfid)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetByFunction(Function function)
        {
            throw new NotImplementedException();
        }

        public Employee GetByUsernamePassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}