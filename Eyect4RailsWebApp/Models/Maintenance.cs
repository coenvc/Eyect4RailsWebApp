using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eyect4RailsWebApp.Interfaces;

namespace eyect4rails.Classes
{
    public class Maintenance:ICruddable
    {
        public int Id { get; set; } 
        public Employee Employee { get; set; } 
        public Tram Tram { get; set; } 
        public DateTime ScheduledDate { get; set; } 
        public DateTime AvailableDate { get; set; } 
        
    }
}
