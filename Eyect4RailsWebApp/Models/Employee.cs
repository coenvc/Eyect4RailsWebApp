using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyect4RailsWebApp.Interfaces;

namespace eyect4rails.Classes
{
    public class Employee:ICruddable
    {
        #region Properties coming from Employee
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Function { get; set; }
        public int Id { get; set; }
        #endregion
        #region Properties coming from Account
        public int AccountID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RFIDCode { get; set; }
        public bool Active { get; set; }
        #endregion

        /// <summary>
        /// Constructor used to get Employees out of the database (when you have an ID)
        /// </summary>
        public Employee(int id, string name, string email, string telephoneNumber, string function, int accountID, string username, string password, string rFIDCode, bool active)
        {
            Id = id;
            Name = name;
            Email = email;
            TelephoneNumber = telephoneNumber;
            Function = function;
            AccountID = accountID;
            Username = username;
            Password = password;
            RFIDCode = rFIDCode;
            Active = active;
        }

        /// <summary>
        /// Constructor to make objects without an ID
        /// </summary>
        public Employee(string name, string email, string telephoneNumber, string function, string username, string password, string rFIDCode, bool active)
        {
            Name = name;
            Email = email;
            TelephoneNumber = telephoneNumber;
            Function = function;
            Username = username;
            Password = password;
            RFIDCode = rFIDCode;
            Active = active;
        }

        

        /// <summary>
        /// Zet de Employee om naar een nette string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }


    }
}
