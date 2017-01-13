using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
            int tramId = 0;
            int id = Convert.ToInt32(reader["ID"]);
            int trackId = Convert.ToInt32(reader["Spoor_ID"]);
            if (reader["Tram_ID"] is DBNull)
            {
                tramId = 0;
            }
            else
            {
                tramId = Convert.ToInt32(reader["Tram_ID"]);
            }
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
                        command.Parameters.AddWithValue("@ID", id);

                        command.ExecuteNonQuery();
                        delete = true;
                    }
                }
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
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sectors.Add(CreateObjectFromReader(reader));
                            }
                        }
                    }
                }
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
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sector = CreateObjectFromReader(reader);
                            }
                        }
                    }
                }
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
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {

                        command.Parameters.AddWithValue("@TrackId", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sectors.Add(CreateObjectFromReader(reader));
                            }
                        }
                    }
                }
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

            string query = "SELECT * FROM SECTOR WHERE Tram_ID = @TramId";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {

                        command.Parameters.AddWithValue("@TramId", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sector = CreateObjectFromReader(reader);
                            }
                        }

                    }

                }
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
                "INSERT INTO SECTOR (Spoor_ID, Tram_ID, Nummer, Beschikbaar, Blokkade) VALUES (@Spoor_Id, @Tram_Id, @Nummer, @Beschikbaar, @Blokkade)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@Spoor_Id", entity.TrackId);
                        command.Parameters.AddWithValue("@Tram_Id", entity.TramId);
                        command.Parameters.AddWithValue("@Nummer", entity.Number);
                        command.Parameters.AddWithValue("@Beschikbaar", entity.Available);
                        command.Parameters.AddWithValue("@Blokkade", entity.Blocked);

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

        public void Update(int id, Sector entity)
        {
            string query =
                "UPDATE SECTOR SET Spoor_ID = @Spoor_Id, Tram_ID = @Tram_Id, Nummer = @Nummer, Beschikbaar = @Beschikbaar, Blokkade = @Blokkade WHERE ID = @ID";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@ID", entity.Id);
                        command.Parameters.AddWithValue("@Spoor_Id", entity.TrackId);
                        command.Parameters.AddWithValue("@Tram_Id", entity.TramId);
                        command.Parameters.AddWithValue("@Nummer", entity.Number);
                        command.Parameters.AddWithValue("@Beschikbaar", entity.Available);
                        command.Parameters.AddWithValue("@Blokkade", entity.Blocked);

                        command.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public int MinimalSectorNumber(int trackId)
        {
            int minimalSectorNumber = 0;

            string query =
                @"SELECT MIN(Nummer) FROM SECTOR WHERE Spoor_ID = @SpoorID AND (Beschikbaar = 0 OR Blokkade = 1) ";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@SpoorID", trackId);
                        if (command.ExecuteScalar() != System.DBNull.Value)
                        {
                            minimalSectorNumber = (int)command.ExecuteScalar();
                        }
                        else
                        {
                            minimalSectorNumber = 0;
                        }
                    }
                }
            }

            finally
            {
                CloseConnection();
            }

            return minimalSectorNumber;
        }

        public int MaximalSectorNumber(int trackId)
        {
            int maximalSectorNumber = 0;

            string query =
                @"SELECT MAX(Nummer) FROM SECTOR WHERE Spoor_ID = @SpoorID AND (Beschikbaar = 1 AND Blokkade = 0)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@SpoorID", trackId);
                        if (command.ExecuteScalar() != System.DBNull.Value)
                        {
                            maximalSectorNumber = (int) command.ExecuteScalar();
                        }
                        else
                        {
                            maximalSectorNumber = 0;
                        }
                    }
                }
            }

            finally
            {
                CloseConnection();
            }


            return maximalSectorNumber;
        }


        public void UpdateAssignTramSectors(int trackId, int sectorNumber, int tramid)
        {
            string query =
                @"UPDATE SECTOR SET SECTOR.Tram_ID = @TramID WHERE SECTOR.Nummer = @Nummer AND SECTOR.Spoor_ID = @SpoorID";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@TramID", tramid);
;                        command.Parameters.AddWithValue("@Nummer", sectorNumber);
                        command.Parameters.AddWithValue("@SpoorID", trackId);
                        command.ExecuteNonQuery();
                    }
                }
            }

            finally
            {
                CloseConnection();
            }
        }

    }
}