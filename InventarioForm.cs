using PuntoVenta.Models;

namespace PuntoVenta
{
    public partial class InventarioForm : Form
    {
        private int? selectedProductoId = null;
        private Usuario usuarioActual;
        public InventarioForm(Usuario usuario)
        {
            InitializeComponent();
            CargarProductos();
            usuarioActual = usuario;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textGtin.Focus();
            tablaProductos.ReadOnly = true;
            tablaProductos.AllowUserToAddRows = false;
            tablaProductos.AllowUserToDeleteRows = false;
            tablaProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            using var db = new AppDbContext();

            if (db.Productos.Any(p => p.Gtin == textGtin.Text))
            {
                MessageBox.Show("Ya existe un producto con ese GTIN.", "GTIN duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var producto = new Producto
                {
                    Gtin = textGtin.Text,
                    Nombre = textNombre.Text,
                    aGranel = checkAgranel.Checked,
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    PrecioVentaUnitario = decimal.Parse(textPrecioVentaUnitario.Text),
                    UtilidadUnitaria = decimal.Parse(textUtilidadUnitaria.Text),
                    PrecioVentaMayoreo = decimal.Parse(textPrecioVentaMayoreo.Text),
                    UtilidadMayoreo = decimal.Parse(textUtilidadMayoreo.Text),
                    CantidadMinimaMayoreo = int.Parse(textCantMinMayoreo.Text),
                    CantidadDisponible = int.Parse(textCantDisponible.Text),
                    CantidadMinimaDisponible = int.Parse(textCantMin.Text),
                    FechaCreacion = DateTime.Now,
                    CreadoPor = usuarioActual.UsuarioId
                };

                db.Productos.Add(producto);
                db.SaveChanges();
                MessageBox.Show("Producto agregado correctamente");
                LimpiarCampos();
                CargarProductos();
                textGtin.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message);
            }
        }

