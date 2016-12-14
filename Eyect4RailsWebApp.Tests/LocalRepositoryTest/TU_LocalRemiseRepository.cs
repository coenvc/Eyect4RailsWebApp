using System;
using System.Collections.Generic;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Repositories.LocalRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eyect4RailsWebApp.Tests.LocalRepositoryTest
{
    [TestClass]
    public class TU_LocalRemiseRepository
    {
        private RemiseContext Context = new RemiseContext(new LocalRemiseRepository());

        [TestMethod]
        public bool Test()
        {
            throw new NotImplementedException();
        }
        
    }
}
