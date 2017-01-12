using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.LocalRepository
{
    public class LocalRemiseRepository : IRemiseRepository
    {
        private LocalCrud<Remise> Crud;

        private LocalTramRepository tramRepository = new LocalTramRepository();
        private LocalTrackRepository trackRepository = new LocalTrackRepository();

        public LocalRemiseRepository()
        {
            List<Track> Tracks1 = trackRepository.GetByRemiseId(1);
            List<Tram> Trams1 = tramRepository.GetByRemiseId(1);

            List<Track> Tracks2 = trackRepository.GetByRemiseId(2);
            List<Tram> Trams2 = tramRepository.GetByRemiseId(1);

            Remise amsterdam = new Remise("Remise Amsterdam", Tracks1,Trams1);
            Remise rotterdam = new Remise("Remise Rotterdam", Tracks2, Trams2);

            List<Remise> remises = new List<Remise>();
            remises.Add(amsterdam);
            remises.Add(rotterdam);

            Crud = new LocalCrud<Remise>(remises);
        }

        public bool Insert(Remise entity)
        {
            return Crud.Insert(entity);
        }

        public void Update(int id, Remise entity)
        {
            Crud.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return Crud.Delete(id);
        }

        public Remise GetById(int id)
        {
            return Crud.GetById(id);
        }

        public List<Remise> GetAll()
        {
            return Crud.GetAll();
        }

        public Remise GetByRemiseName(string name)
        {
            #region Create placeholder object
            List<Tram> trams = new List<Tram>();
            List<Track> tracks = new List<Track>();

            Remise remise = new Remise("ERROR", tracks, trams);
            #endregion

            foreach (Remise selRemise in Crud.All)
            {
                if (selRemise.Name == name)
                {
                    remise = selRemise;
                }
            }

            return remise;
        }
        public void EmptyAll(int id)
        {
            this.Delete(id);
        }

    }
}