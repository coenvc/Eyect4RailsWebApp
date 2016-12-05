using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eyect4rails.Classes;

namespace eyect4rails.IRepository
{
    public interface IRemiseRepository:IRepository<Remise>
    {
        List<Track> GetTracksByRemiseID(int id);

        List<Track> GetTracksByRemiseID(int id, string tracktype);
    }
}