        private void textGtin_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"KeyCode: {e.KeyCode}");
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }

        private void CargarProductos()
        {
            using var db = new AppDbContext();
            tablaProductos.DataSource = db.Productos
                .OrderBy(p => p.Nombre)
                .ToList();

            if (tablaProductos.Columns.Contains("ProductoId"))
                tablaProductos.Columns["ProductoId"].Visible = false;

            if (tablaProductos.Columns.Contains("Nombre"))
                tablaProductos.Columns["Nombre"].Width = 480;

            AgregarColumnaEliminar();
        }

        private void AgregarColumnaEliminar()
        {
            if (!tablaProductos.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Acciones";
                btnEliminar.Text = "Eliminar";
                btnEliminar.Name = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                tablaProductos.Columns.Add(btnEliminar);
            }
        }

        private void tablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaProductos.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                var fila = tablaProductos.Rows[e.RowIndex];
                int id = (int)fila.Cells["ProductoId"].Value;

                var confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                   "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    using var db = new AppDbContext();
                    var producto = db.Productos.Find(id);
                    if (producto != null)
                    {
                        db.Productos.Remove(producto);
                        db.SaveChanges();
                        MessageBox.Show("Producto eliminado correctamente.");
                        CargarProductos();
                    }
                }
            }
        }

        private void tablaProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tablaProductos.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DataGridViewButtonCell btn = tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                if (btn != null)
                {
                    btn.Style.BackColor = Color.Red;
                    btn.Style.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        private void LimpiarCampos()
        {
            textGtin.Text = "";
            textNombre.Text = "";
            checkAgranel.Checked = false;
            txtPrecioCompra.Text = "";
            textPrecioVentaUnitario.Text = "";
            textUtilidadUnitaria.Text = "";
            textPrecioVentaMayoreo.Text = "";
            textUtilidadMayoreo.Text = "";
            textCantMinMayoreo.Text = "";
            textCantDisponible.Text = "";
            textCantMin.Text = "";
            selectedProductoId = null;
        }

        private void tablaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = tablaProductos.Rows[e.RowIndex];
                selectedProductoId = (int)fila.Cells["ProductoId"].Value;

                textGtin.Text = fila.Cells["Gtin"].Value.ToString();
                textNombre.Text = fila.Cells["Nombre"].Value.ToString();
                checkAgranel.Checked = (bool)fila.Cells["aGranel"].Value;
                txtPrecioCompra.Text = fila.Cells["PrecioCompra"].Value.ToString();
                textPrecioVentaUnitario.Text = fila.Cells["PrecioVentaUnitario"].Value.ToString();
                textUtilidadUnitaria.Text = fila.Cells["UtilidadUnitaria"].Value.ToString();
                textPrecioVentaMayoreo.Text = fila.Cells["PrecioVentaMayoreo"].Value.ToString();
                textUtilidadMayoreo.Text = fila.Cells["UtilidadMayoreo"].Value.ToString();
                textCantMinMayoreo.Text = fila.Cells["CantidadMinimaMayoreo"].Value.ToString();
                textCantDisponible.Text = fila.Cells["CantidadDisponible"].Value.ToString();
                textCantMin.Text = fila.Cells["CantidadMinimaDisponible"].Value.ToString();

                btnAgregar.Visible = false;
                btnGuardarEdicion.Visible = true;
                btnCancelarEdicion.Visible = true;
            }
        }

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            using var db = new AppDbContext();

            Producto producto;

            if (selectedProductoId.HasValue)
            {
                producto = db.Productos.FirstOrDefault(p => p.ProductoId == selectedProductoId.Value);
                if (producto == null)
                {
                    MessageBox.Show("Error al encontrar el producto para editar.");
                    return;
                }
            }
            else
            {
                producto = new Producto();
                db.Productos.Add(producto);
            }

            producto.Gtin = textGtin.Text;
            producto.Nombre = textNombre.Text;
            producto.aGranel = checkAgranel.Checked;
            producto.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
            producto.PrecioVentaUnitario = decimal.Parse(textPrecioVentaUnitario.Text);
            producto.UtilidadUnitaria = decimal.Parse(textUtilidadUnitaria.Text);
            producto.PrecioVentaMayoreo = decimal.Parse(textPrecioVentaMayoreo.Text);
            producto.UtilidadMayoreo = decimal.Parse(textUtilidadMayoreo.Text);
            producto.CantidadMinimaMayoreo = int.Parse(textCantMinMayoreo.Text);
            producto.CantidadDisponible = int.Parse(textCantDisponible.Text);
            producto.CantidadMinimaDisponible = int.Parse(textCantMin.Text);

            db.SaveChanges();

            MessageBox.Show("Producto guardado correctamente.");
            LimpiarCampos();
            CargarProductos();

            selectedProductoId = null;
            btnAgregar.Visible = true;
            btnGuardarEdicion.Visible = false;
            btnCancelarEdicion.Visible = false;
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            selectedProductoId = null;
            LimpiarCampos();
            btnAgregar.Visible = true;
            btnGuardarEdicion.Visible = false;
            btnCancelarEdicion.Visible = false;
        }

        private void CalcularUtilidadUnitaria()
        {
            if (decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) &&
                decimal.TryParse(textPrecioVentaUnitario.Text, out decimal precioVenta))
            {
                decimal utilidad = precioVenta - precioCompra;
                textUtilidadUnitaria.Text = utilidad.ToString("0.00");
            }
            else
            {
                textUtilidadUnitaria.Text = "";
            }
        }

        private void CalcularUtilidadMayoreo()
        {
            if (decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) &&
                decimal.TryParse(textPrecioVentaMayoreo.Text, out decimal precioMayoreo))
            {
                decimal utilidad = precioMayoreo - precioCompra;
                textUtilidadMayoreo.Text = utilidad.ToString("0.00");
            }
            else
            {
                textUtilidadMayoreo.Text = "";
            }
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            CalcularUtilidadUnitaria();
            CalcularUtilidadMayoreo();
        }

        private void textPrecioVentaUnitario_TextChanged(object sender, EventArgs e)
        {
            CalcularUtilidadUnitaria();
        }

        private void textPrecioVentaMayoreo_TextChanged(object sender, EventArgs e)
        {
            CalcularUtilidadMayoreo();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textGtin.Text) ||
                string.IsNullOrWhiteSpace(textNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ||
                string.IsNullOrWhiteSpace(textPrecioVentaUnitario.Text) ||
                string.IsNullOrWhiteSpace(textUtilidadUnitaria.Text) ||
                string.IsNullOrWhiteSpace(textPrecioVentaMayoreo.Text) ||
                string.IsNullOrWhiteSpace(textUtilidadMayoreo.Text) ||
                string.IsNullOrWhiteSpace(textCantMinMayoreo.Text) ||
                string.IsNullOrWhiteSpace(textCantDisponible.Text) ||
                string.IsNullOrWhiteSpace(textCantMin.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos(textBuscar.Text);
        }

        private void FiltrarProductos(string criterio)
        {
            using var db = new AppDbContext();

            var productosFiltrados = db.Productos
                .Where(p =>
                    p.Nombre.ToLower().Contains(criterio.ToLower()) ||
                    p.Gtin.Contains(criterio)
                )
                .OrderBy(p => p.Nombre)
                .ToList();

            tablaProductos.DataSource = productosFiltrados;

            if (tablaProductos.Columns.Contains("ProductoId"))
                tablaProductos.Columns["ProductoId"].Visible = false;

            if (tablaProductos.Columns.Contains("Nombre"))
                tablaProductos.Columns["Nombre"].Width = 480;

            if (!tablaProductos.Columns.Contains("Eliminar"))
                AgregarColumnaEliminar();
        }

        private void buttonLimpiarBuscar_Click(object sender, EventArgs e)
        {
            textBuscar.Text = "";
            CargarProductos();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
