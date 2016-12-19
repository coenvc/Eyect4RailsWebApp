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

        [HttpPost]
        [ActionName("Details")]
        public ActionResult DetailsPost(int id)
        {
            Employee Employee = EmployeeLogic.GetById(id);

            return View(Employee);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        { 
            return View(EmployeeLogic.GetById(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Employee employee)
        {
            EmployeeLogic.Update(employee.Id, employee);
            return RedirectToAction("Details","Employee",employee.Id);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeLogic.Insert(employee);
            return RedirectToAction("Index");
        }
    }
}