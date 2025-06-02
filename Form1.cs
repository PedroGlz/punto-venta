using PuntoVenta.Models;

namespace PuntoVenta
{
    public partial class Form1 : Form
    {
        private int? selectedProductoId = null;

        public Form1()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textGtin.Focus();
            tablaProductos.ReadOnly = true;                  // Impide edición directa de celdas
            tablaProductos.AllowUserToAddRows = false;       // Evita que agreguen filas desde la interfaz
            tablaProductos.AllowUserToDeleteRows = false;    // Evita eliminación directa
            tablaProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!ValidarCampos())
                return;

            using var db = new AppDbContext();

            // Verificar si el GTIN ya existe
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
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    PrecioVenta = decimal.Parse(textPrecioVenta.Text),
                    Utilidad = decimal.Parse(textUtilidad.Text),
                    CantidadDisponible = int.Parse(textCantDisponible.Text), // Fixed conversion to int
                    CantidadMinima = int.Parse(textCantMin.Text) // Fixed conversion to int
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

        // Agrega este método para capturar y mostrar el KeyCode en consola:
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
            tablaProductos.DataSource = db.Productos.ToList();

            // Oculta la columna ProductoId si existe
            if (tablaProductos.Columns.Contains("ProductoId"))
            {
                tablaProductos.Columns["ProductoId"].Visible = false;
            }

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
            txtPrecioCompra.Text = "";
            textPrecioVenta.Text = "";
            textUtilidad.Text = "";
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
                txtPrecioCompra.Text = fila.Cells["PrecioCompra"].Value.ToString();
                textPrecioVenta.Text = fila.Cells["PrecioVenta"].Value.ToString();
                textUtilidad.Text = fila.Cells["Utilidad"].Value.ToString();
                textCantDisponible.Text = fila.Cells["CantidadDisponible"].Value.ToString();
                textCantMin.Text = fila.Cells["CantidadMinima"].Value.ToString();

                btnAgregar.Visible = false;
                btnGuardarEdicion.Visible = true;
                btnCancelarEdicion.Visible = true;
            }
        }

        private void textNombre_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            using var db = new AppDbContext();

            //// Verificar duplicado solo si es un nuevo producto o cambió el GTIN
            //var gtinExiste = db.Productos
            //    .Any(p => p.Gtin == textGtin.Text && p.ProductoId != selectedProductoId);

            //if (gtinExiste)
            //{
            //    MessageBox.Show("El GTIN ya está registrado para otro producto.");
            //    return;
            //}

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
            producto.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
            producto.PrecioVenta = decimal.Parse(textPrecioVenta.Text);
            producto.Utilidad = decimal.Parse(textUtilidad.Text);
            producto.CantidadDisponible = int.Parse(textCantDisponible.Text); // Fixed conversion to int
            producto.CantidadMinima = int.Parse(textCantMin.Text);

            db.SaveChanges();

            MessageBox.Show("Producto guardado correctamente.");
            LimpiarCampos();
            CargarProductos();

            // Volver a modo agregar
            selectedProductoId = null;
            btnAgregar.Visible = true;
            btnGuardarEdicion.Visible = false;
            btnCancelarEdicion.Visible = false;


        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            selectedProductoId = null;
            LimpiarCampos();
            // Volver a modo agregar
            selectedProductoId = null;
            btnAgregar.Visible = true;
            btnGuardarEdicion.Visible = false;
            btnCancelarEdicion.Visible = false;
        }

        private void CalcularUtilidad()
        {
            if (decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) &&
                decimal.TryParse(textPrecioVenta.Text, out decimal precioVenta))
            {
                decimal utilidad = precioVenta - precioCompra;
                textUtilidad.Text = utilidad.ToString("0.00");
            }
            else
            {
                textUtilidad.Text = "";
            }
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            CalcularUtilidad();
        }

        private void textPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            CalcularUtilidad();
        }

        private void SoloNumerosDecimalesPositivos(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permitir teclas de control como backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir solo dígitos y un punto decimal (no al inicio y no duplicado)
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == '.' && !textBox.Text.Contains(".") && textBox.SelectionStart != 0)
                    return;

                // Bloquear todo lo demás (como letras o '-')
                e.Handled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textGtin.Text) ||
                string.IsNullOrWhiteSpace(textNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ||
                string.IsNullOrWhiteSpace(textPrecioVenta.Text) ||
                string.IsNullOrWhiteSpace(textUtilidad.Text) ||
                string.IsNullOrWhiteSpace(textCantDisponible.Text) ||
                string.IsNullOrWhiteSpace(textCantMin.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos(textBuscar.Text);
        }

        private void FiltrarProductos(string criterio)
        {
            using var db = new AppDbContext();

            var productosFiltrados = db.Productos
                .Where(p => p.Nombre.ToLower().Contains(criterio.ToLower()))
                .Select(p => new
                {
                    p.ProductoId,
                    p.Gtin,
                    p.Nombre,
                    p.PrecioCompra,
                    p.PrecioVenta,
                    p.Utilidad,
                    p.CantidadDisponible,
                    p.CantidadMinima
                })
                .ToList(); // <- Esto materializa la consulta en memoria

            tablaProductos.DataSource = productosFiltrados;

            // Si aún quieres ocultar la columna ProductoId
            if (tablaProductos.Columns.Contains("ProductoId"))
                tablaProductos.Columns["ProductoId"].Visible = false;

            if (!tablaProductos.Columns.Contains("Eliminar"))
                AgregarColumnaEliminar();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textGtin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
