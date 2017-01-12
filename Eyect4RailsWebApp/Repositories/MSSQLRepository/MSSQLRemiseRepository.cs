using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.MSSQLRepository
{
    public class MSSQLRemiseRepository : Database, IRemiseRepository
    {
        private MSSQLTramRepository TramRepository = new MSSQLTramRepository();
        private MSSQLTrackRepository TrackRepository = new MSSQLTrackRepository();
        private string StartQuery = "Select ID, Naam,latitude,longitude From Remise";

        private Remise CreateObjectFromReader(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string name = Convert.ToString(reader["Naam"]);
            List<Tram> trams = TramRepository.GetByRemiseId(id);
            List<Track> tracks = TrackRepository.GetByRemiseId(id);
            string latitude = Convert.ToString(reader["latitude"]);
            string longitude = Convert.ToString(reader["longitude"]);
            Remise remise = new Remise(id, name, tracks, trams);
            remise.Latitude = latitude;
            remise.Longitude = longitude;
            return remise;
        }

        public bool Insert(Remise entity)
        {
            bool insert = false;

            string query = "INSERT INTO Remise(Naam, GroteServiceBeurtenPerDag, KleineServiceBeurtenPerDag, GroteSchoonmaakBeurtenPerDag, KleineSchoonmaakBeurtenPerDag)values(@Naam, 1, 4, 2, 3)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@Naam", entity.Name);

                        command.ExecuteNonQuery();
                        insert = true;
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return insert;
        }

        public void Update(int id, Remise entity)
        {
            string query = "Update Remise SET Naam = @Naam WHERE ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@Naam", entity.Name);

                        command.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

        }

        public bool Delete(int id)
        {
            bool delete = false;

            string[] queries = new string[3];
            queries[0] = "Update Tram SET Remise_ID_Standplaats = NULL where Remise_ID_Standplaats = @ID";
            queries[1] = "Update Spoor SET Remise_ID = NULL where Remise_ID = @ID";
            queries[2] = "DELETE FROM Remise WHERE ID = @ID";

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

        public Remise GetById(int id)
        {
            Remise remise = new Remise();

            string query = StartQuery + " where ID = @ID";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            try
                            {
                                while (reader.Read())
                                {
                                    remise = CreateObjectFromReader(reader);
                                }
                            }
                            catch (SqlException ex)
                            {
                                
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                
            }


            return remise;
        }

        public List<Remise> GetAll()
        {
            List<Remise> remises = new List<Remise>();

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
                                remises.Add(CreateObjectFromReader(reader));
                            }
                        }
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return remises;
        }

        public Remise GetByRemiseName(string name)
        {
            Remise remise = new Remise();

            string query = StartQuery + " where Naam = @Naam";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@Naam", name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                remise = CreateObjectFromReader(reader);
                            }
                        }

                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return remise;
        }

        public void EmptyAll(int id)
        {
            string query = "update SECTOR set Tram_ID = null";

            if (OpenConnection())
            {
                using (SqlCommand command = new SqlCommand(query, Connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}