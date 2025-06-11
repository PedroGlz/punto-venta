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
        public decimal PrecioVentaUnitario { get; set; }
        public decimal UtilidadUnitaria { get; set; }
        public decimal PrecioVentaMayoreo { get; set; }
        public decimal UtilidadMayoreo { get; set; }
        public int CantidadMinimaMayoreo { get; set; }
        public int CantidadDisponible { get; set; }
        public int CantidadMinimaDisponible { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CreadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }

    }
}
