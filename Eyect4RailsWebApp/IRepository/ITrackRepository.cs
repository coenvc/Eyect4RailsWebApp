using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Models;

namespace eyect4rails.IRepository
{
    public interface ITrackRepository : IRepository<Track>
    {
        List<Track> GetByRemiseId(int remiseid);
        bool Insert(Remise remise, Track track);


        List<Track> GetAvailableByRemiseId(int remiseid);
    }
}
