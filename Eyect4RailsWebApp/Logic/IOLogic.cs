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


        public int AssignTramToSector(int tramId)
        {
            var tracklist = Track.GetAvailableByRemiseId(1);
            Tram tram = Tram.GetById(tramId);

            int sectorMinNumber;
            int sectorMaxNumber;
            int availableConnectingSectors;

            int sectorPlaceNumber;
            int firstSectorPlaceNumber;

            foreach (Track track in tracklist)
            {
                sectorMaxNumber = Sector.MaximalSectorNumber(track.Id);
                sectorMinNumber = Sector.MinimalSectorNumber(track.Id);
                availableConnectingSectors = sectorMaxNumber - sectorMinNumber;
                sectorPlaceNumber = sectorMinNumber + 1;
                firstSectorPlaceNumber = sectorMinNumber + 1;

                if (PerfectParking(tram, availableConnectingSectors))
                {
                    for (int sectornummer = tram.Length; sectornummer > 0; sectornummer--)
                    {
                         Sector.UpdateAssignTramSectors(track.Id, sectorPlaceNumber, tram.Id);
                        sectorPlaceNumber++;
                    }

                    return firstSectorPlaceNumber;

                }

                else if (ParkTram(tram, availableConnectingSectors))
                {
                    for (int sectornummer = tram.Length; sectornummer > 0; sectornummer--)
                    {
                        Sector.UpdateAssignTramSectors(track.Id, sectorPlaceNumber, tram.Id);
                        sectorPlaceNumber++;
                    }

                    return firstSectorPlaceNumber;
                }
            }

            return -1;


        }

        private bool ParkTram(Tram tram, int availableConnectingSectors)
        {
            if (tram.Length <= availableConnectingSectors)
            {
                return true;
            }

            return false;
        }

        private bool PerfectParking(Tram tram, int availableConnectingSectors)
        {
            if (tram.Length == availableConnectingSectors)
            {
                return true;
            }

            return false;
        }
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

<<<<<<< HEAD
        public int GetHighestSector(int id)
        {
            return Tram.GetHighestSector(id);
        }

=======
        public List<Tram> GetNotParkedTrams()
        {
            throw new NotImplementedException();
        }

        //public int GetHighestSector(int id)
        //{
        //    return Tram.GetHighestSector(id);
        //}
>>>>>>> def2af0de5d0716dd472d2a8fdf1629471e08cfa
    }
}