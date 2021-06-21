using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Services.Interface;

namespace Tuya.Pagos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [HttpPost(Name = "CrearUsuario")]
        public async Task<IActionResult> CrearUsuario(UsuarioDto usuario)
        {
            try
            {

                var creacionUsuario = await _usuarioService.CrearUsuario(usuario);

                return Ok(creacionUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo en creacion de usuario" + ex);
            }
        }
    }
}
