using System;
using System.Collections.Generic;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eyect4RailsWebApp.Tests.MSSQLRepositoryTest
{
    [TestClass]
    public class TU_MSSQLSectorRepository
    {
        [TestMethod]
        public void TestGetAll()
        {
            // arrange
            var emptySectors = new List<Sector>();
            var sectors = new List<Sector>();
            var mssqlSectorRepository = new MSSQLSectorRepository();

            // act
            sectors = mssqlSectorRepository.GetAll();

            //assert
            Assert.AreNotEqual(emptySectors.Count, sectors.Count);
        }

        [TestMethod]
        public void TestDelete()
        {
            // arrange 
            var mssqlSectorRepository = new MSSQLSectorRepository();
            var sector = new Sector();
            bool deleted;

            // act 
            deleted = mssqlSectorRepository.Delete(2);

            // assert
            Assert.AreEqual(true, deleted);
        }

        [TestMethod]
        public void TestGetById()
        {
            // arrange
            var mssqlSectorRepository = new MSSQLSectorRepository();
            var testSector = new Sector();
            var sector = new Sector();

            // act 
            testSector.Id = 2000;
            sector = mssqlSectorRepository.GetById(2);

            // assert 
            Assert.AreNotEqual(testSector.Id, sector.Id);
        }

        [TestMethod]
        public void TestGetByTrackId()
        {
            // arrange
            var mssqlSectorRepository = new MSSQLSectorRepository();
            var emptySectorList = new List<Sector>();
            var sectorList = new List<Sector>();

            // act 
            sectorList = mssqlSectorRepository.GetByTrackId(1);

            // assert
            Assert.AreNotEqual(emptySectorList.Count, sectorList.Count);
        }

        [TestMethod]
        public void TestGetByTramId()
        {
            // arrange
            var mssqlSectorRepository = new MSSQLSectorRepository();
            var testSector = new Sector();
            var sector = new Sector();

            // act
            testSector.TramId = 1000;
            sector = mssqlSectorRepository.GetByTramId(2);

            // assert
            Assert.AreNotEqual(testSector.TramId, sector.TramId);
        }

        [TestMethod]
        public void TestInsert()
        {
            // arrange
            var mssqlSectorRepository = new MSSQLSectorRepository();
            var sector = new Sector(1, 1000, 1, true, false);
            bool inserted;

            // act
            inserted = mssqlSectorRepository.Insert(sector);

            // assert
            Assert.AreEqual(true, inserted);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // arrange
            var mssqlSectorRepository = new MSSQLSectorRepository();
            var sector = new Sector(6, 3, 3, 10, false, true);
            var getSector = new Sector();

            // act
            mssqlSectorRepository.Update(sector.Id, sector);
            getSector = mssqlSectorRepository.GetById(sector.Id);

            // assert
            Assert.AreEqual(getSector.Available, sector.Available);
        }

        [TestMethod]
        public void TestMin()
        {
            // Arrange
            var mssqlSectorRepository = new MSSQLSectorRepository();
            int nummer = -1;
            int targetNummer;

            // Act 
            targetNummer = mssqlSectorRepository.MinimalSectorNumber(1);

            // Assert
            Assert.AreNotEqual(nummer, targetNummer);
        }

        [TestMethod]
        public void TestMax()
        {
            // Arrange
            var mssqlSectorRepository = new MSSQLSectorRepository();
            int nummer = 0;
            int targetNummer;

            // Act 
            targetNummer = mssqlSectorRepository.MaximalSectorNumber(1);

            // Assert
            Assert.AreNotEqual(nummer, targetNummer);
        }
    }
}
