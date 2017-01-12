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
<<<<<<< HEAD
        int GetHighestSector(int id);
=======
        List<Tram> GetNotParkedTrams();
>>>>>>> def2af0de5d0716dd472d2a8fdf1629471e08cfa
    }
}
