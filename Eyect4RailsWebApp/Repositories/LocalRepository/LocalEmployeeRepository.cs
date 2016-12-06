using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.LocalRepository
{
    public class LocalEmployeeRepository : IEmployeeRepository
    {
        private LocalCrud<Employee> Crud;

        private List<Rights> FullRights = new List<Rights>
        {
            Rights.WagensInvoeren,
            Rights.StatusVeranderen,
            Rights.SporenBlokkeren,
            Rights.WagensNaarDeSchoonmaakSturen,
            Rights.TijdsindicatieReparatieGeven,
            Rights.SchoonmaakLijstOpvragen,
            Rights.DatumTijdSchoonmaakInvoeren
        };

        private List<Employee> Employees = new List<Employee>();

        public LocalEmployeeRepository()
        {
            Employee Coen = new Employee("Coen", "van Campenhout", "0683992086", "RABO0041001241794", 
                "coenvc", "Test123", "10102030", true, Function.Beheerder, FullRights);

            Insert(Coen);

            Crud = new LocalCrud<Employee>(Employees);
        }

        public bool Insert(Employee entity)
        {
            if (Crud.Insert(entity) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(int id, Employee entity)
        {
            Crud.Update(id, entity);
        }

        public bool Delete(int id)
        {
            if (Crud.Delete(id) == true)
            {
                return true;
            }
            return false;
        }
        
        public Employee GetById(int id)
        {
            return Crud.GetById(id);
        }

        public List<Employee> GetAll()
        {
            return Crud.GetAll();
        }

        public List<Employee> GetAllActive(bool active)
        {
            List<Employee> activeEmployees = new List<Employee>();
            foreach (Employee employee in Employees)
            {
                if (employee.Active == active)
                {
                    activeEmployees.Add(employee);
                }
            }
            return activeEmployees;
        }

        public Employee GetByRfid(string rfid)
        {
            Employee ReturnEmployee = null;
            foreach (Employee employee in Employees)
            {
                if (employee.RFIDCode == rfid)
                {
                    ReturnEmployee = employee;
                }
            }
            return ReturnEmployee;
        }

        public List<Employee> GetByFunction(Function function)
        {
            List<Employee> employeesWithFunction = new List<Employee>();
            foreach (Employee employee in Employees)
            {
                if (employee.Function == function)
                {
                    employeesWithFunction.Add(employee);
                }
            }
            return employeesWithFunction;
        }


        public Employee GetByUsernamePassword(string username, string password)
        {
            Employee employeeWithUsernameAndPassword = null;
            foreach (Employee employee in Employees)
            {
                if (employee.Username == username && employee.Password == password)
                {
                    employeeWithUsernameAndPassword = employee;
                }
            }
            return employeeWithUsernameAndPassword;
        }
    }
}