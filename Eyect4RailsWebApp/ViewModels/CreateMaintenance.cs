﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.ViewModels
{
    public class CreateMaintenance
    {
        public Maintenance Maintenance { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Tram> Trams { get; set; }
        public Dictionary<int, string> TasksDictionary { get; set; }

        public CreateMaintenance()
        {
        }

        public CreateMaintenance(List<Employee> employees, List<Tram> trams, Dictionary<int, string> tasksDictionary)
        {
            Maintenance = new Maintenance();
            Employees = employees;
            Trams = trams;
            TasksDictionary = tasksDictionary;
        }
    }
}