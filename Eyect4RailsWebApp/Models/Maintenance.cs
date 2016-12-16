using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Eyect4RailsWebApp.Interfaces;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Models;

namespace eyect4rails.Classes
{
    public class Maintenance : ICruddable
    {
        #region Properties
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public Employee Employee { get; set; }

        [Required(ErrorMessage = "A task has to be assigned to a Tram. Tram is required.")]
        public Tram Tram { get; set; }

        [DisplayName("Scheduled to be completed at"),
            Required(ErrorMessage = "A task needs a scheduled date. Scheduled Date is required.")]
        public DateTime ScheduledDate { get; set; }

        [DisplayName("Completed at")]
        public DateTime AvailableDate { get; set; }

        public bool Completed { get; set; }

        public Tasks Task { get; set; }
        
        //[Editable(false)]
        //public int TaskID { get; set; }

        //public string Task { get; set; }
        #endregion

        public Maintenance()
        {

        }

        public Maintenance(Employee employee, Tram tram, DateTime scheduledDate, DateTime availableDate, bool completed, Tasks task)
        {
            Employee = employee;
            Tram = tram;
            ScheduledDate = scheduledDate;
            AvailableDate = availableDate;
            Completed = completed;
            this.Task = task;
        }

        public Maintenance(int id, Employee employee, Tram tram, DateTime scheduledDate, DateTime availableDate, bool completed, Tasks task)
        {
            Id = id;
            Employee = employee;
            Tram = tram;
            ScheduledDate = scheduledDate;
            AvailableDate = availableDate;
            Completed = completed;
            this.Task = task;
        }
    }
}
