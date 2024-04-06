using Examen2.Contexto;
using Examen2.Contratos;
using Examen2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Implementacion
{
    public class Preguntas : IPreguntas
    {
        private readonly Examen2Context _context;
        public Preguntas(Examen2Context context) { 
            _context = context;
        }
        public async Task<bool> ActualizarPedidoDetalle(PedidoDetalle pedidodetalle)
        {
            Pedido ped = await _context.Pedidos.FindAsync(pedidodetalle.pedido.Idpedido);
            Detalle det =await _context.Detalles.Where(x => x.Idproducto == pedidodetalle.detalle.Idproducto && x.Idpedido == pedidodetalle.pedido.Idpedido).FirstOrDefaultAsync();
            if (ped == null || det == null)
            {
                return false;
            }
            _context.Entry(det).CurrentValues.SetValues(pedidodetalle.detalle);
            _context.Entry(ped).CurrentValues.SetValues(pedidodetalle.pedido);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<bool> EliminarCascadaCliente(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DTOReporte>> ListarReporteCFNS()
        {
            var result = await _context.Detalles.Select( x => new DTOReporte {
                NombreCliente = x.IdpedidoNavigation.IdclienteNavigation.Nombre,
                FechaPedido = (DateOnly)x.IdpedidoNavigation.Fecha,
                NombreProducto = x.IdproductoNavigation.Nombre,
                SubTotal = (decimal)x.SubTotal,
            }).ToListAsync();
            return result;
        }

        public async Task<List<Producto>> ProductoMasVendido(string inicio, string final)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> ProductosMasSolicitados()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegistrarPedidoDetalle(PedidoDetalle pedidodetalle)
        {
            try
            {
                _context.Pedidos.Add(pedidodetalle.pedido);
                _context.Detalles.Add(pedidodetalle.detalle);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
