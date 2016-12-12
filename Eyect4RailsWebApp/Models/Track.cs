using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyect4RailsWebApp.Interfaces;
using Eyect4RailsWebApp.Models;

namespace eyect4rails.Classes
{
    public class Track : ICruddable
    {
        #region Properties
        public int Id { get; set; }
        public int RemiseId { get; set; }
        public int Number { get; set; }
        public int Sectors { get; set; }
        public bool Available { get; set; }
        public bool EntryDepartTrack { get; set; }
        public List<Sector> SectorList { get; set; }
        #endregion

        public Track()
        {
        }

        public Track(int id, int remise_id, int number, int sectors, bool available, bool entrydeparttrack, List<Sector> sectorlist)
        {
            Id = id;
            RemiseId = remise_id;
            Number = number;
            Sectors = sectors;
            Available = available;
            EntryDepartTrack = entrydeparttrack;
            SectorList = sectorlist;
        }
        public Track(int remiseid, int number, int sectors, bool available, bool entrydeparttrack, List<Sector> sectorlist)
        {
            RemiseId = remiseid;
            Number = number;
            Sectors = sectors;
            Available = available;
            EntryDepartTrack = entrydeparttrack;
            SectorList = sectorlist;
        }
    }
}
