using Calendario.Models.Calendario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Calendario.Controllers {
    [ApiController]
    [Route("api/transportista")]
    public class TrasnportistaController : Controller {
        public List<TransportistaModels> Post() {
            try {
                List<TransportistaModels> result = new List<TransportistaModels>();
                Sage.Calendario.Calendario _calendario = new Sage.Calendario.Calendario();
                result = _calendario.Transportista();

                return result;
            }
            catch (Exception ex) {

                throw;
            }
        }
    }
}
