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

        public bool Insert(Tram entity)
        {
            bool insert = false;

            string query =
                "INSERT INTO TRAM (Remise_ID_Standplaats, Tramtype_ID, Nummer, Lengte, Vervuild, Defect, ConducteurGeschikt, Beschikbaar) VALUES (@RemiseID, @Tramtype, @Tramnumber, @Length, @Filthy, @Defective, @ConductorQualified, @Available)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
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
                }
            }
            catch (Exception ex)
            {
                
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
                        command.Parameters.AddWithValue("@ID", entity.Id);
                        command.Parameters.AddWithValue("@RemiseID", entity.RemiseId);
                        command.Parameters.AddWithValue("@Tramtype", (int) entity.Tramtype);
                        command.Parameters.AddWithValue("@Tramnumber", entity.TramNumber);
                        command.Parameters.AddWithValue("@Length", entity.Length);
                        command.Parameters.AddWithValue("@Filthy", entity.Filthy);
                        command.Parameters.AddWithValue("@Defective", entity.Defective);
                        command.Parameters.AddWithValue("@ConductorQualified", entity.ConductorQualified);
                        command.Parameters.AddWithValue("@Available", entity.Available);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException ex)
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

            string[] queries = new string[5];
            queries[0] = "DELETE FROM SECTOR WHERE Tram_ID = @ID";
            queries[1] = "DELETE FROM RESERVERING WHERE Tram_ID = @ID";
            queries[2] = "DELETE TRAM_ONDERHOUD WHERE Tram_ID = @ID";
            queries[3] = "DELETE FROM TRAM_LIJN WHERE Tram_ID = @ID";
            queries[4] = "DELETE FROM TRAM WHERE ID = @ID";

            try
            {
                if (OpenConnection())
                {
                    foreach (string query in queries)
                    {
                        using (SqlCommand command = new SqlCommand(query, Connection))
                        {
                            command.Parameters.AddWithValue("@ID", id);

                            command.ExecuteNonQuery();
                            delete = true;


                        }
                    }
                }
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

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tram = CreateObjectFromReader(reader);
                            }
                        }

                    }
                }
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
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                trams.Add(CreateObjectFromReader(reader));
                            }
                        }

                    }
                }
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

                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@SectorId", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tramIdBySector = Convert.ToInt32(reader["Tram_ID"]);
                            }
                        }

                    }

                }
            }
            finally
            {
                CloseConnection();
            }

            return tramIdBySector;
        }

        public List<Tram> GetByRemiseId(int id)
        {
            List<Tram> trams = new List<Tram>();

            string query = "SELECT * FROM TRAM WHERE Remise_ID_Standplaats = @RemiseId";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@RemiseId", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                trams.Add(CreateObjectFromReader(reader));
                            }
                        }
                    }
                }
            }

            finally
            {
                CloseConnection();
            }

            return trams;
        }

        public List<Tram> GetNotParkedTrams()
        {
            List<Tram> NotParkedTrams = new List<Tram>();
            string query ="Select T.ID, T.Remise_ID_Standplaats, T.Tramtype_ID, T.Nummer, T.Lengte, T.Vervuild, T.Defect, T.ConducteurGeschikt, T.Beschikbaar from TRAM as T left join SECTOR as S on S.Tram_ID = T.ID where S.ID is null";
            if (OpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NotParkedTrams.Add(CreateObjectFromReader(reader));
                                
                            }
                            return NotParkedTrams;
                        }
                    }

                }
                catch (Exception exception)
                {

                }
                finally
                {
                    CloseConnection(); 
                }
                
            }
            throw new Exception();
        }
    }
}