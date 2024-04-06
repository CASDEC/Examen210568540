using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Models
{
    public class PedidoDetalle
    {
        public Pedido pedido { get; set; }
        public Detalle detalle { get; set; }
    }
}
