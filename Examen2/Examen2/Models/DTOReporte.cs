using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Models
{
    public class DTOReporte
    {
        public string NombreCliente { get; set; }
        public DateOnly FechaPedido { get; set; }
        public string NombreProducto { get; set; }
        public decimal SubTotal { get; set; }
    }
}
