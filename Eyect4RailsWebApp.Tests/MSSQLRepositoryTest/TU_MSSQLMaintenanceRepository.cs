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
            // arrane
            MaintenanceContext context = new MaintenanceContext(new MSSQLMaintenanceRepository());
            EmployeeContext employeeContext = new EmployeeContext(new MSSQLEmployeeRepository());
            TramContext tramContext = new TramContext(new MSSQLTramRepository());

            Maintenance maintenance;
            Maintenance verifyMaintenance;
            Employee employee;
            Tram tram;

            List<Maintenance> maintenances;

            // act
            employee = employeeContext.GetById(1);
            tram = tramContext.GetById(1);
            maintenance = new Maintenance(employee, tram, new DateTime(2016, 12, 14, 16, 06, 01), DateTime.MaxValue, false, 1, "Grote Schoonmaak");

            context.Insert(maintenance);

            maintenances = context.GetAll();
            verifyMaintenance = maintenances[maintenances.Count - 1];

            // assert
            Assert.AreEqual(verifyMaintenance.Employee.Id, maintenance.Employee.Id);
            Assert.AreEqual(verifyMaintenance.Tram.Id, maintenance.Tram.Id);
            Assert.AreEqual(verifyMaintenance.AvailableDate, maintenance.AvailableDate);
        }
        
        [TestMethod]
        public void tu_MSSQLMaintenance_Update()
        {
            // arrane
            MaintenanceContext context = new MaintenanceContext(new MSSQLMaintenanceRepository());
            List<Maintenance> maintenances;
            Maintenance maintenance;
            Maintenance verifyMaintenance;

            // act
            maintenances = context.GetAll();
            maintenance = maintenances[maintenances.Count - 1];

            maintenance.Employee.Id = 3;
            maintenance.Tram.Id = 3;
            maintenance.ScheduledDate = new DateTime(2016, 12, 14, 12, 00, 00);

            context.Update(maintenance.Id, maintenance);

            maintenances = context.GetAll();
            verifyMaintenance = maintenances[maintenances.Count - 1];

            // assert
            Assert.AreEqual(new DateTime(2016, 12, 14, 12, 00, 00), maintenance.ScheduledDate);
            Assert.AreEqual(3, verifyMaintenance.Employee.Id);
            Assert.AreEqual(3, verifyMaintenance.Tram.Id);

            Assert.AreNotEqual(new DateTime(2016, 12, 14, 16, 06, 01), verifyMaintenance.ScheduledDate);
            Assert.AreNotEqual(1, verifyMaintenance.Employee.Id);
            Assert.AreNotEqual(1, verifyMaintenance.Tram.Id);

        }

        [TestMethod]
        public void tu_MSSQLMaintenance_Delete()
        {
            // arrane
            MaintenanceContext context = new MaintenanceContext(new MSSQLMaintenanceRepository());
            List<Maintenance> maintenances;
            Maintenance maintenance;
            Maintenance verifyMaintenance;

            // act
            maintenances = context.GetAll();
            maintenance = maintenances[maintenances.Count - 1];

            context.Delete(maintenance.Id);

            verifyMaintenance = context.GetById(maintenance.Id);

            // assert
            Assert.AreEqual(-1, verifyMaintenance.Id);
        }
    }
}
