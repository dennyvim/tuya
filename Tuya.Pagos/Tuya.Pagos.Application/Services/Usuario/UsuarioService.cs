using System;
using System.Threading.Tasks;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Services.Interface;
using Tuya.Pagos.Domain.Entities;
using Tuya.Pagos.Data.UnitOfWork;

namespace Tuya.Pagos.Application.Services.User
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IPagosUnitOfWork _pagosRepository;

        public UsuarioService(IPagosUnitOfWork pagosRepository)
        {
            this._pagosRepository = pagosRepository;
        }

        public async Task<UsuarioDto> CrearUsuario(UsuarioDto usuario)
        {
            try
            {

                Usuario usuarioEntity = new Usuario
                {
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Email = usuario.Email,
                    Direccion = usuario.Direccion,
                    Cedula = usuario.Cedula,

                };
                _pagosRepository.Usuarios.Insert(usuarioEntity);
                _pagosRepository.Save();
                usuario.Id = usuarioEntity.Id;

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando un usuario" + ex);
            }
        }
    }
}
