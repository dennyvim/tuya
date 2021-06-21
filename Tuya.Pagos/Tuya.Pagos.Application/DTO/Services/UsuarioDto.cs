using System;
using System.ComponentModel.DataAnnotations;

namespace Tuya.Pagos.Application.DTO.Services
{

    public class UsuarioDto
    {
        public UsuarioDto()
        {
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Cedula { get; set; }

    }

}
