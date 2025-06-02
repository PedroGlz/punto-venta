using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    public class Venta
    {
        public int VentaId { get; set; }  // folio o número de ticket consecutivo (clave primaria)
        public int Folio { get; set; } // Número de ticket consecutivo
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalVenta { get; set; }
        public int NumeroProductos { get; set; }
        public decimal Pago { get; set; }
        public decimal Cambio { get; set; }
        public decimal TipoPagoId { get; set; }

        // Opcional: Relación con usuario
        // public Usuario Usuario { get; set; }
    }
}
