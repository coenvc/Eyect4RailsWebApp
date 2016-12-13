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

            Employee employee = new Employee(surname,name,phonenumber,bankaccount,username,password,rfid,CheckActive(activeInt),(Function)function,List<Rights>(){Rights.DatumTijdSchoonmaakInvoeren,Rights.SporenBlokkeren,Rights.StatusVeranderen})
            ;
            return maintenance;
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
             Employee ReturnEmployee = null;		
             string query = "select * from medewerker where id = @id";		
             try		
             {		
                 if (OpenConnection())		
                 {		
                     using (SqlCommand command = new SqlCommand(query, Connection))		
                     {		
                         SqlDataReader reader = command.ExecuteReader();		
                         while (reader.Read())		
                         {		
                             //Employee Employee = new Employee(reader["Achternaam"].ToString(),		
                             //    reader["Voornaam"].ToString(), reader["Telefoonnummer"].ToString(),		
                             //    reader["Bankrekeningnummer"].ToString(), reader["Username"].ToString(),		
                             //    reader["Password"].ToString(), reader["RFIDCode"].ToString(),		 
                             //    Convert.ToBoolean(reader["Active"]), (Function) reader["Functie_Id"],); 

                             return ReturnEmployee;
                         }		
                     }		
                 }
                 throw new NotImplementedException();
             }		
             catch (SqlException exception)
             {
                 throw new NotImplementedException();
             }		
         }		
 		
         public List<Employee> GetAll()		
         {		
             throw new NotImplementedException();		
         }		
 		
         public List<Employee> GetAllActive(bool active)		
         {		
             throw new NotImplementedException();		
         }		
 		
         public Employee GetByRfid(string rfid)		
         {		
             throw new NotImplementedException();		
         }		
 		
         public List<Employee> GetByFunction(Function Function)		
         {		
             throw new NotImplementedException();		
         }		
 		
         public Employee GetByUsernamePassword(string username, string password)		
         {		
             throw new NotImplementedException();		
         }		
     }		
 } 