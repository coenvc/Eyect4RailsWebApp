using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;

namespace Eyect4RailsWebApp.ViewModels
{
    public class AssignMaintenanceToEmployee
    {
        public Maintenance Maintenance { get; set; }
        public List<Employee> Employees { get; set; }

        public AssignMaintenanceToEmployee(Maintenance maintenance, List<Employee> employees)
        {
            Maintenance = maintenance;
            Employees = employees;
        }
    }
}