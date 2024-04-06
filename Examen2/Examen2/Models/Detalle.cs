using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Examen2.Models;

[Keyless]
[Table("Detalle")]
public class Detalle
{
    [Column("IDpedido")]
    public int Idpedido { get; set; }

    [Column("IDproducto")]
    public int? Idproducto { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Precio { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? SubTotal { get; set; }

    [ForeignKey("Idpedido")]
    [JsonIgnore]
    public virtual Pedido? IdpedidoNavigation { get; set; } = null!;

    
    [ForeignKey("Idproducto")]
    [JsonIgnore]
    public virtual Producto? IdproductoNavigation { get; set; }
}
