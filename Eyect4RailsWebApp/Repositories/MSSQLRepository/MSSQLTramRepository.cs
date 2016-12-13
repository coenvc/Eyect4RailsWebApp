using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.MSSQLRepository
{
    public class MSSQLTramRepository : Database, ITramRepository
    {
        private Tram CreateObjectFromReader(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int remiseId = Convert.ToInt32(reader["Remise_ID_Standplaats"]);
            TramType tramtype = (TramType)Convert.ToInt32(reader["Tramtype_ID"]);
            int tramNumber = Convert.ToInt32(reader["Nummer"]);
            int length = Convert.ToInt32(reader["Lengte"]);
            bool filthy = Convert.ToBoolean(reader["Vervuild"]);
            bool defective = Convert.ToBoolean(reader["Defect"]);
            bool conductorQualified = Convert.ToBoolean(reader["ConducteurGeschikt"]);
            bool available = Convert.ToBoolean(reader["Beschikbaar"]);

            Tram tram = new Tram(id, remiseId, tramtype, tramNumber, length, filthy, defective, conductorQualified, available);
            return tram;
        }
        public Tram GetBySectorId(int id)
        {
            Tram tram = GetById(TramIdBySectorId(id));
            return tram;
        }

        public List<Tram> GetByRemiseId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Tram entity)
        {
            bool insert = false;

            string query =
                "INSERT INTO TRAM (ID, Remise_ID_Standplaats, Tramtype_ID, Nummer, Lengte, Vervuild, Defect, ConducteurGeschikt, Beschikbaar) VALUES (@ID, @RemiseID, @Tramtype, @Tramnumber, @Length, @Filthy, @Defective, @ConductorQualified, @Available)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@ID", entity.Id);
                            command.Parameters.AddWithValue("@RemiseID", entity.RemiseId);
                            command.Parameters.AddWithValue("@Tramtype", entity.Tramtype);
                            command.Parameters.AddWithValue("@Tramnumber", entity.TramNumber);
                            command.Parameters.AddWithValue("@Length", entity.Length);
                            command.Parameters.AddWithValue("@Filthy", entity.Filthy);
                            command.Parameters.AddWithValue("@Defective", entity.Defective);
                            command.Parameters.AddWithValue("@ConductorQualified", entity.ConductorQualified);
                            command.Parameters.AddWithValue("@Available", entity.Available);

                            command.ExecuteNonQuery();
                            insert = true;
                        }

                        catch (SqlException exception)
                        {
                            ThrowDatabaseException(exception);
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

            return insert;
        }

        public void Update(int id, Tram entity)
        {
            string query =
                "UPDATE TRAM SET Remise_ID_Standplaats = @RemiseID, Tramtype_ID = @Tramtype, Nummer = @Tramnumber, Lengte = @Length, Vervuild = @Filthy, Defect = @Defective, ConducteurGeschikt = @ConductorQualified, Beschikbaar = @Available WHERE ID = @ID";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@ID", entity.Id);
                            command.Parameters.AddWithValue("@RemiseID", entity.RemiseId);
                            command.Parameters.AddWithValue("@Tramtype", entity.Tramtype);
                            command.Parameters.AddWithValue("@Tramnumber", entity.TramNumber);
                            command.Parameters.AddWithValue("@Length", entity.Length);
                            command.Parameters.AddWithValue("@Filthy", entity.Filthy);
                            command.Parameters.AddWithValue("@Defective", entity.Defective);
                            command.Parameters.AddWithValue("@ConductorQualified", entity.ConductorQualified);
                            command.Parameters.AddWithValue("@Available", entity.Available);

                            command.ExecuteNonQuery();
                        }

                        catch (SqlException exception)
                        {
                            ThrowDatabaseException(exception);
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
        }
        public bool Delete(int id)
        {
            bool delete = false;

            string[] queries = new string[5];
            queries[0] = "UPDATE SECTOR SET Tram_ID = NULL where Tram_ID = @ID";
            queries[1] = "UPDATE RESERVERING SET Tram_ID = NULL where Tram_ID = @ID";
            queries[2] = "UPDATE TRAM_ONDERHOUD SET Tram_ID = NULL where Tram_ID = @ID";
            queries[3] = "UPDATE TRAM_LIJN SET Tram_ID = NULL where Tram_ID = @ID";
            queries[4] = "DELETE FROM TRAM WHERE ID = @ID";

            try
            {
                if (OpenConnection())
                {
                    foreach (string query in queries)
                    {
                        using (SqlCommand command = new SqlCommand(query, Connection))
                        {
                            try
                            {
                                command.Parameters.AddWithValue("@ID", id);

                                command.ExecuteNonQuery();
                                delete = true;
                            }

                            catch (SqlException exception)
                            {
                                ThrowDatabaseException(exception);
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

            return delete;

        }

        public Tram GetById(int id)
        {
            Tram tram = new Tram();

            string query = "SELECT * FROM TRAM WHERE ID = @ID";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    tram = CreateObjectFromReader(reader);
                                }
                            }
                        }

                        catch (SqlException exception)
                        {
                            ThrowDatabaseException(exception);
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

            return tram;
        }

        public List<Tram> GetAll()
        {
            List<Tram> trams = new List<Tram>();

            string query = "SELECT * FROM TRAM";

            try
            {
                if (OpenConnection())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, Connection))
                        {
                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        trams.Add(CreateObjectFromReader(reader));
                                    }
                                }
                            }

                            catch (SqlException exception)
                            {
                                ThrowDatabaseException(exception);
                            }
                        }
                    }

                    catch (SqlException exception)
                    {
                        ThrowDatabaseException(exception);
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

            return trams;
        }

        private int TramIdBySectorId(int id)
        {
            int tramIdBySector = 0;

            string query = "SELECT Tram_ID FROM SECTOR WHERE ID = @SectorId";

            try
            {
                if (OpenConnection())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, Connection))
                        {
                            command.Parameters.AddWithValue("@SectorId", id);
                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        tramIdBySector = Convert.ToInt32(reader["Tram_ID"]);
                                    }
                                }
                            }

                            catch (SqlException exception)
                            {
                                ThrowDatabaseException(exception);
                            }
                        }
                    }

                    catch (SqlException exception)
                    {
                        ThrowDatabaseException(exception);
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

            return tramIdBySector;
        }

        private void ThrowDatabaseException(Exception ex)
        {
            // TODO: implement error handling
        }
    }
}