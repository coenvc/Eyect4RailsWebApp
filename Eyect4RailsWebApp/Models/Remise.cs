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
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Track> Tracklist { get; set; }
        public List<Tram> Tramlist { get; set; }
        #endregion

        public Remise()
        {
        }

        public Remise(string name, List<Track> tracklist, List<Tram> tramlist)
        {
            Name = name;
            Tracklist = tracklist;
            Tramlist = tramlist;
        }

        public Remise(int id, string name, List<Track> tracklist, List<Tram> tramlist)
        {
            Id = id;
            Name = name;
            Tracklist = tracklist;
            Tramlist = tramlist;
        }
    }
}
