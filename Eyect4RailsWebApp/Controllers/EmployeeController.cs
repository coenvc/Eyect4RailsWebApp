using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Logic;

namespace Eyect4RailsWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeLogic EmployeeLogic = new EmployeeLogic();
        // GET: Employee 
        [HttpGet]
        public ActionResult Index()
        {
            List<Employee> Employees = EmployeeLogic.GetAll();

            return View(Employees);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee Employee = EmployeeLogic.GetById(id);

            return View(Employee);
        } 
        
    }
}