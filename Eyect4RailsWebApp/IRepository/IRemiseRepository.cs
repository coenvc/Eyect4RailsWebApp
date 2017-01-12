using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eyect4rails.Classes;
using Eyect4RailsWebApp.Models;

namespace eyect4rails.IRepository
{
    public interface IRemiseRepository:IRepository<Remise>
    {
        Remise GetByRemiseName(string name);
        void EmptyAll(int id);
    }
}
