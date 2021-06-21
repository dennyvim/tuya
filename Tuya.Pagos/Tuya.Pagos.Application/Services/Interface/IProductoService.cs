using System;
using System.Threading.Tasks;
using Tuya.Pagos.Application.DTO.Services;

namespace Tuya.Pagos.Application.Services.Interface
{
    public interface IProductoService
    {
        Task<ProductoDto> CrearProducto(ProductoDto usuario);

    }
}
