using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }  // clave primaria autoincremental (opcional)
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }  // Cantidad vendida de ese producto
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }  // Subtotal de la venta de ese producto (Cantidad * PrecioUnitario)
        // Opcional: Relaciones
        // public Venta Venta { get; set; }
        // public Producto Producto { get; set; }
    }
}
