using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Exceptions;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.MSSQLRepository
 {		
     public class MSSQLEmployeeRepository:Database,IEmployeeRepository		
     {

        private List<Rights> FullRights = new List<Rights>
        {
            Rights.WagensInvoeren,
            Rights.StatusVeranderen,
            Rights.SporenBlokkeren,
            Rights.WagensNaarDeSchoonmaakSturen,
            Rights.TijdsindicatieReparatieGeven,
            Rights.SchoonmaakLijstOpvragen,
            Rights.DatumTijdSchoonmaakInvoeren
        };
        private bool CheckActive(int boolInt)
         {
             if (boolInt == 1)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         } 

        private Employee CreateObjectFromReader(SqlDataReader reader)
        {

            int id = Convert.ToInt32(reader["ID"]);
            int function = Convert.ToInt32(reader["FUNCTIE_ID"]);
            string name = reader["voornaam"].ToString();
            string surname = reader["achternaam"].ToString();
            string phonenumber = Convert.ToString(reader["Telefoonnummer"]);
            string bankaccount = Convert.ToString(reader["bankrekeningnummer"]);
            string username = Convert.ToString(reader["username"]);
            string password = Convert.ToString(reader["password"]);
            string rfid = Convert.ToString(reader["RFIDCode"]);
            int activeInt = Convert.ToInt32(reader["Active"]);
            

            //StatusEnum MyStatus = StatusEnum.Parse("Active");
            //StatusEnum MyStatus = (StatusEnum)Enum.Parse(typeof(StatusEnum), "Active", true);

            Employee employee = new Employee(id,surname, name, phonenumber, bankaccount, username, password, rfid, CheckActive(activeInt), (Function) function, FullRights);
            return employee;
        } 

        public bool Insert(Employee entity)		
         { 		
             bool insert = false;		
             string query ="INSERT INTO MEDEWERKER(Functie_ID,Voornaam,Achternaam,Telefoonnummer,Bankrekeningnummer,Username,Password,RFIDCode,Active) values(@FunctieId,@Voornaam,@Achternaam,@Telefoonnummer,@Bankrekeningnummer,@Username,@Password,@RFIDCode,@Active)";		
             if (OpenConnection())		
             {		
                 using (SqlCommand command = new SqlCommand(query, Connection))		
                 {		
                     try		
                     {		
                         command.Parameters.AddWithValue("@FunctieId", (int) entity.Function);		
                         command.Parameters.AddWithValue("@Voornaam", entity.Name);		
                         command.Parameters.AddWithValue("@Achternaam", entity.Surname);		
                         command.Parameters.AddWithValue("@Telefoonnummer", entity.TelephoneNumber);		
                         command.Parameters.AddWithValue("@Bankrekeningnummer", entity.IBANNumber);		
                         command.Parameters.AddWithValue("@Username", entity.Username);		
                         command.Parameters.AddWithValue("@Password", entity.Password);		
                         command.Parameters.AddWithValue("@RFIDCode", entity.RFIDCode);		
                         command.Parameters.AddWithValue("@Active", entity.Active);		
                         command.ExecuteNonQuery();		
                         insert = true;		
                     }		
                     catch (Exception exception)		
                     {		
                         // ignored		
                     }		
                 }		
             }		
                 return insert;		
         }		
 		
         public void Update(int id, Employee entity)		
         {		
             string query = "Update Medewerker set Functie_ID = @Functie_ID,Voornaam = @Voornaam,Achternaam = @Achternaam,Telefoonnummer = @Telefoonnummer,Bankrekeningnummer = @Bankrekeningnummer,Username = @Username,Password = @Password ,RFIDCode = @RFIDCode,Active = @Active where Id = @Id";		
 		
             try		
             {		
                 if (OpenConnection())		
                 {		
                     using (SqlCommand command = new SqlCommand(query, Connection))		
                     {		
                         try		
                         {		
                             command.Parameters.AddWithValue("@Functie_ID", (int)entity.Function);		
                             command.Parameters.AddWithValue("@Voornaam", entity.Name);		
                             command.Parameters.AddWithValue("@Achternaam", entity.Surname);		
                             command.Parameters.AddWithValue("@Telefoonnummer", entity.TelephoneNumber);		
                             command.Parameters.AddWithValue("@Bankrekeningnummer", entity.IBANNumber);		
                             command.Parameters.AddWithValue("@Username", entity.Username);		
                             command.Parameters.AddWithValue("@Password", entity.Password);		
                             command.Parameters.AddWithValue("@RFIDCode", entity.RFIDCode);		
                             command.Parameters.AddWithValue("@Active", entity.Active);		
                             command.Parameters.AddWithValue("@Id", id);		
                             command.ExecuteNonQuery();		
                         }		
                         catch (SqlException exception)		
                         {		
                             //Ignored		
                         }		
                     }		
                 }		
             }		
             catch (SqlException ex)		
             {		
                 //Ignored		
             }		
         }		
 		
         public bool Delete(int id)		
         {		
             string query = "Delete FROM Medewerker where Id = @Id";		
             bool executed = false;		
             try		
             {		
                 if (OpenConnection())		
                 {		
                     using (SqlCommand command = new SqlCommand(query, Connection))		
                     {		
                         try		
                         {		
                             command.Parameters.AddWithValue("@Id", id);		
                             command.ExecuteNonQuery();		
                             executed = true;		
                             return executed;		
                         }		
                         catch (SqlException exception)		
                         {		
                             //Ignored		
                         }		
                     }		
                 }		
             }		
             catch (SqlException ex)		
             {		
                 //Ignored		
             }		
             return executed;		
         }

         public Employee GetById(int id)
         {
             Employee employee = new Employee();

             string query = "SELECT * FROM MEDEWERKER WHERE ID = @ID";
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
                                     employee = CreateObjectFromReader(reader);
                                     return employee;
                                 }
                             }
                         }

                         catch (SqlException exception)
                         {
                             throw exception;
                         }
                     }
                 }
             }

             catch (Exception exception)
             {
                return employee;
             }
             return employee;
         }




        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            string query = "SELECT * FROM MEDEWERKER";

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
                                        employees.Add(CreateObjectFromReader(reader));
                                    }
                                }
                            }

                            catch (SqlException exception)
                            {
                                throw exception;
                            }
                        }
                    }

                    catch (SqlException exception)
                    {
                        throw exception;
                    }
                }
            }

            catch (SqlException exception)
            {
                throw exception;
            }

            finally
            {
                CloseConnection();
            }

            return employees;
        }

        public List<Employee> GetAllActive(bool active)
        {
            List<Employee> employees = new List<Employee>();

            string query = "select * from MEDEWERKER where active = @Active";

            try
            {
                if (OpenConnection())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, Connection))
                        {
                            if (active == true)
                            {
                                command.Parameters.AddWithValue("@Active", 1);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@Active", 0);
                            }
                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        employees.Add(CreateObjectFromReader(reader));
                                    }
                                }
                            }

                            catch (SqlException exception)
                            {
                                throw exception;
                            }
                        }
                    }

                    catch (SqlException exception)
                    {
                        throw exception;
                    }
                }
            }

            catch (SqlException exception)
            {
                throw exception;
            }

            finally
            {
                CloseConnection();
            }

            return employees;
        }
   
 		
         public Employee GetByRfid(string rfid)		
         {
            Employee employee = new Employee();

            string query = "SELECT * FROM MEDEWERKER WHERE rfidcode = @RFID";
            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@ID", rfid);
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    employee = CreateObjectFromReader(reader);
                                    return employee;
                                }
                            }
                        }

                        catch (SqlException exception)
                        {
                            throw exception;
                        }
                    }
                }
            }

            catch (Exception exception)
            {
                return employee;
            }
            return employee;
        }		
 		
         public List<Employee> GetByFunction(Function Function)		
         {
            List<Employee> employees = new List<Employee>();

            string query = "select * from MEDEWERKER where function_id = @FunctionId";

            try
            {
                if (OpenConnection())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, Connection))
                        {
                            command.Parameters.AddWithValue("@FunctionId", (int)Function);
                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        employees.Add(CreateObjectFromReader(reader));
                                    }
                                }
                            }

                            catch (SqlException exception)
                            {
                                throw exception;
                            }
                        }
                    }

                    catch (SqlException exception)
                    {
                        throw exception;
                    }
                }
            }

            catch (SqlException exception)
            {
                throw exception;
            }

            finally
            {
                CloseConnection();
            }

            return employees;
        }		
 		
         public Employee GetByUsernamePassword(string username, string password)		
         {
            Employee employee = new Employee();

            string query = "SELECT * FROM MEDEWERKER WHERE username = @username and password = @password";
            try
            {
                if (OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    employee = CreateObjectFromReader(reader);
                                    return employee;
                                }
                            }
                        }

                        catch (SqlException exception)
                        {
                            throw exception;
                        }
                    }
                }
            }

            catch (Exception exception)
            {
                return employee;
            }
            return employee;
        }		
     }		
 } 