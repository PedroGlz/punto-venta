using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class FormSeleccionProducto : Form
    {
        public Producto ProductoSeleccionado { get; private set; }

        public FormSeleccionProducto(List<Producto> productos)
        {
            InitializeComponent();
            dataGridViewProductos.DataSource = productos;
        }

        private void FormSeleccionProducto_Load(object sender, EventArgs e)
        {
            // Aquí puedes ajustar la visualización si es necesario
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
