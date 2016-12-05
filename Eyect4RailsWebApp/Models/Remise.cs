using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyect4RailsWebApp.Interfaces;

namespace eyect4rails.Classes
{
    public class Remise:ICruddable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Track> Tracklist { get; set; }
        public string TelephoneNumber { get; set; }

        public Remise(int id, string name, string telephonenumber)
        {
            this.Id = id;
            this.Name = name;
            this.TelephoneNumber = telephonenumber;
        }

        public Remise(string name, string telephoneNumber)
        {
            Name = name;
            TelephoneNumber = telephoneNumber;
        }

    }
}
