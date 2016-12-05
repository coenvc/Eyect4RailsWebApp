using System;
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

        private static List<Rights> FullRights = new List<Rights>()
        {
            Rights.WagensInvoeren,
            Rights.StatusVeranderen,
            Rights.SporenBlokkeren,
            Rights.WagensNaarDeSchoonmaakSturen,
            Rights.TijdsindicatieReparatieGeven,
            Rights.SchoonmaakLijstOpvragen,
            Rights.DatumTijdSchoonmaakInvoeren
        };

        private List<Employee> Employees = new List<Employee>()
        {
            new Employee("Coen", "van Campenhout", "0683992086", "RABO0041001241794", "coenvc", "Test123", "10102030",
                true, Function.Beheerder, FullRights)
        };

        private List<Maintenance> Maintaenances;

        public LocalMaintenaceRepository()
        {
            Maintaenances = new List<Maintenance>()
            {
                new Maintenance(Employees[0], new Tram(1, Enums.TramType.ElevenG, 4, 10, true, true, true, true),
                    new DateTime(2016, 12, 12), new DateTime(2016, 12, 15), Enums.Tasks.KleineReparatie)
            };
            Crud = new LocalCrud<Maintenance>(Maintaenances);
        }


        public bool Insert(Maintenance entity)
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

        public void Update(int id, Maintenance entity)
        {
            Crud.Update(id, entity);
        }

        public bool Delete(int id)
        {
            if (Crud.Delete(id) == true)
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
            maintenance.Employee = employee;
        }

        public void Complete(Maintenance maintenance, Employee employee)
        {
            maintenance.Completed = true;
            maintenance.Employee = employee;
            maintenance.AvailableDate = DateTime.Now; 
        }
    }
}