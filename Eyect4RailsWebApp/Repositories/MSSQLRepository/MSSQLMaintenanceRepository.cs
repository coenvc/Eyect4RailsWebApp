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
    public class MSSQLMaintenanceRepository : Database, IMaintenanceRepository
    {
        MSSQLTramRepository TramRepository = new MSSQLTramRepository();
        MSSQLEmployeeRepository EmployeeRepository = new MSSQLEmployeeRepository();

        private string StartQuery = "Select * from TRAM_ONDERHOUD";

        private Maintenance CreateObjectFromReader(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int tram_ID = Convert.ToInt32(reader["Tram_ID"]);
            int taak_ID = Convert.ToInt32(reader["Taak_ID"]);
            bool completed = Convert.ToBoolean(reader["Voltooid"]);

            Tasks task = (Tasks)taak_ID;

            DateTime ScheduledDate;
            DateTime.TryParse(Convert.ToString(reader["DatumTijdstip"]), out ScheduledDate);
            
            #region Properties that can be NULL in the database
            Employee employee = new Employee();

            if (reader["Medewerker_ID"] != System.DBNull.Value)
            {
                // If it's not null
                employee = EmployeeRepository.GetById(Convert.ToInt32(reader["Medewerker_ID"]));
            }

            DateTime AvailableDate = DateTime.MaxValue;

            if (reader["BeschikbaarDatum"] != System.DBNull.Value)
            {
                // If it's not null
                AvailableDate = Convert.ToDateTime(reader["BeschikbaarDatum"]);
            }
            #endregion

            Tram tram = TramRepository.GetById(tram_ID);

            Maintenance maintenance = new Maintenance(id, employee, tram,
                            ScheduledDate, AvailableDate,
                            completed, task);

            return maintenance;
        }

        public bool Insert(Maintenance entity)
        {
            bool insert = false;

            string query = $"INSERT INTO TRAM_ONDERHOUD(Medewerker_ID, Tram_ID, DatumTijdstip, BeschikbaarDatum, Taak_ID, Voltooid) values(@Medewerker_ID, @Tram_ID, @DatumTijdstip, @BeschikbaarDatum, @Taak_ID, @Voltooid)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@Medewerker_ID", Convert.DBNull);
                        command.Parameters.AddWithValue("@Tram_ID", entity.Tram.Id);
                        command.Parameters.AddWithValue("@DatumTijdstip", entity.ScheduledDate);
                        if (entity.AvailableDate.Year == 9999)
                        {
                            command.Parameters.AddWithValue("@BeschikbaarDatum", Convert.DBNull);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@BeschikbaarDatum", entity.AvailableDate);
                        }
                        command.Parameters.AddWithValue("@Taak_ID", (int)entity.Task);
                        command.Parameters.AddWithValue("@Voltooid", entity.Completed);

                        command.ExecuteNonQuery();
                        insert = true;
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }

            return insert;
        }

        public void Update(int id, Maintenance entity)
        {
            string query = $"Update TRAM_ONDERHOUD SET Medewerker_ID = @Medewerker_ID, Tram_ID = @Tram_ID, DatumTijdstip = @DatumTijdstip, BeschikbaarDatum = @BeschikbaarDatum, Taak_ID = @Taak_ID, Voltooid = @Voltooid where ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@Medewerker_ID", entity.Employee.Id);
                        command.Parameters.AddWithValue("@Tram_ID", entity.Tram.Id);
                        command.Parameters.AddWithValue("@DatumTijdstip", entity.ScheduledDate);
                        if (entity.AvailableDate.Year == 9999)
                        {
                            command.Parameters.AddWithValue("@BeschikbaarDatum", Convert.DBNull);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@BeschikbaarDatum", entity.AvailableDate);
                        }
                        command.Parameters.AddWithValue("@Taak_ID", (int)entity.Task);
                        command.Parameters.AddWithValue("@Voltooid", entity.Completed);

                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Delete(int id)
        {
            bool delete = false;

            string query = "DELETE FROM TRAM_ONDERHOUD WHERE ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                        delete = true;
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }

            return delete;
        }

        public Maintenance GetById(int id)
        {
            Maintenance maintenance = new Maintenance();

            string query = StartQuery + " where ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id.ToString());

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                maintenance = CreateObjectFromReader(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }

            return maintenance;
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
            List<Maintenance> maintenances = new List<Maintenance>();

            string query = StartQuery + " where Voltooid = @completed";

            if (completed == false)
            {
                query = query + " and Medewerker_ID is null";
            }

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@completed", Convert.ToInt32(completed));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Maintenance maintenance = CreateObjectFromReader(reader);

                                maintenances.Add(maintenance);
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }

            return maintenances;
        }

        public List<Maintenance> GetByEmployeeId(int id)
        {
            List<Maintenance> maintenances = new List<Maintenance>();

            string query = StartQuery + " where Medewerker_ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id.ToString());

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Maintenance maintenance = CreateObjectFromReader(reader);

                                maintenances.Add(maintenance);
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }

            return maintenances;
        }

        public List<Maintenance> GetByEmployeeId(int id, bool completed)
        {
            List<Maintenance> maintenances = new List<Maintenance>();

            string query = StartQuery + " where Medewerker_ID = @id and Voltooid = @completed";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id.ToString());
                        command.Parameters.AddWithValue("@completed", Convert.ToInt32(completed));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Maintenance maintenance = CreateObjectFromReader(reader);

                                maintenances.Add(maintenance);
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }

            return maintenances;
        }

        public List<Maintenance> GetByTramId(int id)
        {
            List<Maintenance> maintenances = new List<Maintenance>();

            string query = StartQuery + " where Tram_ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id.ToString());

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Maintenance maintenance = CreateObjectFromReader(reader);

                                maintenances.Add(maintenance);
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }

            return maintenances;
        }

        public List<Maintenance> GetByTramId(int id, bool completed)
        {
            List<Maintenance> maintenances = new List<Maintenance>();

            string query = StartQuery + " where Tram_ID = @id and Voltooid = @completed";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id.ToString());
                        command.Parameters.AddWithValue("@completed", Convert.ToInt32(completed));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Maintenance maintenance = CreateObjectFromReader(reader);

                                maintenances.Add(maintenance);
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }

            return maintenances;
        }

        public void Assign(int id, Employee employee)
        {
            string query = $"Update TRAM_ONDERHOUD SET Medewerker_ID = @Medewerker_ID where ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@Medewerker_ID", employee.Id);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Complete(int id, Employee employee, DateTime completed)
        {
            string query = $"Update TRAM_ONDERHOUD SET Medewerker_ID = @Medewerker_ID, BeschikbaarDatum = @Beschikbaardatum, Voltooid = 1 where ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@Medewerker_ID", employee.Id);
                        command.Parameters.AddWithValue("@BeschikbaarDatum", completed);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException exception)
            {

            }
            finally
            {
                CloseConnection();
            }
        }

        private void ThrowDatabaseException(SqlException exception)
        {
            // TODO: implement error handling
        }

    }
}