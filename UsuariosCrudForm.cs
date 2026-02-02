using Microsoft.EntityFrameworkCore;
using PuntoVenta.Models;

namespace PuntoVenta
{
    public class UsuariosCrudForm : Form
    {
        private readonly Usuario usuarioActual;
        private DataGridView tablaUsuarios = null!;
        private TextBox txtNombre = null!;
        private TextBox txtPassword = null!;
        private ComboBox cboTipoUsuario = null!;
        private Button btnNuevo = null!;
        private Button btnGuardar = null!;
        private Button btnEliminar = null!;
        private Button btnCancelar = null!;
        private int? usuarioIdSeleccionado;

        public UsuariosCrudForm(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
            CargarTiposUsuario();
            CargarUsuarios();
            PrepararModoNuevo();
        }

        private void InitializeComponent()
        {
            tablaUsuarios = new DataGridView();
            txtNombre = new TextBox();
            txtPassword = new TextBox();
            cboTipoUsuario = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            var lblNombre = new Label();
            var lblPassword = new Label();
            var lblTipoUsuario = new Label();

            SuspendLayout();

            tablaUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tablaUsuarios.Location = new Point(16, 120);
            tablaUsuarios.Size = new Size(1248, 544);
            tablaUsuarios.AllowUserToAddRows = false;
            tablaUsuarios.AllowUserToDeleteRows = false;
            tablaUsuarios.ReadOnly = true;
            tablaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaUsuarios.MultiSelect = false;
            tablaUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tablaUsuarios.CellDoubleClick += tablaUsuarios_CellDoubleClick;

            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(16, 20);
            lblNombre.Text = "Usuario:";

            txtNombre.Location = new Point(16, 42);
            txtNombre.Size = new Size(280, 23);

            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(312, 20);
            lblPassword.Text = "Password:";

            txtPassword.Location = new Point(312, 42);
            txtPassword.Size = new Size(280, 23);

            lblTipoUsuario.AutoSize = true;
            lblTipoUsuario.Location = new Point(608, 20);
            lblTipoUsuario.Text = "Tipo Usuario:";

            cboTipoUsuario.Location = new Point(608, 42);
            cboTipoUsuario.Size = new Size(200, 23);
            cboTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;

            btnNuevo.Location = new Point(16, 78);
            btnNuevo.Size = new Size(88, 30);
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;

            btnGuardar.BackColor = Color.FromArgb(0, 64, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(112, 78);
            btnGuardar.Size = new Size(88, 30);
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnEliminar.BackColor = Color.Maroon;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(208, 78);
            btnEliminar.Size = new Size(88, 30);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            btnCancelar.Location = new Point(304, 78);
            btnCancelar.Size = new Size(88, 30);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;

            ClientSize = new Size(1280, 680);
            Controls.Add(tablaUsuarios);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblTipoUsuario);
            Controls.Add(cboTipoUsuario);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(btnCancelar);
            Name = "UsuariosCrudForm";
            Text = $"Usuarios - Admin: {usuarioActual.NombreUsuario}";

            ResumeLayout(false);
            PerformLayout();
        }

        private void CargarTiposUsuario()
        {
            using var db = new AppDbContext();
            var tipos = db.TiposUsuario
                .AsNoTracking()
                .OrderBy(t => t.TipoUsuarioId)
                .ToList();

            cboTipoUsuario.DataSource = tipos;
            cboTipoUsuario.DisplayMember = "Tipo";
            cboTipoUsuario.ValueMember = "TipoUsuarioId";
        }

        private void CargarUsuarios()
        {
            using var db = new AppDbContext();
            var usuarios = db.Usuarios
                .AsNoTracking()
                .Join(db.TiposUsuario.AsNoTracking(),
                    u => u.TipoUsuarioId,
                    t => t.TipoUsuarioId,
                    (u, t) => new
                    {
                        u.UsuarioId,
                        u.NombreUsuario,
                        u.Password,
                        TipoUsuarioId = u.TipoUsuarioId,
                        TipoUsuario = t.Tipo
                    })
                .OrderBy(u => u.UsuarioId)
                .ToList();

            tablaUsuarios.DataSource = usuarios;

            if (tablaUsuarios.Columns.Contains("TipoUsuarioId"))
                tablaUsuarios.Columns["TipoUsuarioId"].Visible = false;
        }

        private void PrepararModoNuevo()
        {
            usuarioIdSeleccionado = null;
            txtNombre.Clear();
            txtPassword.Clear();
            if (cboTipoUsuario.Items.Count > 0)
                cboTipoUsuario.SelectedIndex = 0;
            tablaUsuarios.ClearSelection();
        }

        private void tablaUsuarios_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = tablaUsuarios.Rows[e.RowIndex];
            usuarioIdSeleccionado = Convert.ToInt32(row.Cells["UsuarioId"].Value);
            txtNombre.Text = row.Cells["NombreUsuario"].Value?.ToString() ?? string.Empty;
            txtPassword.Text = row.Cells["Password"].Value?.ToString() ?? string.Empty;
            cboTipoUsuario.SelectedValue = Convert.ToInt32(row.Cells["TipoUsuarioId"].Value);
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            PrepararModoNuevo();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            PrepararModoNuevo();
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            var nombre = txtNombre.Text.Trim();
            var password = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Usuario y password son obligatorios.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTipoUsuario.SelectedValue == null || !int.TryParse(cboTipoUsuario.SelectedValue.ToString(), out var tipoUsuarioId))
            {
                MessageBox.Show("Selecciona un tipo de usuario valido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();
            var nombreDuplicado = db.Usuarios.Any(u => u.NombreUsuario == nombre && u.UsuarioId != (usuarioIdSeleccionado ?? 0));
            if (nombreDuplicado)
            {
                MessageBox.Show("Ese nombre de usuario ya existe.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuarioIdSeleccionado.HasValue)
            {
                var usuarioDb = db.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioIdSeleccionado.Value);
                if (usuarioDb == null)
                {
                    MessageBox.Show("No se encontro el usuario a editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                usuarioDb.NombreUsuario = nombre;
                usuarioDb.Password = password;
                usuarioDb.TipoUsuarioId = tipoUsuarioId;
            }
            else
            {
                db.Usuarios.Add(new Usuario
                {
                    NombreUsuario = nombre,
                    Password = password,
                    TipoUsuarioId = tipoUsuarioId
                });
            }

            db.SaveChanges();
            CargarUsuarios();
            PrepararModoNuevo();
            MessageBox.Show("Usuario guardado correctamente.");
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (!usuarioIdSeleccionado.HasValue)
            {
                MessageBox.Show("Selecciona un usuario para eliminar con doble clic.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (usuarioIdSeleccionado.Value == usuarioActual.UsuarioId)
            {
                MessageBox.Show("No puedes eliminar tu propio usuario en sesion.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("Deseas eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes)
                return;

            using var db = new AppDbContext();
            var usuarioDb = db.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioIdSeleccionado.Value);
            if (usuarioDb == null)
            {
                MessageBox.Show("No se encontro el usuario a eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.Usuarios.Remove(usuarioDb);
            db.SaveChanges();
            CargarUsuarios();
            PrepararModoNuevo();
            MessageBox.Show("Usuario eliminado correctamente.");
        }
    }
}
