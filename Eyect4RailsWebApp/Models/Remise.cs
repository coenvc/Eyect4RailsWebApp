using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eyect4rails.Classes
{
    public class Remise
    {
        public int Id;
        public string Name;
        public List<Track> Tracklist;
        public string TelephoneNumber;

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
