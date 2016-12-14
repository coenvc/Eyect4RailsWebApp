using System;
using System.Collections.Generic;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Context;
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
            MaintenanceContext context = new MaintenanceContext(new MSSQLMaintenanceRepository());
            Maintenance maintenance0;
            Maintenance maintenance1;

            //act
            maintenance0 = context.GetById(0);
            maintenance1 = context.GetById(1);

            //assert
            Assert.AreEqual(1, maintenance0.Employee.Id, "Employee is not picked up correctly");
            Assert.AreEqual(1, maintenance0.Tram.Id, "Tram is not picked up correctly");
            Assert.AreEqual(new DateTime(2016, 12, 12, 08, 00, 00), maintenance0.ScheduledDate);
            Assert.AreEqual(new DateTime(2016, 12, 12, 12, 00, 00), maintenance0.AvailableDate);
            Assert.AreEqual(1, maintenance0.TaskID);
            Assert.AreEqual("Kleine Schoonmaak", maintenance0.Task, "Task description is not picked up correctly");

            Assert.AreEqual(DateTime.MaxValue, maintenance1.AvailableDate);
        }

        [TestMethod]
        public void tu_MSSQLMaintenance_Insert()
        {
            
        }
    }
}
