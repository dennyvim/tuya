using System;
using System.Threading.Tasks;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Services.Interface;
using Tuya.Pagos.Data.UnitOfWork;
using Tuya.Pagos.Domain.Entities;

namespace Tuya.Pagos.Application.Services.Facturacion
{
    public class FacturacionService : IFacturacionService
    {
        private readonly IPagosUnitOfWork _pagosRepository;

        public FacturacionService(IPagosUnitOfWork pagosRepository)
        {
            _pagosRepository = pagosRepository;
        }

        public async Task createPagos()
        {

        }

        public async Task createUser(UsuarioDto usuario)
        {
            Usuario user = new Usuario
            {
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Direccion = usuario.Direccion,
                Email = usuario.Email

            };
            _pagosRepository.Usuarios.Insert(user);
            _pagosRepository.Save();
        }
    }
}
