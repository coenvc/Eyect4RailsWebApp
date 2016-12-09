using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.MSSQLRepository
{
    public class MSSQLMaintenanceRepository:Database, IMaintenanceRepository
    {
        // TODO: Add the MSSQLTramRepository
        // TODO: Add the MSSQLEmployeeRepository

        private string StartQuery = "Select * From TRAM_ONDERHOUD";

        private Maintenance CreateObjectFromReader(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int medewerker_ID = Convert.ToInt32(reader["Medewerker_ID"]);
            int tram_ID = Convert.ToInt32(reader["Tram_ID"]);

            DateTime ScheduledDate = Convert.ToDateTime(reader["DatumTijdstip"]);
            DateTime AvailableDate = Convert.ToDateTime(reader["BeschikbaarDatum"]);
            string taskString = Convert.ToString(reader["TypeOnderhoud"]);
            bool completed = Convert.ToBoolean(reader["Voltooid"]);

            Tasks task = (Tasks)Enum.Parse(typeof(Tasks), taskString ,true);

            //StatusEnum MyStatus = StatusEnum.Parse("Active");
            //StatusEnum MyStatus = (StatusEnum)Enum.Parse(typeof(StatusEnum), "Active", true);

            // TODO: Get Employee from MSSQLEmployeeRepository
            Employee employee = new Employee();
            // TODO: Get Tram from MSSQLTramRepository
            Tram tram = new Tram();

            Maintenance maintenance = new Maintenance(id, employee, tram, ScheduledDate, AvailableDate, task, false);

            return maintenance;
        }

        public bool Insert(Maintenance entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Maintenance entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Maintenance GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Maintenance> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Maintenance> GetAll(bool completed)
        {
            throw new NotImplementedException();
        }

        public List<Maintenance> GetByEmployeeId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Maintenance> GetByEmployeeId(int id, bool completed)
        {
            throw new NotImplementedException();
        }

        public List<Maintenance> GetByTramId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Maintenance> GetByTramId(int id, bool completed)
        {
            throw new NotImplementedException();
        }

        public void Assign(Maintenance maintenance, Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Complete(Maintenance maintenance, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}