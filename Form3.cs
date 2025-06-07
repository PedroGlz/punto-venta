using PuntoVenta.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class FormLogin : Form
    {
        // ✅ Propiedad pública para acceder al usuario autenticado
        public Usuario UsuarioAutenticado { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
            textUsuario.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = textUsuario.Text.Trim();
            string clave = textClave.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                labelMensaje.Text = "Ingresa usuario y clave";
                return;
            }

            using var db = new AppDbContext();
            var user = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario);

            if (user != null && user.Password == clave) // Reemplazar con verificación hash si es necesario
            {
                UsuarioAutenticado = user; // ✅ Guarda el usuario autenticado
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                labelMensaje.Text = "Usuario o clave incorrectos";
            }
        }
    }
}
