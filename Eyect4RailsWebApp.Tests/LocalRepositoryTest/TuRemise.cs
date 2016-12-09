using System;
using System.Collections.Generic;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Repositories.LocalRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eyect4RailsWebApp.Tests.LocalRepositoryTest
{
    [TestClass]
    public class TuRemise
    {
        private Context.RemiseContext Context = new RemiseContext(new LocalRemiseRepository());

        [TestMethod]
        public bool Insert(Remise entity)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Update(int id, Remise entity)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public Remise GetById(int id)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public List<Remise> GetAll()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public Remise GetByRemiseName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
