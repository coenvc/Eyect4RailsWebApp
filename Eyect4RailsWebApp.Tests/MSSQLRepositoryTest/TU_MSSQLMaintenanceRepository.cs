using System;
using System.Collections.Generic;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eyect4RailsWebApp.Tests.MSSQLRepositoryTest
{
    [TestClass]
    public class TU_MSSQLMaintenanceRepository
    {
        [TestMethod]
        public void tu_MSSQLMaintenance_CreateObjectFromReader()
        {
            // arrange
            MSSQLMaintenanceRepository Repository = new MSSQLMaintenanceRepository();
            Maintenance maintenance;

            //act
            maintenance = Repository.GetAll()[0];

            //assert
            Assert.AreEqual(1, maintenance.Employee.Id, "Employee is not picked up correctly");
            Assert.AreEqual(1, maintenance.Tram.Id, "Tram is not picked up correctly");
            Assert.AreEqual(new DateTime(2016, 12, 12, 08, 00, 00), maintenance.ScheduledDate);
            Assert.AreEqual(new DateTime(2016, 12, 12, 12, 00, 00), maintenance.AvailableDate);
            Assert.AreEqual(1, maintenance.TaskID);
            Assert.AreEqual("Kleine Schoonmaak", maintenance.Task, "Task description is not picked up correctly");
        }
    }
}
