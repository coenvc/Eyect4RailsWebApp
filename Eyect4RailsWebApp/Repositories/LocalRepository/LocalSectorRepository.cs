using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.IRepository;
using Eyect4RailsWebApp.Models;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.LocalRepository
{
    public class LocalSectorRepository : ISectorRepository
    {
        private LocalCrud<Sector> crud;
        private LocalCrud<Track> trackCrud;

        public LocalSectorRepository()
        {
            crud = new LocalCrud<Sector>();
            trackCrud = new LocalCrud<Track>();

            Sector sector = new Sector(1, 2, 1, false, true);
            Sector sector1 = new Sector(1, 3, 2, true, false);
            Sector sector2 = new Sector(2, 4, 3, true, false);
            Sector sector3 = new Sector(2, 5, 4, false, false);
            Sector sector4 = new Sector(3, 6, 5, false, true);
            Sector sector5 = new Sector(3, 7, 6, true, true);
            Sector sector6 = new Sector(4, 8, 7, true, false);
            Sector sector7 = new Sector(4, 9, 8, false, true);
            Sector sector8 = new Sector(5, 10, 9, false, false);
            Sector sector9 = new Sector(5, 11, 10, true, true);

            Insert(sector);
            Insert(sector1);
            Insert(sector2);
            Insert(sector3);
            Insert(sector4);
            Insert(sector5);
            Insert(sector6);
            Insert(sector7);
            Insert(sector8);
            Insert(sector9);
        }

        public bool Delete(int id)
        {
            return crud.Delete(id);
        }

        public List<Sector> GetAll()
        {
            return crud.GetAll();
        }

        public Sector GetById(int id)
        {
            return crud.GetById(id);
        }

        public List<Sector> GetByTrackId(int id)
        {
            return trackCrud.GetById(id).SectorList;
        }

        public Sector GetByTramId(int id)
        {
            var emptySector = new Sector();
            var sectors = new List<Sector>();

            sectors = crud.GetAll();

            foreach (Sector sector in sectors)
            {
                if (sector.TramId == id)
                {
                    return sector;
                }
            }

            return emptySector;
        }


        public bool Insert(Sector entity)
        {
            return crud.Insert(entity);
        }

        public int MaximalSectorNumber(int trackId)
        {
            throw new NotImplementedException();
        }

        public int MinimalSectorNumber(int trackId)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Sector entity)
        {
            crud.Update(id, entity);
        }

        public void UpdateAssignTramSectors(int trackId, int sectorNumber, int tramid)
        {
            throw new NotImplementedException();
        }
    }
}

