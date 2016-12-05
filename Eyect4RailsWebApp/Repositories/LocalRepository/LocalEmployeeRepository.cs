﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.LocalRepository
{
    public class LocalEmployeeRepository:IEmployeeRepository
    {
        private LocalCrud<Employee> Crud;

        private List<Employee> Employees = new List<Employee>()
        {
            new Employee("Coen van Campenhout", "coenvc@gmail.com", "0683992086", "Cleaner", "coenvc", "Test123","10102030", true)
        };
        public LocalEmployeeRepository()
        {
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

        public List<Employee> GetByFunctionName(string functionName)
        {
            List<Employee> employeesWithFunction = new List<Employee>();
            foreach (Employee employee in Employees)
            {
                if (employee.Function == functionName)
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