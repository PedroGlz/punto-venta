using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;


namespace PuntoVenta
{
    public partial class FormSeleccionProducto : Form
    {
        public Producto ProductoSeleccionado { get; private set; }

        public FormSeleccionProducto(List<Producto> productos)
        {
            InitializeComponent();

            // Ordenar la lista por nombre ascendentemente
            var productosOrdenados = productos.OrderBy(p => p.Nombre).ToList();

            dataGridViewProductos.AutoGenerateColumns = false;
            dataGridViewProductos.Columns.Clear();

            var colNombre = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Producto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            var colPrecio = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioVentaUnitario",
                HeaderText = "Precio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = { Format = "C2" }
            };

            dataGridViewProductos.Columns.Add(colNombre);
            dataGridViewProductos.Columns.Add(colPrecio);

            // Asignar los productos ya ordenados
            dataGridViewProductos.DataSource = productosOrdenados;
        }


        private void FormSeleccionProducto_Load(object sender, EventArgs e)
        {
            dataGridViewProductos.ClearSelection();
        }

        private void dataGridViewProductos_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarProducto();
        }

        private void dataGridViewProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void SeleccionarProducto()
        {
            if (dataGridViewProductos.CurrentRow != null)
            {
                ProductoSeleccionado = dataGridViewProductos.CurrentRow.DataBoundItem as Producto;
                if (ProductoSeleccionado != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
