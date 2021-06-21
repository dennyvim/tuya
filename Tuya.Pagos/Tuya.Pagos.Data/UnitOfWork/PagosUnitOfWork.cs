using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tuya.Pagos.Data.Context;
using Tuya.Pagos.Data.Repositories;
using Tuya.Pagos.Domain.Entities;

namespace Tuya.Pagos.Data.UnitOfWork
{
    public class PagosUnitOfWork : IPagosUnitOfWork
    {
        private readonly PagosContext _context;
        private bool disposed = false;


        public PagosUnitOfWork(IServiceProvider serv)
        {
            var serviceScope = serv.CreateScope();
            this._context = new PagosContext(serviceScope.ServiceProvider.GetRequiredService<DbContextOptions<PagosContext>>());
        }

        private Repository<Usuario> usuarios;
        public Repository<Usuario> Usuarios
        {
            get { if (this.usuarios == null) this.usuarios = new Repository<Usuario>(_context); return usuarios; }
        }

        private Repository<Evento> eventos;
        public Repository<Evento> Eventos
        {
            get { if (this.eventos == null) this.eventos = new Repository<Evento>(_context); return eventos; }
        }


        private Repository<Producto> productos;
        public Repository<Producto> Productos
        {
            get { if (this.productos == null) this.productos = new Repository<Producto>(_context); return productos; }
        }

        private Repository<Transaccion> transacciones;
        public Repository<Transaccion> Transacciones
        {
            get { if (this.transacciones == null) this.transacciones = new Repository<Transaccion>(_context); return transacciones; }
        }

        private Repository<TransaccionDetalle> transaccionDetalles;

        public Repository<TransaccionDetalle> TransaccionDetalles
        {
            get { if (this.transaccionDetalles == null) this.transaccionDetalles = new Repository<TransaccionDetalle>(_context); return transaccionDetalles; }

        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public int Save() => _context.SaveChanges();
    }
}

