using System;
using System.Threading.Tasks;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Services.Interface;
using Tuya.Pagos.Data.UnitOfWork;
using Tuya.Pagos.Domain.Entities;

namespace Tuya.Pagos.Application.Services.Product
{
    public class ProductoService : IProductoService
    {
        private readonly IPagosUnitOfWork _pagosRepository;

        public ProductoService(IPagosUnitOfWork pagosRepository)
        {
            this._pagosRepository = pagosRepository;
        }

        public async Task<ProductoDto> CrearProducto(ProductoDto producto)
        {
            try
            {
                Producto productoEntity = new Producto
                {
                    NombreProducto = producto.NombreProducto,
                    Precio = producto.Precio,

                };
                _pagosRepository.Productos.Insert(productoEntity);
                _pagosRepository.Save();
                producto.Id = productoEntity.Id;

                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando un usuario" + ex);
            }
        }
    }
}
