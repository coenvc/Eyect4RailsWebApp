using System.Data.SqlClient;

namespace Eyect4RailsWebApp.Models
{
    public class Database
    {
        public string Server;
        public string DB;
        public string Uid;
        public string Password;
        public SqlConnection Connection;

        /// <summary>
        /// Opens a connection to the database
        /// </summary>
        /// <returns>true on success false on failure</returns>
        public bool OpenConnection()
        {
            Server = "mssql.fhict.local";
            DB = "dbi354261";
            Uid = "dbi354261";
            Password = "EYECT4RAILS";
            string connectionString;
            connectionString = "SERVER=" + Server + ";" + "DATABASE=" +
            DB + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";

            Connection = new SqlConnection(connectionString); 

            try
            {
                Connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
        /// <summary>
        /// Closes a connection to the database 
        /// </summary>
        /// <returns>true on success false on failure</returns>
        public bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

    }
}
