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
        MSSQLTramRepository TramRepository = new MSSQLTramRepository();
        MSSQLEmployeeRepository EmployeeRepository = new MSSQLEmployeeRepository();

        private string StartQuery = "Select T_O.ID, Medewerker_ID, Tram_ID, DatumTijdstip, BeschikbaarDatum, Voltooid, Taak_ID, T.Omschrijving From TRAM_ONDERHOUD as T_O inner join TAAK as T on T.Id = T_O.Taak_ID";

        private Maintenance CreateObjectFromReader(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int medewerker_ID = Convert.ToInt32(reader["Medewerker_ID"]);
            int tram_ID = Convert.ToInt32(reader["Tram_ID"]);
            int taak_ID = Convert.ToInt32(reader["Taak_ID"]);

            DateTime ScheduledDate = Convert.ToDateTime(reader["DatumTijdstip"]);
            DateTime AvailableDate = Convert.ToDateTime(reader["BeschikbaarDatum"]);
            bool completed = Convert.ToBoolean(reader["Voltooid"]);
            string omschrijving = Convert.ToString(reader["Omschrijving"]);

            Employee employee = EmployeeRepository.GetById(medewerker_ID);
            Tram tram = TramRepository.GetById(tram_ID);

            Maintenance maintenance = new Maintenance(id, employee, tram, 
                ScheduledDate, AvailableDate, 
                completed, taak_ID, omschrijving);

            // TODO: Added a Break Point to check if the Maintenance object is created properly
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
            List<Maintenance> maintenances = new List<Maintenance>();

            string query = StartQuery;

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                maintenances.Add(CreateObjectFromReader(reader));
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                ThrowDatabaseException(exception);
            }
            finally
            {
                CloseConnection();
            }

            return maintenances;
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

        private void ThrowDatabaseException(SqlException exception)
        {
            // TODO: implement error handling
        }

    }
}