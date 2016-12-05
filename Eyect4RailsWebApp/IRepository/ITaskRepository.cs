using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eyect4rails.Classes;

namespace eyect4rails.IRepository
{
    public interface ITaskRepository:IRepository<Maintenance>
    {

        /// <summary>
        /// Gives a list of all tasks. Completed specifies if you want a list of all assigned completed or uncompleted tasks.
        /// </summary>
        /// <param name="completed">True will give a list of all completed tasks, False will give a list of all open tasks.</param>
        List<Maintenance> GetAll(bool completed);

        /// <summary>
        /// A method to get a single specific TaskExecution Maintenance by its ID
        /// </summary>
        /// <param name="id"></param>
        Maintenance GetByTaskExecutionId(int id);

        /// <summary>
        /// Method used to get a list of all assigned tasks that per function, using the DepartmentID
        /// </summary>
        /// <param name="id">DepartmentID</param>
        /// <returns>Returns a list of all tasks for a specific function. If none exist it will return an empty list.</returns>
        List<Maintenance> GetByDepartmentId(int id);

        /// <summary>
        /// Method used to get a list of all assigned tasks that per function, using the DepartmentID
        /// Also gives you the Completed bool to specify if you want completed or incompleted tasks
        /// </summary>
        /// <param name="id">DepartmentID</param>
        /// <param name="completed">True will give a list of all completed tasks, False will give a list of all open tasks</param>
        /// <returns>Returns a list of all tasks for a specific function. If none exist it will return an empty list.</returns>
        List<Maintenance> GetByDepartmentId(int id, bool completed); 

        /// <summary>
        /// Method used to get a list of all assigned tasks for that function, using the Departmentname.
        /// </summary>
        /// <returns>Returns a list of all tasks for a specific function. If none exist it will return an empty list.</returns>
        List<string> GetTasksAsStringList(string departmentName);

        /// <summary>
        /// Method used to get a list of all tasks that per function, using the name of the function
        /// </summary>
        /// <param name="departmentName">Name of the function</param>
        /// <returns>Returns a list of all tasks for a specific function. If none exist it will return an empty list.</returns>
        List<Maintenance> GetByDepartmentName(string departmentName);

        /// <summary>
        /// Method used to get a list of all assigned tasks per function, using the name of the function
        /// </summary>
        /// <param name="departmentName">Name of the function</param>
        /// <param name="completed">True will give a list of all completed tasks, False will give a list of all open tasks</param>
        /// <returns>Returns a list of all tasks for a specific function. If none exist it will return an empty list.</returns>
        List<Maintenance> GetByDepartmentName(string departmentName, bool completed);

        /// <summary>
        /// Gets a list of all tasks assigned to a specific user.
        /// </summary>
        /// <param name="id"></param>
        List<Maintenance> GetByEmployeeId(int id);

        /// <summary>
        /// Gets a list of all tasks assigned to a specific user that are either complete or incomplete
        /// </summary>
        /// <param name="id">EmployeeID</param>
        /// <param name="completed">True will give a list of all completed tasks, False will give a list of all open tasks</param>
        /// <returns></returns>
        List<Maintenance> GetByEmployeeId(int id, bool completed); 

        /// <summary>
        /// Gets a list of all assigned Tasks for a specific tram.
        /// </summary>
        /// <param name="id">TramID</param>
        /// <returns></returns>
        List<Maintenance> GetByTramId(int id);

        /// <summary>
        /// Gets a list of all assigned Tasks for a specific tram. Also gives the option to only shot completed or uncompleted tasks.
        /// </summary>
        /// <param name="id">TramID</param>
        /// <param name="completed">True will give a list of all completed tasks, False will give a list of all open tasks</param>
        /// <returns></returns>
        List<Maintenance> GetByTramId(int id, bool completed);
    }
}