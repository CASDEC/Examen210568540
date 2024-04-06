using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Models;

[Table("Producto")]
public partial class Producto
{
    [Key]
    [Column("IDproducto")]
    public int Idproducto { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }
}
