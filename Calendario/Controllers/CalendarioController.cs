using Calendario.Models.Calendario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Calendario.Controllers
{
    [ApiController]
    [Route("api/calendario")]
    public class CalendarioController : Controller {

        public List<CalendarioModels> Post() {
            try {
                List<CalendarioModels> result = new List<CalendarioModels>();
                Sage.Calendario.Calendario _calendario = new Sage.Calendario.Calendario();
                result = _calendario.Test();

                return result;
            }
            catch (Exception ex) {

                throw;
            }
        }

       
       
        
    }
}
