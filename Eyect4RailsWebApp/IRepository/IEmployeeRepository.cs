using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eyect4rails.Classes;

namespace eyect4rails.IRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        List<Employee> GetAllActive(bool active);
        Employee GetByRfid(string rfid);
        List<Employee> GetByDepartmentId(int id);
        List<Employee> GetByDepartmentName(string departmentName);
        Employee GetByUsernamePassword(string username, string password);
    }
}
