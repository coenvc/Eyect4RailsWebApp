using System;
using System.Collections.Generic;
using eyect4rails.Classes;

namespace eyect4rails.IRepository
{
    public interface ITramRepository:IRepository<Tram>
    {
        Tram GetBySectorId(int id);
    }
}
