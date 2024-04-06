using Examen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Contratos
{
    public interface IPreguntas
    {
        public Task<bool> RegistrarPedidoDetalle(PedidoDetalle pedidodetalle);
        public Task<List<DTOReporte>> ListarReporteCFNS();
        public Task<List<Producto>> ProductosMasSolicitados();
        public Task<bool> ActualizarPedidoDetalle(PedidoDetalle pedidodetalle);
        public Task<bool> EliminarCascadaCliente(int id);
        public Task<List<Producto>> ProductoMasVendido(string inicio, string final);
    }
}
