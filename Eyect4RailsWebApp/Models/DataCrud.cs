using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using eyect4rails.IRepository;

namespace Eyect4RailsWebApp.Models
{
    public class DataCrud<T> :Database, IRepository<T> where T: class  
    {
        public bool Insert(T entity)
        {
            bool insert = false;
            Type currentType = entity.GetType();
            IList<PropertyInfo> properties = new List<PropertyInfo>(currentType.GetProperties());
            string query = $"INSERT INTO Address(StreetName, City, Country, ZIPCode, HouseNumber) values(@StreetName, @City, @Country, @ZIPCode, @HouseNumber)";

            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        try
                        {
                            foreach(PropertyInfo propertyInfo in properties)
                            {
                                Console.WriteLine(propertyInfo);
                            }


                            command.ExecuteNonQuery();
                            insert = true;
                        }
                        catch (SqlException exception)
                        { 

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
            return insert;
        }

        public void Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}