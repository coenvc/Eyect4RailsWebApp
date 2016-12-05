using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Interfaces;

namespace Eyect4RailsWebApp.Models
{
<<<<<<< HEAD
    public class Sector
    {
        private static int SectorCounter;
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int TramId { get; set; }
        public int Number { get; set; }
        public bool Available { get; set; }
        public bool Blocked { get; set; }
=======
    public class Sector:ICruddable
    {
        public int Id { get; set; }
        Tram Tram { get; set; }
>>>>>>> 8d71a072f789061c1a79e2907ad1994f0df5811e

        public Sector(int id, int trackid, int tramid, int number, bool available, bool blocked)
        {
            this.Id = id;
            this.TrackId = trackid;
            this.TramId = tramid;
            this.Number = number;
            this.Available = available;
            this.Blocked = blocked;
        }

        public Sector(int trackid, int tramid, int number, bool available, bool blocked)
        {
            this.Id = SectorCounter;
            this.TrackId = trackid;
            this.TramId = tramid;
            this.Number = number;
            this.Available = available;
            this.Blocked = blocked;
            SectorCounter++;
        }


    }
}