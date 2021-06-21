using System;
using Microsoft.EntityFrameworkCore;
using Tuya.Pagos.Domain.Entities;

namespace Tuya.Pagos.Data.Context
{
    public class PagosContext : DbContext
    {

        // DbSet Entities
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<TransaccionDetalle> TransaccionDetalles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public PagosContext(DbContextOptions options) : base(options)
        {
        }

    }
}
