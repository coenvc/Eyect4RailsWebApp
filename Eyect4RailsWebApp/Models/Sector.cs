using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Interfaces;

namespace Eyect4RailsWebApp.Models
{
    public class Sector:ICruddable
    {
        public int Id { get; set; }
        Tram Tram { get; set; }

        public Sector(Tram tram)
        {
            Tram = tram;
        }


    }
}