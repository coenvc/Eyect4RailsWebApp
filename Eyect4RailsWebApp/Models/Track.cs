using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyect4RailsWebApp.Interfaces;

namespace eyect4rails.Classes
{
    public class Track:ICruddable
    {
        public int Id { get; set; }
        public bool ConductorRequired;
        public int Sectors;
        public int TestCalculation { get; set; }
        public int OpenSectors { get; set; }
        public string TrackType { get; set; }

        public List<Tram> trams = new List<Tram>();
        public List<Tram> copytrams = new List<Tram>();
        public List<Tram> Trams = new List<Tram>();


        public Track(int id, bool conductorRequired, int sectors, List<Tram> trams, string tracktype)
        {
            this.Id = id;
            this.ConductorRequired = conductorRequired;
            this.Sectors = sectors;
            this.Trams = trams;
            this.TrackType = tracktype;
            OpenSectorCalculation();
        }

        public Track(bool conductorRequired, int sectors, List<Tram> trams, string tracktype)
        {
            this.ConductorRequired = conductorRequired;
            this.Trams = trams;
            this.Sectors = sectors;
            this.TrackType = tracktype;
            OpenSectorCalculation();
        }
        
        /// <summary>
        /// This mehod checks all the trams from the track and calculates the OpenSectors.
        /// </summary>
        public void OpenSectorCalculation()
        {
            OpenSectors = Sectors;
            foreach (Tram tram in trams)
            {
                this.OpenSectors = OpenSectors - tram.Sectors;
            }

            TestCalculation = OpenSectors;
        }

        public override string ToString()
        {
            return $"{Id}, {TrackType}";
        }
    }
}
