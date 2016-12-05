using System;
using System.Collections.Generic;
using eyect4rails.Classes;

namespace eyect4rails.IRepository
{
    public interface ITramRepository:IRepository<Tram>
    {
        List<Tram> GetByTrackId(int id);
        List<Tram> GetByTrackId(int id, bool present);
        bool Enter(int trackid, int tramid, DateTime enter);
        bool Depart(int trackid, int tramid, DateTime depart);
    }
}
