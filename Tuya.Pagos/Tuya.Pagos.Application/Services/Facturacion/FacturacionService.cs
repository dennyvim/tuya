using System;
using System.Threading.Tasks;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Services.Interface;
using Tuya.Pagos.Data.UnitOfWork;
using Tuya.Pagos.Domain.Entities;
using Tuya.Pagos.Utils.Enum;

namespace Tuya.Pagos.Application.Services.Facturacion
{
    public class FacturacionService : IFacturacionService
    {
        private readonly IPagosUnitOfWork _pagosRepository;

        public FacturacionService(IPagosUnitOfWork pagosRepository)
        {
            _pagosRepository = pagosRepository;
        }

        public async Task<ResultadoTransaccionDto> CrearPago(CompraDto compraDto)
        {
            try
            {

                float total = 0;
                foreach (var productos in compraDto.Productos)
                {

                    float costo = productos.Price;
                    total = total + costo;
                }
                Transaccion transaccion = new Transaccion
                {
                    Total = total,
                    Fecha = DateTime.Now,
                    UsuarioId = compraDto.UserId
                };

                _pagosRepository.Transacciones.Insert(transaccion);
                _pagosRepository.Save();

                int id = transaccion.Id;

                foreach (var productos in compraDto.Productos)
                {
                    TransaccionDetalle detalle = new TransaccionDetalle
                    {
                        ProductoId = productos.ProductId,
                        TransaccionId = id
                    };

                    _pagosRepository.TransaccionDetalles.Insert(detalle);
                }

                Evento evento = new Evento
                {
                    TipoEvento = Eventos.PEDIDO_FACTURADO,
                    TransaccionId = id,
                    UltimaActualizacion = DateTime.Now,

                };
                _pagosRepository.Eventos.Insert(evento);


                _pagosRepository.Save();

                var response = new ResultadoTransaccionDto
                {
                    IdTransaccion = id,
                    Productos = compraDto.Productos,
                    UsuarioId = compraDto.UserId,
                    TotalCompra = total
                };
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + "Error");
            }
        }

    }
}
