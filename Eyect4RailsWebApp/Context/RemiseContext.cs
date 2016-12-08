using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;

namespace Eyect4RailsWebApp.Context
{
    public class RemiseContext:IRemiseRepository
    {
        private IRemiseRepository Context;

        public RemiseContext(IRemiseRepository context)
        {
            Context = context;
        }

        public bool Insert(Remise entity)
        {
            return Context.Insert(entity);
        }

        public void Update(int id, Remise entity)
        {
            Context.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return Context.Delete(id);
        }

        public Remise GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Remise> GetAll()
        {
            return Context.GetAll();
        }

        public Remise GetByRemiseName(string name)
        {
            return Context.GetByRemiseName(name);
        }
    }
}