using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Tracing;
using eyect4rails.Classes;
using eyect4rails.IRepository;


namespace Eyect4RailsWebApp.Repositories.LocalRepository
{
    public class LocalTramRepository : ITramRepository
    {
        private List<Tram> trams;

        public LocalTramRepository()
        {
            trams = new List<Tram>();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Depart(int trackid, int tramid, DateTime depart)
        {
            throw new NotImplementedException();
        }

        public bool Enter(int trackid, int tramid, DateTime enter)
        {
            throw new NotImplementedException();
        }

        public List<Tram> GetAll()
        {
            Tram tram = new Tram(1, Enums.Enums.TramType.Combino, 1, 3, false, false, true, true);
            Tram tram1 = new Tram(1, Enums.Enums.TramType.DubbelKopCombino, 2, 5, false, true, false, false);
            Tram tram2 = new Tram(1, Enums.Enums.TramType.ElevenG, 3, 6, true, false, false, false);
            Tram tram3 = new Tram(1, Enums.Enums.TramType.TenG, 4, 5, false, false, false, true);
            Tram tram4 = new Tram(1, Enums.Enums.TramType.Opleidingstram, 5, 6, true, true, true, false);
          //  Tram tram5 = new Tram(1,Enums.Enums.TramType.TwelveG, 6, );
        }

        public Tram GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tram> GetByTrackId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tram> GetByTrackId(int id, bool present)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Tram entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Tram entity)
        {
            throw new NotImplementedException();
        }
    }
}