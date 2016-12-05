using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eyect4RailsWebApp.Interfaces;
using Eyect4RailsWebApp.Enums;
namespace eyect4rails.Classes
{
    public class Maintenance:ICruddable
    {
        public int Id { get; set; } 
        public Employee Employee { get; set; } 
        public Tram Tram { get; set; } 
        public DateTime ScheduledDate { get; set; } 
        public DateTime AvailableDate { get; set; } 
        public Tasks TaskType { get; set; }
        public bool Completed { get; set; } = false;

        public Maintenance(int id, Employee employee, Tram tram, DateTime scheduledDate, DateTime availableDate, Tasks taskType)
        {
            Id = id;
            Employee = employee;
            Tram = tram;
            ScheduledDate = scheduledDate;
            AvailableDate = availableDate;
            TaskType = taskType;
        }

        public Maintenance(Employee employee, Tram tram, DateTime scheduledDate, DateTime availableDate, Tasks taskType)
        {
            Employee = employee;
            Tram = tram;
            ScheduledDate = scheduledDate;
            AvailableDate = availableDate;
            TaskType = taskType;
        }

        public Maintenance()
        {
            
        }
    }
}
