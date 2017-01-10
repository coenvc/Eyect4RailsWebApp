using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Models;

namespace Eyect4RailsWebApp.ViewModels
{
    public class CreateEditTramViewModel
    {
        public Tram Tram { get; set; }
        public List<Tram> Trams { get; set; }
        public Track Track { get; set; }
        public List<Track> Tracks { get; set; }
        public Sector Sector { get; set; }
        public List<Sector> Sectors { get; set; }
        public Remise Remise { get; set; }
        public List<Remise> Remises { get; set; }
        public int  RemiseId { get; set; }
        public CreateEditTramViewModel()
        {
            Tram = new Tram();
            Trams = new List<Tram>();
            Track = new Track();
            Tracks = new List<Track>();
            Sector = new Sector();
            Sectors = new List<Sector>();
            Remises = new List<Remise>();
            Remise = new Remise();
        }

        public CreateEditTramViewModel(Tram tram, List<Tram> trams, Track track, List<Track> tracks, Sector sector, List<Sector> sectors, Remise remise, List<Remise> remises)
        {
            this.Tram = tram;
            this.Trams = trams;
            this.Track = track;
            this.Tracks = tracks;
            this.Sector = sector;
            this.Sectors = sectors;
            this.Remise = remise;
            this.Remises = remises;

        }
    }
}