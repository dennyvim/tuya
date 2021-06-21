using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Responses;
using Tuya.Pagos.Application.Services.Interface;

namespace Tuya.Pagos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly IFacturacionService _facturacionService;
        private readonly ILogisticaService _logisticaService;
        ResponseModel<ResultadoPagos> responsePagos;

        public PagosController(IFacturacionService facturacionService, ILogisticaService logisticaService)
        {
            this._facturacionService = facturacionService;
            this._logisticaService = logisticaService;
        }

        [HttpPost(Name = "PagarCompra")]
        public async Task<IActionResult> RealizarPago(CompraDto compra)
        {
            try
            {

                var facturacion = await this._facturacionService.CrearPago(compra);
                var logistica = await this._logisticaService.CrearEvento(facturacion);
                ResultadoPagos resultadoUnificado = new ResultadoPagos { Evento = logistica, Transaccion = facturacion };
                var responsePagos = new ResponseModel<ResultadoPagos>()
                {
                    Exitoso = true,
                    Descripcion = "OK",
                    Resultado = resultadoUnificado,
                };

                return this.Ok(responsePagos);

            }
            catch (Exception ex)
            {

                throw new Exception("Error en realizacion de pago" + ex);
            }
        }
    }
}
