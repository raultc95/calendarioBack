using Calendario.Models.Calendario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Calendario.Controllers {
    [ApiController]
    [Route("api/modifica")]
    public class ModificaPedidoController : Controller {

        public Int32 Post(CalendarioModels pedido) {
            try {
                
                Sage.Calendario.Calendario _calendario = new Sage.Calendario.Calendario();
                var resultado = _calendario.Modifica(pedido);

                return resultado;
            }
            catch (Exception ex) {
                
                throw;
            }
        }


    }
}
