using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;

namespace Eyect4RailsWebApp.Logic
{
    public class TrackLogic:ITrackRepository
    {
        private TrackContext Context = new TrackContext(new MSSQLTrackRepository());
        public bool Insert(Track entity)
        {
            return Context.Insert(entity);
        }

        public void Update(int id, Track entity)
        {
            Context.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return Context.Delete(id);
        }

        public Track GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Track> GetAll()
        {
            return Context.GetAll();
        }

        public List<Track> GetByRemiseId(int remiseid)
        {
            return Context.GetByRemiseId(remiseid);
        }

        public bool Insert(Remise remise, Track track)
        {
            return Context.Insert(remise, track);
        }
    }
}