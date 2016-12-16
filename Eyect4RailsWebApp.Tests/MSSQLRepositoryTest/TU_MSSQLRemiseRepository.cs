using System;
using System.Collections.Generic;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eyect4RailsWebApp.Tests.MSSQLRepositoryTest
{
    [TestClass]
    public class TU_MSSQLRemiseRepository
    {
        [TestMethod]
        public void tu_MSSQLRemise_CreateObjectFromReader()
        {
            // arrange
            RemiseContext context = new RemiseContext(new MSSQLRemiseRepository());
            Remise remise;

            // act
            remise = context.GetById(1);

            // assert
            Assert.AreEqual("Remise Havenstraat", remise.Name);
            Assert.AreNotEqual(0, remise.Tramlist.Count);
            Assert.AreNotEqual(0, remise.Tracklist.Count);

            Assert.AreNotEqual(-1, remise.Id);
        }

        [TestMethod]
        public void tu_MSSQLRemise_Insert()
        {
            // arrange
            RemiseContext context = new RemiseContext(new MSSQLRemiseRepository());
            List<Remise> remises;
            List<Track> tracks;
            List<Tram> trams;
            Remise remise;
            Remise verifyRemise;

            // act
            tracks = new List<Track>();
            trams = new List<Tram>();

            remise = new Remise("Havenstraat Schiermonnikoog", tracks, trams);

            context.Insert(remise);

            remises = context.GetAll();
            verifyRemise = remises[remises.Count - 1];
            
            // assert
            Assert.AreEqual(remise.Name, verifyRemise.Name);
        }

        [TestMethod]
        public void tu_MSSQLRemise_Update()
        {
            // arrange
            RemiseContext context = new RemiseContext(new MSSQLRemiseRepository());
            List<Remise> remises;
            Remise remise;
            Remise verifyRemise;

            // act
            remises = context.GetAll();
            remise = remises[remises.Count - 1];

            remise.Name = "Remise Schiermonnikoog";

            context.Update(remise.Id, remise);

            remises = context.GetAll();
            verifyRemise = remises[remises.Count - 1];

            // assert
            Assert.AreEqual(remise.Name, verifyRemise.Name);
            Assert.AreNotEqual("Havenstraat Schiermonnikoog", verifyRemise.Name);
        }

        [TestMethod]
        public void tu_MSSQLRemise_Delete()
        {
            // arrange
            RemiseContext context = new RemiseContext(new MSSQLRemiseRepository());
            List<Remise> remises;
            Remise remise;
            Remise verifyRemise;

            // act
            remises = context.GetAll();
            remise = remises[remises.Count - 1];

            context.Delete(remise.Id);

            remises = context.GetAll();
            verifyRemise = remises[remises.Count - 1];
            
            // assert
            Assert.AreNotEqual(remise.Id, verifyRemise.Id);
            Assert.AreNotEqual(remise.Name, verifyRemise.Name);
        }
    }
}
