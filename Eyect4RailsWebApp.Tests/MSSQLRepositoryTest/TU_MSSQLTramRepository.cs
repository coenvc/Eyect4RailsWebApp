using System;
using System.Collections.Generic;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eyect4RailsWebApp.Tests.MSSQLRepositoryTest
{
    [TestClass]
    public class TU_MSSQLTramRepository
    {
        [TestMethod]
        public void TestGetBySectorId()
        {
            // arrange
            var mssqlTramRepository = new MSSQLTramRepository();
            var testTram = new Tram();
            var tram = new Tram();

            // act
            testTram.Id = 1;
            tram = mssqlTramRepository.GetById(1);

            // assert
            Assert.AreEqual(testTram.Id, tram.Id);
        }

        [TestMethod]
        public void TestInsert()
        {
            // arrange
            var mssqlTramRepository = new MSSQLTramRepository();
            var tram = new Tram(1, TramType.TwelveG, 150210, 2, true, true, true, true);
            bool inserted;

            // act
            inserted = mssqlTramRepository.Insert(tram);

            // assert
            Assert.AreEqual(true, inserted);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // arrange
            var mssqlTramRepository = new MSSQLTramRepository();
            var tram = new Tram(215, 2, TramType.ElevenG, 123456, 1, true, false, true, false);
            var getTram = new Tram();

            // act
            mssqlTramRepository.Update(tram.Id, tram);
            getTram = mssqlTramRepository.GetById(tram.Id);

            // assert
            Assert.AreEqual(getTram.TramNumber, tram.TramNumber);
        }

        [TestMethod]
        public void TestDelete()
        {
            // arrange
            var mssqlTramRepository = new MSSQLTramRepository();
            var tram = new Tram();
            bool deleted;

            // act
            deleted = mssqlTramRepository.Delete(216);

            // assert
            Assert.AreEqual(true, deleted);
        }

        [TestMethod]
        public void TestGetById()
        {
            // arrange
            var mssqlTramRepository = new MSSQLTramRepository();
            var testTram = new Tram();
            var tram = new Tram();

            // act
            testTram.Id = 2000;
            tram = mssqlTramRepository.GetById(1);

            // assert
            Assert.AreNotEqual(testTram.Id, tram.Id);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // arrange
            var mssqlTramRepository = new MSSQLTramRepository();
            var trams = new List<Tram>();
            var emptyTrams = new List<Tram>();

            // act
            trams = mssqlTramRepository.GetAll();

            // assert
            Assert.AreNotEqual(emptyTrams.Count, trams.Count);
        }

        [TestMethod]
        public void TestGetByRemiseId()
        {
            // arrange
            var mssqlTramRepository = new MSSQLTramRepository();
            var trams = new List<Tram>();
            var emptyTrams = new List<Tram>();

            // act
            trams = mssqlTramRepository.GetByRemiseId(1);

            // assert
            Assert.AreNotEqual(emptyTrams.Count, trams.Count);
        }

        [TestMethod]
        public void TestTramIdBySectorId()
        {
            // arrange
            var mssqlTramRepository = new MSSQLTramRepository();
            var testTram = new Tram();
            var tram = new Tram();

            // act
            tram = mssqlTramRepository.GetBySectorId(6);
            testTram.Id = 123456789;

            // assert
            Assert.AreNotEqual(testTram.Id, tram.Id);
        }

        [TestMethod]

        public void TestAssigntram()
        {
            IOLogic logic = new IOLogic();

            int number = logic.AssignTramToSector(77);
            int number2 = 0;

            Assert.AreNotEqual(number2, number);


        }

        //[TestMethod]
        //public void testremisetracks()
        //{
        //    MSSQLTrackRepository mssqlTrackRepository = new MSSQLTrackRepository();
        //    List<Track> tracks = new List<Track>();
        //    List<Track> targetTracks = new List<Track>();

        //    targetTracks = mssqlTrackRepository.GetAvailableByRemiseId(1);

        //    Assert.AreNotEqual(tracks.Count, targetTracks.Count);

        //}
    }
}
