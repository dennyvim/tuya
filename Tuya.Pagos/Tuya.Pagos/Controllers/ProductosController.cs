using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Services.Interface;

namespace Tuya.Pagos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            this._productoService = productoService;
        }

        [HttpPost(Name = "CrearProducto")]
        public async Task<IActionResult> CrearProducto(ProductoDto producto)
        {
            try
            {

                var creacionProducto = await _productoService.CrearProducto(producto);
                return Ok(creacionProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Falló en creacion de producto" + ex);
            }
        }
    }
}
