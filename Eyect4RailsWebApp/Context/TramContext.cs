using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;

namespace Eyect4RailsWebApp.Context
{
    public class TramContext:ITramRepository
    {
        private ITramRepository Context;

        public TramContext(ITramRepository context)
        {
            Context = context;
        }

        public bool Insert(Tram entity)
        {
            return Context.Insert(entity);
        }

        public void Update(int id, Tram entity)
        {
            Context.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return Context.Delete(id);
        }

        public Tram GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Tram> GetAll()
        {
            return Context.GetAll();
        }

        public Tram GetBySectorId(int id)
        {
            return Context.GetBySectorId(id);
        }
    }
}