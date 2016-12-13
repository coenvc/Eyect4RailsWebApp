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
    public class LocalTramRepository : ITramRepository
    {
        private LocalCrud<Tram> Crud;

        public LocalTramRepository()
        {
            Tram tram = new Tram(1, Enums.TramType.Combino, 1, 3, false, false, true, true);
            Tram tram1 = new Tram(1, Enums.TramType.DubbelKopCombino, 2, 5, false, true, false, false);
            Tram tram2 = new Tram(1, Enums.TramType.ElevenG, 3, 6, true, false, false, false);
            Tram tram3 = new Tram(1, Enums.TramType.TenG, 4, 5, false, false, false, true);
            Tram tram4 = new Tram(1, Enums.TramType.Opleidingstram, 5, 6, true, true, true, false);
            Tram tram5 = new Tram(1, Enums.TramType.TwelveG, 6, 3, false, false, false, true);
            Tram tram6 = new Tram(1, Enums.TramType.TwelveG, 7, 1, true, false, false, true);
            Tram tram7 = new Tram(2, Enums.TramType.Combino, 8, 1, false, true, false, false);
            Tram tram8 = new Tram(2, Enums.TramType.DubbelKopCombino, 9, 4, false, false, true, true);
            Tram tram9 = new Tram(2, Enums.TramType.TwelveG, 10, 8, false, false, true, true);

            List<Tram> trams = new List<Tram>
            {
                tram,
                tram1,
                tram2,
                tram3,
                tram4,
                tram5,
                tram6,
                tram7,
                tram8,
                tram9
            };

            Crud = new LocalCrud<Tram>(trams);
        }

        public bool Insert(Tram entity)
        {
            return Crud.Insert(entity);
        }

        public void Update(int id, Tram entity)
        {
            Crud.Update(id, entity);
        }

        public bool Delete(int id)
        {
            return Crud.Delete(id);
        }

        public Tram GetById(int id)
        {
            return Crud.GetById(id);
        }

        public List<Tram> GetAll()
        {
            return Crud.GetAll();
        }

        public Tram GetBySectorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tram> GetByRemiseId(int id)
        {
            throw new NotImplementedException();
        }
    }
}