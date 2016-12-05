using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;

namespace Eyect4RailsWebApp.Models
{
    public class Sector
    { 
        Tram Tram { get; set; }

        public Sector(Tram tram)
        {
            Tram = tram;
        }
    }
}