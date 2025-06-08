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
            this.Shown += FormVenta_Shown; // <- Agrega esta línea
            btnFinalizarVenta.Enabled = false;
            usuarioActual = usuario;
        }

        private void GenerarNuevoFolio()
        {
            int maxFolio = dbContext.Ventas.Any() ? dbContext.Ventas.Max(v => v.Folio) : 0;
            textNumTicket.Text = (maxFolio + 1).ToString("D7"); // Formato de 7 dígitos
        }
        private void CargarTipoPagos()
        {
            using var db = new AppDbContext();
            var tipos = db.TiposPago.ToList();

            comboBoxTipoPago.DataSource = tipos;
            comboBoxTipoPago.DisplayMember = "Tipo";
            comboBoxTipoPago.ValueMember = "TipoPagoId";

            // Seleccionar por defecto el tipo con TipoPagoId = 1
            var index = tipos.FindIndex(t => t.TipoPagoId == 1);
            if (index >= 0)
            {
                comboBoxTipoPago.SelectedIndex = index;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            ConfigurarGridVenta();
            dataGridVenta.CellClick += dataGridVenta_CellClick;
        }

        private void FormVenta_Shown(object sender, EventArgs e)
        {
            textCodigoBarras.Focus();
        }

        private void textCodigoBarras_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            // Buscar por código de barras exacto
            var producto = db.Productos.FirstOrDefault(p => p.Gtin == entrada);

            if (producto != null)
            {
                AgregarProductoAlGrid(producto);
                return;
            }

            // Buscar coincidencias por nombre parcial
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
                // Mostrar formulario de selección si hay varias coincidencias
                using var formSeleccion = new FormSeleccionProducto(productosEncontrados);
                if (formSeleccion.ShowDialog() == DialogResult.OK && formSeleccion.ProductoSeleccionado != null)
                {
                    AgregarProductoAlGrid(formSeleccion.ProductoSeleccionado);
                }
            }
        }

        private void AgregarProductoAlGrid(Producto producto)
        {
            dataGridVenta.Rows.Add(producto.Nombre, producto.PrecioVenta, 1, producto.PrecioVenta);
            RecalcularTotal();
            ActualizarCantidadProductos();
        }

        private void textSuPago_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(labelTotal.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out decimal total))
            {
                labelSuCambio.Text = "";
                btnFinalizarVenta.Enabled = false;
                return;
            }

            if (decimal.TryParse(textSuPago.Text, out decimal pago))
            {
                decimal cambio = pago - total;
                labelSuCambio.Text = cambio >= 0 ? cambio.ToString("C") : "$0.00";
                btnFinalizarVenta.Enabled = cambio >= 0;
            }
            else
            {
                labelSuCambio.Text = "";
                btnFinalizarVenta.Enabled = false;
            }
        }



        private void ActualizarTablaYTotal()
        {
            // Crea una lista anónima solo con lo necesario
            var datosParaMostrar = productosAgregados.Select(p => new
            {
                p.Nombre,
                p.PrecioVenta
            }).ToList();

            dataGridVenta.DataSource = null;
            dataGridVenta.DataSource = datosParaMostrar;

            // Calcular el total
            decimal total = productosAgregados.Sum(p => p.PrecioVenta);
            labelTotal.Text = total.ToString("C"); // "C" muestra como moneda, ej. $123.00

            // Mostrar número de productos
            labelNumProductos.Text = productosAgregados.Count.ToString();
        }

        private void ConfigurarGridVenta()
        {
            dataGridVenta.AllowUserToAddRows = false;    // Evita que el usuario agregue filas manualmente

            dataGridVenta.Columns.Clear();

            dataGridVenta.Columns.Add("Nombre", "Producto");
            dataGridVenta.Columns.Add("Precio", "Precio");
            dataGridVenta.Columns.Add("Cantidad", "Cantidad");
            dataGridVenta.Columns.Add("Subtotal", "Subtotal");

            dataGridVenta.Columns["Nombre"].Width = 510;

            // Botón para eliminar
            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Name = "Eliminar",
                Text = "Quitar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat // Mejora la apariencia
            };

            // Estilo: fondo rojo y texto blanco
            btnEliminar.DefaultCellStyle.BackColor = Color.Red;
            btnEliminar.DefaultCellStyle.ForeColor = Color.White;
            dataGridVenta.Columns.Add(btnEliminar);
        }



        private void dataGridVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridVenta.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                var fila = dataGridVenta.Rows[e.RowIndex];

                int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                decimal precioUnitario = Convert.ToDecimal(fila.Cells["Precio"].Value);

                if (cantidadActual > 1)
                {
                    cantidadActual--;
                    fila.Cells["Cantidad"].Value = cantidadActual;
                    fila.Cells["Subtotal"].Value = cantidadActual * precioUnitario;
                }
                else
                {
                    dataGridVenta.Rows.RemoveAt(e.RowIndex);
                }

                RecalcularTotal();
                ActualizarCantidadProductos();  // <--- actualizar aquí
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
    }
}
