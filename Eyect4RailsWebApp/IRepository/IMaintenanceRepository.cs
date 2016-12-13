using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eyect4rails.Classes;
using eyect4rails.IRepository;

namespace Eyect4RailsWebApp.IRepository
{
    public interface IMaintenanceRepository:IRepository<Maintenance>
    {
        List<Maintenance> GetAll(bool completed);
        List<Maintenance> GetByEmployeeId(int id);
        List<Maintenance> GetByEmployeeId(int id, bool completed);
        List<Maintenance> GetByTramId(int id);
        List<Maintenance> GetByTramId(int id, bool completed);
        void Assign(int id, Employee employee);
        void Complete(int id, Employee employee, DateTime completed); 
    }
}
