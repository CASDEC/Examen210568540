using System;
using System.Collections.Generic;
using Examen2.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Contexto;

public partial class Examen2Context : DbContext
{

    public Examen2Context(DbContextOptions<Examen2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detalle> Detalles { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

}
