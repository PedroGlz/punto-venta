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
        public FormVenta()
        {
            InitializeComponent();
            labelFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            GenerarNuevoFolio();
            CargarTipoPagos();
            this.Shown += FormVenta_Shown; // <- Agrega esta línea

        }

        private void GenerarNuevoFolio()
        {
            int maxFolio = dbContext.Ventas.Any() ? dbContext.Ventas.Max(v => v.Folio) : 0;
            textNumTicket.Text = (maxFolio + 1).ToString();
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
                AgregarProductoPorCodigo(textCodigoBarras.Text.Trim());
                textCodigoBarras.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true; // Evita el sonido de error
            }
        }

        private void AgregarProductoPorCodigo(string codigoBarras)
        {
            using var db = new AppDbContext();
            var producto = db.Productos.FirstOrDefault(p => p.Gtin == codigoBarras);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            // Agregar SIEMPRE una nueva fila, sin importar si ya existe
            dataGridVenta.Rows.Add(producto.Nombre, producto.PrecioVenta, 1, producto.PrecioVenta);
            RecalcularTotal();
            ActualizarCantidadProductos();
        }


        private void textSuPago_TextChanged(object sender, EventArgs e)
        {
            // Asegúrate de que el total tenga un valor válido
            if (!decimal.TryParse(labelTotal.Text, System.Globalization.NumberStyles.Currency, null, out decimal total))
            {
                textSuCambio.Text = "";
                return;
            }

            // Leer el pago ingresado por el usuario
            if (decimal.TryParse(textSuPago.Text, out decimal pago))
            {
                decimal cambio = pago - total;
                textSuCambio.Text = cambio >= 0 ? cambio.ToString("C") : "$0.00"; // Muestra $0 si aún no alcanza
            }
            else
            {
                textSuCambio.Text = "";
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
            textNumProductos.Text = productosAgregados.Count.ToString();
        }

        private void ConfigurarGridVenta()
        {
            dataGridVenta.AllowUserToAddRows = false;    // Evita que el usuario agregue filas manualmente

            dataGridVenta.Columns.Clear();

            dataGridVenta.Columns.Add("Nombre", "Producto");
            dataGridVenta.Columns.Add("Precio", "Precio");
            dataGridVenta.Columns.Add("Cantidad", "Cantidad");
            dataGridVenta.Columns.Add("Subtotal", "Subtotal");

            // Botón para eliminar
            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Name = "Eliminar",
                Text = "Quitar",
                UseColumnTextForButtonValue = true
            };
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
            textNumProductos.Text = totalProductos.ToString();
        }



    }
}
