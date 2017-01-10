using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Interfaces; 

namespace eyect4rails.Classes
{
    public class Employee:ICruddable
    {
        #region Properties
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string IBANNumber { get; set; }
        public string Username { get; set; }
        public string Password { get;  set; }
        public string RFIDCode { get; set; }
        public bool Active { get; set; }
        public Function Function{ get; set; }
        public List<Rights> Rights { get; set; }
        #endregion

        public Employee()
        {
        }

        public Employee(string surname, string name, string telephoneNumber, string ibanNumber, string username, string password, string rfidCode, bool active, Function function, List<Rights> rights)
        {
            Surname = surname;
            Name = name;
            TelephoneNumber = telephoneNumber;
            IBANNumber = ibanNumber;
            Username = username;
            Password = password;
            RFIDCode = rfidCode;
            Active = active;
            Function = function;
            Rights = rights;
        }

        public Employee(int id, string surname, string name, string telephoneNumber, string ibanNumber, string username, string password, string rfidCode, bool active, Function function, List<Rights> rights)
        {
            Id = id;
            Surname = surname;
            Name = name;
            TelephoneNumber = telephoneNumber;
            IBANNumber = ibanNumber;
            Username = username;
            Password = password;
            RFIDCode = rfidCode;
            Active = active;
            Function = function;
            Rights = rights;
        }

        /// <summary>
        /// Zet de Employee om naar een nette string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
