using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.Classes;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Context;
using Eyect4RailsWebApp.IRepository;
using Eyect4RailsWebApp.Models;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;
using Eyect4RailsWebApp.ViewModels;

namespace Eyect4RailsWebApp.Logic
{
    public class TramLogic : ITramRepository
    {
        private TramContext tramContext = new TramContext(new MSSQLTramRepository());
        
        public bool Delete(int id)
        {
            return tramContext.Delete(id);
        }

        public List<Tram> GetAll()
        {
            return tramContext.GetAll();
        }

        public Tram GetById(int id)
        {
            return tramContext.GetById(id);
        }

        public List<Tram> GetByRemiseId(int id)
        {
            return tramContext.GetByRemiseId(id);
        }

        public List<Tram> GetNotParkedTrams()
        {
            return tramContext.GetNotParkedTrams();
        }

        public Tram GetBySectorId(int id)
        {
            return tramContext.GetBySectorId(id);
        }

        public int GetHighestSector(int id)
        {
            return tramContext.GetHighestSector(id);
        }

        public bool Insert(Tram entity)
        {
            return tramContext.Insert(entity);
        }

        public void Update(int id, Tram entity)
        {
            tramContext.Update(id, entity);
<<<<<<< HEAD
        }

=======
        } 
>>>>>>> def2af0de5d0716dd472d2a8fdf1629471e08cfa

    }
}