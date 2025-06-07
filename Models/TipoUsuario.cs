using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    public class TipoUsuario
    {
        public int TipoUsuarioId { get; set; }  // clave primaria autoincremental
        public string Tipo { get; set; }
    }
}
