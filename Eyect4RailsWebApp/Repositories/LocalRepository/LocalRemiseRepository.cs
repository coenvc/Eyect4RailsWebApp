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
        private List<Remise> Remises = new List<Remise>();

        private LocalTramRepository tramRepository = new LocalTramRepository();
        //private LocalTrackRepository trackRepository = new LocalTrackRepository();

        public LocalRemiseRepository()
        {
            // TODO: Replace placeholderTracks when LocalTrackRepository is working
            List<Track> placeholderTracks = new List<Track>
            {
                new Track()
            };

            // TODO: Replace placeholderTrams when LocalTramRepository is working
            List<Tram> placeholderTrams = new List<Tram>
            {
                new Tram()
            };

            Remise amsterdam = new Remise("Remise Amsterdam", placeholderTracks, placeholderTrams);
            Remise rotterdam = new Remise("Remise Rotterdam", placeholderTracks, placeholderTrams);

            Insert(amsterdam);
            Insert(rotterdam);
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

            foreach (Remise selRemise in Remises)
            {
                if (selRemise.Name == name)
                {
                    remise = selRemise;
                }
            }

            return remise;
        }
    }
}