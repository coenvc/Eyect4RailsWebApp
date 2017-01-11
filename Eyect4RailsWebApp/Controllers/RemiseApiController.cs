using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eyect4RailsWebApp.Logic;
using Eyect4RailsWebApp.Repositories.MSSQLRepository;

namespace Eyect4RailsWebApp.Controllers
{
    public class RemiseApiController : ApiController
    {
        RemiseLogic logic = new RemiseLogic(new MSSQLRemiseRepository());

        public IHttpActionResult GetSector(int id)
        {
            var sector = logic.GetById(id); 
            if (sector == null)
            {
                return NotFound();
            }
            return Ok(sector);
        }
    }
}
