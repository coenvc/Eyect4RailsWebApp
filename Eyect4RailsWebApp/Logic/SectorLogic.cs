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
    public class SectorLogic : ISectorRepository
    {
         SectorContext sector = new SectorContext(new MSSQLSectorRepository());
        public bool Delete(int id)
        {
            return sector.Delete(id);
        }

        public List<Sector> GetAll()
        {
            return sector.GetAll();
        }

        public Sector GetById(int id)
        {
            return sector.GetById(id);
        }

        public List<Sector> GetByTrackId(int id)
        {
            return sector.GetByTrackId(id);
        }

        public Sector GetByTramId(int id)
        {
            return sector.GetByTramId(id);
        }



        public bool Insert(Sector entity)
        {
            return sector.Insert(entity);
        }

        public void Update(int id, Sector entity)
        {
            sector.Update(id, entity);
        }
    }
}