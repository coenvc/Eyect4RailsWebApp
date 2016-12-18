using System;
using System.Collections.Generic;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Models;

namespace eyect4rails.IRepository
{
    public interface ITramRepository:IRepository<Tram>
    {
        Tram GetBySectorId(int id);
        List<Tram> GetByRemiseId(int id);
    }
}
