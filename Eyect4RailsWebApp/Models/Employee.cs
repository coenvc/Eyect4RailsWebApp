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
        public string Lastname { get; set; }
        public string TelephoneNumber { get; set; }
        public string IBANNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public string RFIDCode { get; set; }
        public bool Active { get; set; }
        public string Function { get; set; }
        public List<Rights> Rights { get; set; }
        #endregion

        public Employee()
        {
        }

        public Employee(string surname, string lastname, string telephoneNumber, string ibanNumber, string username, string password, string rfidCode, bool active, string function, List<Rights> rights)
        {
            Surname = surname;
            Lastname = lastname;
            TelephoneNumber = telephoneNumber;
            IBANNumber = ibanNumber;
            Username = username;
            Password = password;
            RFIDCode = rfidCode;
            Active = active;
            Function = function;
            Rights = rights;
        }

        public Employee(int id, string surname, string lastname, string telephoneNumber, string ibanNumber, string username, string password, string rfidCode, bool active, string function, List<Rights> rights)
        {
            Id = id;
            Surname = surname;
            Lastname = lastname;
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
            return $"{Surname} {Lastname}";
        }


    }
}
