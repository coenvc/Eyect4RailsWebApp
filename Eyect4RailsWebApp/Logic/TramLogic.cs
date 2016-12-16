using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.IRepository;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;

namespace Eyect4RailsWebApp.Logic
{
    public class TramLogic: ITramRepository
    {
       private TramContext tram = new TramContext(new MSSQLTramRepository());

        public bool Delete(int id)
        {
           return tram.Delete(id);
        }

        public List<Tram> GetAll()
        {
            return tram.GetAll();
        }

        public Tram GetById(int id)
        {
            return tram.GetById(id);
        }

        public List<Tram> GetByRemiseId(int id)
        {
            return tram.GetByRemiseId(id);
        }

        public Tram GetBySectorId(int id)
        {
            return tram.GetBySectorId(id);
        }

        public bool Insert(Tram entity)
        {
            return tram.Insert(entity);
        }

        public void Update(int id, Tram entity)
        {
            tram.Update(id, entity);
        }
    }
}