using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Interfaces;
using Eyect4RailsWebApp.Models;
using eyect4rails.IRepository;

namespace Eyect4RailsWebApp.IRepository
{
    public interface ISectorRepository : IRepository<Sector>
    {
        List<Sector> GetByTrackId(int id);
        Sector GetByTramId(int id);

        int MaximalSectorNumber(int trackId);

        int MinimalSectorNumber(int trackId);

        void UpdateAssignTramSectors(int trackId, int sectorNumber, int tramid);
    }
}
