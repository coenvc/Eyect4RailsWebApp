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
        public bool Completed { get; set; }
        public int TaskID { get; set; }
        public string Task { get; set; }

        public Maintenance()
        {
            
        }

        public Maintenance(Employee employee, Tram tram, DateTime scheduledDate, DateTime availableDate, bool completed, int taskId, string task)
        {
            Employee = employee;
            Tram = tram;
            ScheduledDate = scheduledDate;
            AvailableDate = availableDate;
            Completed = completed;
            TaskID = taskId;
            Task = task;
        }

        public Maintenance(int id, Employee employee, Tram tram, DateTime scheduledDate, DateTime availableDate, bool completed, int taskId, string task)
        {
            Id = id;
            Employee = employee;
            Tram = tram;
            ScheduledDate = scheduledDate;
            AvailableDate = availableDate;
            Completed = completed;
            TaskID = taskId;
            Task = task;
        }
    }
}
