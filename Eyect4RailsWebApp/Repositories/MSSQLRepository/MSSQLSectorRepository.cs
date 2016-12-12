﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.MSSQLRepository
{
    public class MSSQLSectorRepository : Database, ISectorRepository
    {
        // int trackId, int tramId, int number, bool available, bool blocked
        private Sector CreateObjectFromReader(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int trackId = Convert.ToInt32(reader["Spoor_ID"]);
            int tramId = Convert.ToInt32(reader["Tram_ID"]);
            int number = Convert.ToInt32(reader["Nummer"]);
            bool available = Convert.ToBoolean(reader["Beschikbaar"]);
            bool blocked = Convert.ToBoolean(reader["Blokkade"]);

            Sector sector = new Sector(id, trackId, tramId, number, available, blocked);
            return sector;

        }
        public bool Delete(int id)
        {
            bool delete = false;

            string query = "DELETE FROM SECTOR WHERE ID = @ID";

            try
            {
                if (OpenConnection())
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

        public List<Sector> GetAll()
        {
            List<Sector> sectors = new List<Sector>();

            string query = "SELECT * FROM SECTOR";

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
                                        sectors.Add(CreateObjectFromReader(reader));
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

            return sectors;
        }

        public Sector GetById(int id)
        {
            Sector sector = new Sector();

            string query = "SELECT * FROM SECTOR WHERE ID = @ID";

            try
            {
                if (OpenConnection())
                {
                    try
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
                                        sector = CreateObjectFromReader(reader);
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

            return sector;
        }

        public List<Sector> GetByTrackId(int id)
        {
            List<Sector> sectors = new List<Sector>();

            string query = "SELECT * FROM SECTOR WHERE Spoor_ID = @TrackId";

            try
            {
                if (OpenConnection())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, Connection))
                        {

                            command.Parameters.AddWithValue("@TrackId", id);

                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        sectors.Add(CreateObjectFromReader(reader));
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

            return sectors;
        }

        public Sector GetByTramId(int id)
        {
            Sector sector = new Sector();

            string query = "SELECT * FROM SECTOR WHERE Tram_ID = @TrackId";

            try
            {
                if (OpenConnection())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, Connection))
                        {

                            command.Parameters.AddWithValue("@TrackId", id);

                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        sector = CreateObjectFromReader(reader);
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

            return sector;
        }

        public bool Insert(Sector entity)
        {
            bool insert = false;

            string query =
                "INSERT INTO SECTOR (ID, Spoor_ID, Tram_ID, Nummer, Beschikbaar, Blokkade) VALUES (@ID, @Spoor_Id, @Tram_Id, @Nummer, @Beschikbaar, @Blokkade)";

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
                                command.Parameters.AddWithValue("@ID", entity.Id);
                                command.Parameters.AddWithValue("@Spoor_Id", entity.TrackId);
                                command.Parameters.AddWithValue("@Tram_Id", entity.TramId);
                                command.Parameters.AddWithValue("@Nummer", entity.Number);
                                command.Parameters.AddWithValue("@Beschikbaar", entity.Available);
                                command.Parameters.AddWithValue("@Blokkade", entity.Blocked);

                                command.ExecuteNonQuery();
                                insert = true;
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

            return insert;
        }

        public void Update(int id, Sector entity)
        {
            string query =
                "UPDATE SECTOR SET ID = @ID, Spoor_ID = @Spoor_Id, Tram_ID = @Tram_Id, Nummer = @Nummer, Beschikbaar = @Beschikbaar, Blokkade = @Blokkade";

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
                                command.Parameters.AddWithValue("@ID", entity.Id);
                                command.Parameters.AddWithValue("@Spoor_Id", entity.TrackId);
                                command.Parameters.AddWithValue("@Tram_Id", entity.TramId);
                                command.Parameters.AddWithValue("@Nummer", entity.Number);
                                command.Parameters.AddWithValue("@Beschikbaar", entity.Available);
                                command.Parameters.AddWithValue("@Blokkade", entity.Blocked);

                                command.ExecuteNonQuery();
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
        }

        private void ThrowDatabaseException(Exception ex)
        {
            // TODO: implement error handling
        }
    }
}