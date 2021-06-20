using System;
using Microsoft.EntityFrameworkCore;
using Tuya.Pagos.Domain.Entities;

namespace Tuya.Pagos.Data.Context
{
    public class PagosContext : DbContext
    {

        public PagosContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet Entities
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<TransaccionDetalle> TransaccionDetalles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
