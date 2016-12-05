using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyect4RailsWebApp.Interfaces
{
    public interface ICruddable
    {
        /// <summary>
        /// Interface promising the Class you are using will contain an ID 
        /// This is needed to execute the methods in the Crud class
        /// </summary>
            int Id { get; set; }
        
    }
}
