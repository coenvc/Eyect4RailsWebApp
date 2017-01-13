using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eyect4RailsWebApp.IRepository;
using Eyect4RailsWebApp.Models;
using Microsoft.Ajax.Utilities;

namespace Eyect4RailsWebApp.Context
{
    public class SectorContext : ISectorRepository
    {
        private ISectorRepository Context;

        public SectorContext(ISectorRepository context)
        {
            this.Context = context;
        }

        public List<Sector> GetByTrackId(int id)
        {
            return Context.GetByTrackId(id);
        }

        public Sector GetByTramId(int id)
        {
            return Context.GetByTramId(id);
        }



        public bool Insert(Sector entity)
        {
            return Context.Insert(entity);
        }

        public void Update(int id, Sector entity)
        {
            Context.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return Context.Delete(id);
        }

        public Sector GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Sector> GetAll()
        {
            return Context.GetAll();
        }

        public int MaximalSectorNumber(int trackId)
        {
            return Context.MaximalSectorNumber(trackId);
        }

        public int MinimalSectorNumber(int trackId)
        {
            return Context.MinimalSectorNumber(trackId);
        }

        public void UpdateAssignTramSectors(int trackId, int sectorNumber, int tramid)
        {
            Context.UpdateAssignTramSectors(trackId, sectorNumber, tramid);
        }
        } 

    }
