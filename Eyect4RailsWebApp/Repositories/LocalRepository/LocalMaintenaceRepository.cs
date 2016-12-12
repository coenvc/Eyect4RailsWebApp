﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.LocalRepository
{
    public class LocalMaintenaceRepository : IMaintenanceRepository
    {
        private LocalCrud<Maintenance> Crud;
        private LocalEmployeeRepository EmployeeRepository = new LocalEmployeeRepository();
        private LocalTramRepository TramRepository = new LocalTramRepository();

        private List<Maintenance> Maintenances;
        private List<Employee> Employees;
        private List<Tram> Trams;

        public LocalMaintenaceRepository()
        {
            Trams = TramRepository.GetAll();
            Employees = EmployeeRepository.GetAll();

            Maintenances = new List<Maintenance>
            {
                new Maintenance(Employees[0], Trams[0], DateTime.Now.AddDays(-1), DateTime.Now.AddDays(3), false, 0, "Grote Schoonmaak"),
                new Maintenance(Employees[1], Trams[1], DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-1), true, 1, "Kleine Schoonmaak")
            };

            Crud = new LocalCrud<Maintenance>(Maintenances);
        }


        public bool Insert(Maintenance entity)
        {
            return Crud.Insert(entity);
        }

        public void Update(int id, Maintenance entity)
        {
            Crud.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return Crud.Delete(id);
        }

        public Maintenance GetById(int id)
        {
            return Crud.GetById(id);
        }

        public List<Maintenance> GetAll()
        {
            return Crud.GetAll();
        }

        public List<Maintenance> GetAll(bool completed)
        {

            return Crud.GetAll().Where(x => x.Completed == completed).ToList();
        }

        public List<Maintenance> GetByEmployeeId(int id)
        {
            return Crud.GetAll().Where(x => x.Employee.Id == id).ToList();
        }

        public List<Maintenance> GetByEmployeeId(int id, bool completed)
        {
            return Crud.GetAll().Where(x => x.Employee.Id == id && x.Completed == completed).ToList();
        }

        public List<Maintenance> GetByTramId(int id)
        {
            return Crud.GetAll().Where(x => x.Tram.Id == id).ToList();
        }

        public List<Maintenance> GetByTramId(int id, bool completed)
        {
            return Crud.GetAll().Where(x => x.Tram.Id == id && x.Completed == completed).ToList();
        }

        public void Assign(Maintenance maintenance, Employee employee)
        {
            if (employee != null)
            {
                maintenance.Employee = employee;
            }
        }

        public void Complete(Maintenance maintenance, Employee employee)
        {
            maintenance.Completed = true;
            maintenance.Employee = employee;
            maintenance.AvailableDate = DateTime.Now;
        }
    }
}