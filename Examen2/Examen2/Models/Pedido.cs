using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Examen2.Models;

[Table("Pedido")]
public partial class Pedido
{
    [Key]
    [Column("IDpedido")]
    public int Idpedido { get; set; }

    [Column("IDcliente")]
    public int Idcliente { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? Total { get; set; }

    public int? Estado { get; set; }

    
    [ForeignKey("Idcliente")]
    [InverseProperty("Pedidos")]
    [JsonIgnore]
    public virtual Cliente? IdclienteNavigation { get; set; } = null!;
}
