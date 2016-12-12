using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Interfaces;

namespace Eyect4RailsWebApp.Models
{
    public class Sector : ICruddable
    {
        private static int SectorCounter;

        #region Properties
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int TramId { get; set; }
        public int Number { get; set; }
        public bool Available { get; set; }
        public bool Blocked { get; set; }
        #endregion

        public Sector()
        {

        }

        public Sector(int trackId, int tramId, int number, bool available, bool blocked)
        {
            TrackId = trackId;
            TramId = tramId;
            Number = number;
            Available = available;
            Blocked = blocked;
        }

        public Sector(int id, int trackId, int tramId, int number, bool available, bool blocked)
        {
            Id = id;
            TrackId = trackId;
            TramId = tramId;
            Number = number;
            Available = available;
            Blocked = blocked;
        }
    }

}