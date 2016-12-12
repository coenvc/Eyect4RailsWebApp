using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Tracing;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.Repositories.LocalRepository
{
    public class LocalTrackRepository : ITrackRepository
    {
        private int TrackCounter = 0;
        private List<Track> tracks = new List<Track>();
        private List<Sector> Sectors = new List<Sector>();
        private List<Tram> trams = new List<Tram>();
        private List<Remise> remises = new List<Remise>();

        public LocalTrackRepository()
        {
            Tram tram1 = new Tram(1, Enums.TramType.Combino, 1, 3, false, false, true, true);
            Tram tram2 = new Tram(1, Enums.TramType.DubbelKopCombino, 2, 5, false, true, false, false);
            Tram tram3 = new Tram(1, Enums.TramType.ElevenG, 3, 6, true, false, false, false);
            Tram tram4 = new Tram(2, Enums.TramType.TenG, 4, 5, false, false, false, true);
            Tram tram5 = new Tram(2, Enums.TramType.Opleidingstram, 5, 6, true, true, true, false);
            trams.Add(tram1);
            trams.Add(tram2);
            trams.Add(tram3);
            trams.Add(tram4);
            trams.Add(tram5);

            Sector sector1 = new Sector();
            Sector sector2 = new Sector();
            Sector sector3 = new Sector();
            Sector sector4 = new Sector();
            Sectors.Add(sector1);
            Sectors.Add(sector2);
            Sectors.Add(sector3);
            Sectors.Add(sector4);

            Track track = new Track(1, 1, 6, true, true, Sectors);
            Track track1 = new Track(2, 1, 6, true, false, Sectors);
            Track track2 = new Track(3, 1, 6, true, false, Sectors);
            Track track3 = new Track(4, 1, 5, true, false, Sectors);
            Track track4 = new Track(5, 1, 4, true, false, Sectors);
            Insert(track);
            Insert(track1);
            Insert(track2);
            Insert(track3);
            Insert(track4);

            Remise remise = new Remise(1, "Havenstraat", tracks, trams);
            remises.Add(remise);
        }

        public bool Delete(int id)
        {
            foreach (Track track in tracks)
            {
                if (track.Id == id)
                {
                    tracks.Remove(track);
                    return true;
                }
            }
            return false;
        }

        public List<Track> GetAll()
        {
            return tracks;
        }

        public Track GetById(int id)
        {
            foreach (Track track in tracks)
            {
                if (track.Id == id)
                {
                    return track;
                }
            }
            return null;
        }

        public List<Track> GetByRemiseId(int id)
        {
            foreach (Remise remise in remises)
            {
                if (remise.Id == id)
                {
                    return remise.Tracklist;
                }
            }
            return null;
        }

        public bool Insert(Track entity)
        {
            entity.Id = TrackCounter;
            TrackCounter++;
            tracks.Add(entity);
            return true;
        }

        public bool Insert(Remise remise, Track track)
        {
            bool insertTrack = true;
            foreach (Track foundTrack in remise.Tracklist)
            {
                if (track.Id == foundTrack.Id)
                {
                    insertTrack = false;
                }
            }
            if (insertTrack == true)
            {
                remise.Tracklist.Add(track);
                return true;
            }
            return false;
        }

        public void Update(int id, Track entity)
        {
            foreach (Track track in tracks)
            {
                if (track.Id == id)
                {
                    track.RemiseId = entity.RemiseId;
                    track.Available = entity.Available;
                    track.EntryDepartTrack = entity.EntryDepartTrack;
                    track.Number = entity.Number;
                    track.SectorList = entity.SectorList;
                    track.Sectors = entity.Sectors;
                }
            }
        }
    }
}