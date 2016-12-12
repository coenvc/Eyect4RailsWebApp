using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.MSSQLRepository
{
    public class MSSQLTrackRepository : Database, ITrackRepository
    {
        public bool Delete(int id)
        {
            bool executed = false;
            string[] queries = new string[3];
            queries[0] = "Update Sector Set Spoor_ID = NULL where Spoor_ID = @ID";
            queries[1] = "Update Reservering Set Spoor_ID = NULL where Spoor_ID = @ID";
            queries[2] = "Delete FROM Spoor where ID = @IID";

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
                                executed = true;
                            }
                            catch (SqlException exception)
                            {
                                // TODO: Exception afhandelen
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO: Exception afhandelen
            }
            finally
            {
                CloseConnection();
            }
            return executed;
        }

        public List<Track> GetAll()
        {
            List<Track> tracks = new List<Track>();
            string query2 = "Select * From Spoor";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query2, Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tracks.Add(CreateObjectFromReader(reader));
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                // TODO: Exception afhandelen
            }
            finally
            {
                CloseConnection();
            }
            return tracks;
        }

        public Track GetById(int id)
        {
            List<Sector> sectors = new List<Sector>();
            Track track = new Track(0, 0, 0, 0, false, false, sectors);
            string query = "Select * From Spoor Where ID = @ID";

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
                                    track = CreateObjectFromReader(reader);
                                }
                            }
                        }
                        catch (SqlException exception)
                        {
                            // TODO: Exception afhandelen
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                // TODO: Exception afhandelen
            }
            finally
            {
                CloseConnection();
            }
            return track;
        }

        public List<Track> GetByRemiseId(int remiseid)
        {
            List<Track> tracks = new List<Track>();
            string query = "Select * From Spoor Where Remise_ID = @ID";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@ID", remiseid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tracks.Add(CreateObjectFromReader(reader));
                            }
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                // TODO: Exception afhandelen
            }
            finally
            {
                CloseConnection();
            }
            return tracks;
        }

        public bool Insert(Track entity)
        {
            bool insert = false;
            string query = "INSERT INTO Spoor(Remise_ID, Nummer, Lengte, Beschikbaar, InUitRijspoor)values(@remiseid, @nummer, @lengte, @beschikbaar, @inuitrijspoor)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@remiseid", entity.RemiseId);
                            command.Parameters.AddWithValue("@nummer", entity.Number);
                            command.Parameters.AddWithValue("@lengte", entity.Sectors);
                            command.Parameters.AddWithValue("@beschikbaar", entity.Available);
                            command.Parameters.AddWithValue("@inuitrijspoor", entity.EntryDepartTrack);
                            command.ExecuteNonQuery();
                            insert = true;
                        }
                        catch (SqlException exception)
                        {
                            // TODO: Exception afhandelen
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                // TODO: Exception afhandelen
            }
            finally
            {
                CloseConnection();
            }
            return insert;
        }

        public bool Insert(Remise remise, Track track)
        {
            bool insert = false;
            string query = "INSERT INTO Spoor(Remise_ID, Nummer, Lengte, Beschikbaar, InUitRijspoor)values(@remiseid, @nummer, @lengte, @beschikbaar, @inuitrijspoor)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@remiseid", remise.Id);
                            command.Parameters.AddWithValue("@nummer", track.Number);
                            command.Parameters.AddWithValue("@lengte", track.Sectors);
                            command.Parameters.AddWithValue("@beschikbaar", track.Available);
                            command.Parameters.AddWithValue("@inuitrijspoor", track.EntryDepartTrack);
                            command.ExecuteNonQuery();
                            insert = true;
                        }
                        catch (SqlException exception)
                        {
                            // TODO: Exception afhandelen
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                // TODO: Exception afhandelen
            }
            finally
            {
                CloseConnection();
            }
            return insert;
        }

        public void Update(int id, Track entity)
        {
            string query = "Update Spoor SET Remise_ID = @remise, Nummer = @number, Lengte = @sectors, Beschikbaar = @available, InUitRijspoor = @inuitrijspoor WHERE ID = @id";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@remise", entity.RemiseId);
                            command.Parameters.AddWithValue("@number", entity.Number);
                            command.Parameters.AddWithValue("@sectors", entity.Sectors);
                            command.Parameters.AddWithValue("@available", entity.Available);
                            command.Parameters.AddWithValue("@inuitrijspoor", entity.EntryDepartTrack);
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException exception)
                        {
                            // TODO: Exception afhandelen
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                // TODO: Exception afhandelen
            }
            finally
            {
                CloseConnection();
            }
        }

        private Track CreateObjectFromReader(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int remiseid = Convert.ToInt32(reader["Remise_ID"]);
            int number = Convert.ToInt32(reader["Nummer"]);
            int sectors = Convert.ToInt32(reader["Lengte"]);
            bool available = Convert.ToBoolean(reader["Beschikbaar"]);
            bool entrydeparttrack = Convert.ToBoolean(reader["InUitRijspoor"]);
            // TODO: List sectoren ophalen en in de track zetten
            List<Sector> sectorlist = new List<Sector>();
            Track track = new Track(id, remiseid, number, sectors, available, entrydeparttrack, sectorlist);
            return track;
        }
    }
}