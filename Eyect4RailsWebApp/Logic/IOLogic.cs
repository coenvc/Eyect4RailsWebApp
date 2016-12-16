using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;

namespace Eyect4RailsWebApp.Logic
{
    public class IOLogic:ITramRepository
    {
        TramContext Tram = new TramContext(new MSSQLTramRepository());


        public bool Insert(Tram entity)
        {
            return Tram.Insert(entity);
        }

        public void Update(int id, Tram entity)
        {
            Tram.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return Tram.Delete(id);
        }
        public Tram GetById(int id)
        {
            return Tram.GetById(id);
        }

        public List<Tram> GetAll()
        {
            return Tram.GetAll();
        }

        public Tram GetBySectorId(int id)
        {
            return Tram.GetBySectorId(id);
        }

        public List<Tram> GetByRemiseId(int id)
        {
            throw new NotImplementedException();
        }
    }
}