using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Logic;

namespace Eyect4RailsWebApp.Controllers
{
    public class AuthController : Controller
    {
        private EmployeeLogic Logic = new EmployeeLogic();
        
        // GET: Auth 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            string username = employee.Username;
            string password = employee.Password;
            try{
                Session["LoggedInEmployee"] = Logic.Login(username, password); 
                return RedirectToAction("Index", "Employee");  
            }
            catch (Exception ex)
            {
                return View();
            }
        } 
    }
}