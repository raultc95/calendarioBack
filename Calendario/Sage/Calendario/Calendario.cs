using Calendario.Models.Calendario;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Calendario.Sage.Calendario
{
    public class Calendario
    {
        public List<CalendarioModels> Test()
        {
            try
            {
                String sql = "";
                String update = "";
         
                List<CalendarioModels> listaCalendario = new List<CalendarioModels>();
                using ( var connection = new SqlConnection(Properties.Resources.sqlconnection)) {
                    sql = $"SELECT format(cb.FechaEntrega,'dd/MM/yyyy') as FechaEntrega,  cb.CodigoCliente, cb.NumeroPedido,cb.Nombre,cb.Estado," +
                        $" cb.CodigoTransportistaEnvios,isnull(t.Transportista, 'Sin Transportista') as transportista" +
                        $" FROM CabeceraPedidoCliente as cb " +
                        $"left join Transportistas as t on cb.codigoempresa = t.CodigoEmpresa and  cb.CodigoTransportistaEnvios = t.CodigoTransportista " +
                        $"where cb.CodigoEmpresa={Properties.Resources.CodigoEmpresa}";

                    //update = "UPDATE CabeceraPedidoCliente SET CodigoTransportistaEnvios=@CodigoTransportistaEnvios WHERE NumeroPedido=@NumeroPedido";


                    listaCalendario = connection.Query<CalendarioModels>(sql).AsList();
                   // connection.Execute(update);


                    //listaCalendario=connection.Execute(update, calendario)

                    return listaCalendario;

                }
             
            }
            catch (Exception)
            {

                throw;
                
            }
        }
        public int Modifica(CalendarioModels calendario) {
            try {
                String update = "";

                using (var connection = new SqlConnection(Properties.Resources.sqlconnection)) {
              
                    update = $"UPDATE CabeceraPedidoCliente SET CodigoTransportistaEnvios=@CodigoTransportistaEnvios WHERE EjercicioPedido=@Ejercicio and " +
                        $"NumeroPedido=@NumeroPedido and SeriePedido=@SeriePedido and CodigoEmpresa={Properties.Resources.CodigoEmpresa}";

                    var resultado = connection.Execute(update, calendario);
                    return resultado;

                }

            }
            catch (Exception) {

                throw;

            }
        }
        public List<TransportistaModels> Transportista() {
            try {
                String transportista = "";
                

                List<TransportistaModels> listaTransportista = new List<TransportistaModels>();
                using (var connection = new SqlConnection(Properties.Resources.sqlconnection)) {
                    transportista = $"SELECT  CodigoTransportista, Transportista FROM Transportistas  where CodigoEmpresa={Properties.Resources.CodigoEmpresa} order by CodigoTransportista";

                    //update = "UPDATE CabeceraPedidoCliente SET CodigoTransportistaEnvios=@CodigoTransportistaEnvios WHERE NumeroPedido=@NumeroPedido";


                    listaTransportista = connection.Query<TransportistaModels>(transportista).AsList();
                    // connection.Execute(update);


                    //listaCalendario=connection.Execute(update, calendario)

                    return listaTransportista;

                }

            }
            catch (Exception) {

                throw;

            }

        }
    }

}
