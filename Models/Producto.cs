using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Gtin { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Utilidad { get; set; }
        public int CantidadDisponible { get; set; }
        public int CantidadMinima { get; set; }

    }
}
