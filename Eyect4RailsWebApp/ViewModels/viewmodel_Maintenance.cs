using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.ViewModels
{
    public class viewmodel_Maintenance
    {
        public Maintenance Maintenance { get; set; }
        public int SelectedId_Employee { get; set; }
        public List<Employee> Employees { get; set; }
        public int SelectedId_Tram { get; set; }
        public List<Tram> Trams { get; set; }
        public int SelectedId_Task { get; set; }
        public Tasks Tasks { get; set; }

        public viewmodel_Maintenance()
        {
        }

        public viewmodel_Maintenance(Maintenance maintenance, List<Employee> employees, List<Tram> trams)
        {
            Maintenance = maintenance;
            Employees = employees;
            Trams = trams;
            Tasks = new Tasks();
        }
    }
}