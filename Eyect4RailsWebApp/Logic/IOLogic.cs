using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;
using Eyect4RailsWebApp.ViewModels;

namespace Eyect4RailsWebApp.Logic
{
    public class IOLogic:ITramRepository
    {
        TramContext Tram = new TramContext(new MSSQLTramRepository());
        SectorContext Sector = new SectorContext(new MSSQLSectorRepository());
        TrackContext Track = new TrackContext(new MSSQLTrackRepository());
        RemiseContext Remise = new RemiseContext(new MSSQLRemiseRepository());


        public CreateEditTramViewModel GetCETViewModel(int remiseId)
        {
            var CETViewModel = new CreateEditTramViewModel();
            CETViewModel.Trams = Tram.GetByRemiseId(remiseId);
            CETViewModel.Tracks = Track.GetByRemiseId(remiseId);
            CETViewModel.Remises = Remise.GetAll();


            foreach (Track track in CETViewModel.Tracks)
            {
                foreach (Sector sector in track.SectorList)
                {
                    CETViewModel.Sectors.Add(sector);
                }
            }

            return CETViewModel;

        }


        //public int AssignTramToSector(int tramId)
        //{
        //    var tracklist = Track.GetByRemiseId(1);
        //    int trackId = 0;

        //    foreach (Track track in tracklist)
        //    {
        //        if (Tram.GetHighestSector(track.Id) > 0)
        //        {
        //            var sector = Sector.GetById(Tram.GetHighestSector(track.Id));
        //            sector.Available = false;
        //            sector.TramId = tramId;
        //            Sector.Update(sector.Id, sector);
        //            return track.Id;
        //        }
        //    }

        //    return trackId;
        //}
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
            return Tram.GetByRemiseId(id);
        }

        //public int GetHighestSector(int id)
        //{
        //    return Tram.GetHighestSector(id);
        //}
    }
}