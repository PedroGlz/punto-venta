using System;
using System.Collections.Generic;

namespace PuntoVenta.Models
{
    public class Venta
    {
        public int VentaId { get; set; } // Clave primaria
        public int Folio { get; set; }   // Número de ticket consecutivo

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime Fecha { get; set; }

        public decimal TotalVenta { get; set; }
        public int NumeroProductos { get; set; }
        public decimal Pago { get; set; }
        public decimal Cambio { get; set; }

        public int TipoPagoId { get; set; } // Corregido de decimal a int
        public TipoPago TipoPago { get; set; } // Relación de navegación

        public ICollection<DetalleVenta> DetallesVenta { get; set; } // Si usas detalles
    }
}
