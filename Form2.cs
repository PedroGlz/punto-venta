using Microsoft.EntityFrameworkCore;
using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class FormVenta : Form
    {
        private List<Producto> productosAgregados = new();
        private AppDbContext dbContext = new();
        private Usuario usuarioActual;

        public FormVenta(Usuario usuario)
        {
            InitializeComponent();
            labelFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            GenerarNuevoFolio();
            CargarTipoPagos();
            this.Shown += FormVenta_Shown;
            btnFinalizarVenta.Enabled = false;
            usuarioActual = usuario;
        }

        private void GenerarNuevoFolio()
        {
            int maxFolio = dbContext.Ventas.Any() ? dbContext.Ventas.Max(v => v.Folio) : 0;
            textNumTicket.Text = (maxFolio + 1).ToString("D7");
        }

        private void CargarTipoPagos()
        {
            using var db = new AppDbContext();
            var tipos = db.TiposPago.ToList();

            comboBoxTipoPago.DataSource = tipos;
            comboBoxTipoPago.DisplayMember = "Tipo";
            comboBoxTipoPago.ValueMember = "TipoPagoId";

            var index = tipos.FindIndex(t => t.TipoPagoId == 1);
            if (index >= 0)
            {
                comboBoxTipoPago.SelectedIndex = index;
            }
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            ConfigurarGridVenta();
        }

        private void FormVenta_Shown(object sender, EventArgs e)
        {
            textCodigoBarras.Focus();
        }

        private void textCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textCodigoBarras.Text))
            {
                AgregarProducto(textCodigoBarras.Text.Trim());
                textCodigoBarras.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void AgregarProducto(string entrada)
        {
            using var db = new AppDbContext();

            var producto = db.Productos.FirstOrDefault(p => p.Gtin == entrada);
            if (producto != null)
            {
                AgregarProductoAlGrid(producto);
                return;
            }

            var productosEncontrados = db.Productos
                .Where(p => EF.Functions.Like(p.Nombre.ToLower(), $"%{entrada.ToLower()}%"))
                .ToList();

            if (productosEncontrados.Count == 0)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            if (productosEncontrados.Count == 1)
            {
                AgregarProductoAlGrid(productosEncontrados[0]);
            }
            else
            {
                using var formSeleccion = new FormSeleccionProducto(productosEncontrados);
                if (formSeleccion.ShowDialog() == DialogResult.OK && formSeleccion.ProductoSeleccionado != null)
                {
                    AgregarProductoAlGrid(formSeleccion.ProductoSeleccionado);
                }
            }
        }

        private void AgregarProductoAlGrid(Producto producto)
        {
            foreach (DataGridViewRow fila in dataGridVenta.Rows)
            {
                if (fila.Cells["Nombre"].Value?.ToString() == producto.Nombre)
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    cantidadActual++;
                    fila.Cells["Cantidad"].Value = cantidadActual;

                    decimal precioVentaUnitario = Convert.ToDecimal(fila.Cells["PrecioVentaUnitario"].Value);
                    fila.Cells["Subtotal"].Value = (precioVentaUnitario * cantidadActual).ToString("0.00");

                    RecalcularTotal();
                    ActualizarCantidadProductos();
                    return;
                }
            }

            decimal precio = producto.PrecioVentaUnitario;
            dataGridVenta.Rows.Add(producto.Nombre, precio.ToString("0.00"), 1, precio.ToString("0.00"));

            RecalcularTotal();
            ActualizarCantidadProductos();
        }

        private void ConfigurarGridVenta()
        {
            dataGridVenta.AllowUserToAddRows = false;
            dataGridVenta.Columns.Clear();

            dataGridVenta.Columns.Add("Nombre", "Producto");
            dataGridVenta.Columns.Add("PrecioVentaUnitario", "PrecioVentaUnitario");
            dataGridVenta.Columns.Add("Cantidad", "Cantidad");
            dataGridVenta.Columns.Add("Subtotal", "Subtotal");

            dataGridVenta.Columns["Nombre"].ReadOnly = true;
            dataGridVenta.Columns["PrecioVentaUnitario"].ReadOnly = true;
            dataGridVenta.Columns["Subtotal"].ReadOnly = true;

            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Name = "Eliminar",
                Text = "Quitar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };

            btnEliminar.DefaultCellStyle.BackColor = Color.Red;
            btnEliminar.DefaultCellStyle.ForeColor = Color.White;
            dataGridVenta.Columns.Add(btnEliminar);

            dataGridVenta.CellEndEdit += dataGridVenta_CellEndEdit;
        }

        private void dataGridVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridVenta.Columns["Cantidad"].Index && e.RowIndex >= 0)
            {
                var fila = dataGridVenta.Rows[e.RowIndex];
                if (int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) && cantidad > 0)
                {
                    decimal precio = Convert.ToDecimal(fila.Cells["PrecioVentaUnitario"].Value);
                    fila.Cells["Subtotal"].Value = (cantidad * precio).ToString("0.00");
                }
                else
                {
                    fila.Cells["Cantidad"].Value = 1;
                    decimal precio = Convert.ToDecimal(fila.Cells["PrecioVentaUnitario"].Value);
                    fila.Cells["Subtotal"].Value = precio.ToString("0.00");
                }

                RecalcularTotal();
                ActualizarCantidadProductos();
            }
        }

        private void RecalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridVenta.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }
            labelTotal.Text = total.ToString("C");
        }

        private void ActualizarCantidadProductos()
        {
            int totalProductos = 0;
            foreach (DataGridViewRow row in dataGridVenta.Rows)
            {
                if (row.Cells["Cantidad"].Value != null)
                {
                    totalProductos += Convert.ToInt32(row.Cells["Cantidad"].Value);
                }
            }
            labelNumProductos.Text = totalProductos.ToString();
        }

        private void labelInfoCantidadProductos_Click(object sender, EventArgs e)
        {

        }

        private void labelNumProductos_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(labelTotal.Text, System.Globalization.NumberStyles.Currency, null, out decimal total) ||
                !decimal.TryParse(textSuPago.Text, out decimal pago))
            {
                MessageBox.Show("Datos de pago inválidos.");
                return;
            }

            if (pago < total)
            {
                MessageBox.Show("El pago es insuficiente.");
                return;
            }

            if (comboBoxTipoPago.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de pago.");
                return;
            }

            if (!int.TryParse(comboBoxTipoPago.SelectedValue.ToString(), out int tipoPagoIdSeleccionado))
            {
                MessageBox.Show("El valor del tipo de pago seleccionado no es válido.");
                return;
            }

            using var db = new AppDbContext();

            var venta = new Venta
            {
                Folio = int.Parse(textNumTicket.Text),
                Fecha = DateTime.Now,
                TotalVenta = total,
                TipoPagoId = tipoPagoIdSeleccionado,
                UsuarioId = usuarioActual.UsuarioId, // ✅ Aquí se guarda el usuario que hizo la venta
                NumeroProductos = int.TryParse(labelNumProductos.Text, out int numProd) ? numProd : 0,
                Pago = pago,
                Cambio = pago - total
            };

            try
            {
                db.Ventas.Add(venta);
                db.SaveChanges(); // importante para obtener el ID de venta
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la venta:\n{ex.InnerException?.Message ?? ex.Message}");
                return;
            }

            foreach (DataGridViewRow row in dataGridVenta.Rows)
            {
                if (row.IsNewRow) continue;

                string nombreProducto = row.Cells["Nombre"].Value?.ToString();
                var producto = db.Productos.FirstOrDefault(p => p.Nombre == nombreProducto);

                if (producto == null) continue;

                var cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                var precioUnitario = Convert.ToDecimal(row.Cells["Precio"].Value);
                var subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);

                var detalle = new DetalleVenta
                {
                    VentaId = venta.VentaId,
                    ProductoId = producto.ProductoId,
                    Cantidad = cantidad,
                    PrecioUnitario = precioUnitario,
                    Subtotal = subtotal
                };

                db.DetallesVenta.Add(detalle);
            }

            try
            {
                db.SaveChanges();
                MessageBox.Show("Venta guardada correctamente.");
                LimpiarFormularioVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los detalles de la venta:\n{ex.InnerException?.Message ?? ex.Message}");
            }
        }


        private void LimpiarFormularioVenta()
        {
            dataGridVenta.Rows.Clear();
            textCodigoBarras.Clear();
            textSuPago.Clear();
            labelSuCambio.Text = "0000.00";
            labelNumProductos.Text = "00";
            labelTotal.Text = "$0.00";
            GenerarNuevoFolio();
            textCodigoBarras.Focus();
            btnFinalizarVenta.Enabled = false;
        }

        private void buttonCancelarVenta_Click(object sender, EventArgs e)
        {
            LimpiarFormularioVenta();
        }

        private void comboBoxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textNumTicket_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
