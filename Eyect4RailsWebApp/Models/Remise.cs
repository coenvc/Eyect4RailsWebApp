using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyect4RailsWebApp.Interfaces;

namespace eyect4rails.Classes
{
    public class Remise:ICruddable
    {
        #region Properties
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "A name for the Remise is required."),
            DisplayName("Remise name")]
        public string Name { get; set; }
        
        [DisplayName("Tracks on the Remise")]
        public List<Track> Tracklist { get; set; }

        [DisplayName("Trams in the Remise")]
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
