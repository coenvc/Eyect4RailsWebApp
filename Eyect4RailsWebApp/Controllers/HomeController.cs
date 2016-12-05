using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;

namespace Eyect4RailsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Employee Employee = new Employee("van Campenhout", "coen", "0683992086", "12345678", "coenvc", "Test123", "123456", true, Enums.Function.Bestuurder, new List<Enums.Rights>() {Enums.Rights.SporenBlokkeren});
            EmployeeContext ctx = new EmployeeContext(new MSSQLEmployeeRepository());
            ctx.Insert(Employee);
            ctx.Update(1, Employee);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
