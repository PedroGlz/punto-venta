using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }  // clave primaria autoincremental
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
