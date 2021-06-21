using System;
using Tuya.Pagos.Data.Repositories;
using Tuya.Pagos.Domain.Entities;

namespace Tuya.Pagos.Data.UnitOfWork
{
    public interface IPagosUnitOfWork : IDisposable
    {
        Repository<Usuario> Usuarios { get; }
        Repository<Evento> Eventos { get; }
        Repository<Producto> Productos { get; }
        Repository<Transaccion> Transacciones { get; }
        Repository<TransaccionDetalle> TransaccionDetalles { get; }

        int Save();

    }
}
