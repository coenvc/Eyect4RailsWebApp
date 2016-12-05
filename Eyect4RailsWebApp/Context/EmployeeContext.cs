using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;

namespace Eyect4RailsWebApp.Context
{
    public class EmployeeContext:IEmployeeRepository
    {
        private IEmployeeRepository EmployeeRepository;

        public EmployeeContext(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }   
        public bool Insert(Employee entity)
        {

            if (EmployeeRepository.Insert(entity) == true)
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
            EmployeeRepository.Update(id, entity); 

        }

        public bool Delete(int id)
        {
            if (EmployeeRepository.Delete(id) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee GetById(int id)
        {
            return EmployeeRepository.GetById(id);
        }

        public List<Employee> GetAll()
        {
            return EmployeeRepository.GetAll();
        }

        public List<Employee> GetAllActive(bool active)
        {
            return EmployeeRepository.GetAllActive(active);
        }

        public Employee GetByRfid(string rfid)
        {
            return EmployeeRepository.GetByRfid(rfid);
        }
  
        public List<Employee> GetByFunctionName(string functionName)
        {
            return EmployeeRepository.GetByFunctionName(functionName);
        }
        public Employee GetByUsernamePassword(string username, string password)
        {
            return EmployeeRepository.GetByUsernamePassword(username, password);
        }
    }
}