using System;
using System.Threading.Tasks;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Services.Interface;
using Tuya.Pagos.Data.UnitOfWork;
using Tuya.Pagos.Domain.Entities;
using Tuya.Pagos.Utils.Enum;

namespace Tuya.Pagos.Application.Services.Logistica
{
    public class LogisticaService : ILogisticaService
    {
        private readonly IPagosUnitOfWork _pagosRepository;

        public LogisticaService(IPagosUnitOfWork pagosRepository)
        {
            _pagosRepository = pagosRepository;
        }

        public async Task<ResultadoEventoDto> CrearEvento(ResultadoTransaccionDto transaccion)
        {

            Evento evento = new Evento
            {
                TipoEvento = Eventos.PEDIDO_ENVIADO,
                TransaccionId = transaccion.IdTransaccion,
                UltimaActualizacion = DateTime.Now,

            };
            _pagosRepository.Eventos.Insert(evento);
            _pagosRepository.Save();

            int eventoId = evento.Id;

            ResultadoEventoDto response = new ResultadoEventoDto
            {
                Estado = Eventos.PEDIDO_ENVIADO.ToString(),
                EventoId = eventoId
            };

            return response;
        }
    }
}
