using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;

namespace Eyect4RailsWebApp.Context
{
    public class TrackContext : ITrackRepository
    {
        private ITrackRepository Context;

        public TrackContext(ITrackRepository context)
        {
            Context = context;
        }

        public bool Delete(int id)
        {
            return Context.Delete(id);
        }

        public List<Track> GetAll()
        {
            return Context.GetAll();
        }

        public Track GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Track> GetByRemiseId(int remiseid)
        {
            return Context.GetByRemiseId(remiseid);
        }

        public bool Insert(Track entity)
        {
            return Context.Insert(entity);
        }

        public bool Insert(Remise remise, Track track)
        {
            return Context.Insert(remise, track);
        }

        public void Update(int id, Track entity)
        {
            Context.Update(id, entity);
        }
    }
}