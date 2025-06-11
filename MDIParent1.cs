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
    public partial class MDIParent1 : Form
    {
        private Usuario usuarioActual;

        public MDIParent1(Usuario usuario)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.usuarioActual = usuario;
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            // ✅ Mostrar el nombre del usuario en el título del formulario
            this.Text = $"Punto de Venta - Sesión de: {usuarioActual.NombreUsuario}";
        }

        // ✅ Método genérico para abrir formularios hijos sin parámetros
        private void AbrirFormulario<T>() where T : Form, new()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close(); // Opcional: cierra cualquier formulario hijo abierto
            }

            Form formulario = new T
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            formulario.Show();
        }

        // ✅ Método para abrir formularios hijos que reciben Usuario
        private void AbrirFormularioConUsuario<T>() where T : Form
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            // Asume que el formulario tiene un constructor que acepta Usuario
            Form formulario = (Form)Activator.CreateInstance(typeof(T), usuarioActual);
            formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();
        }

        // ✅ Abrir Inventario con el Usuario
        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioConUsuario<InventarioForm>(); // CORREGIDO
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioConUsuario<FormVenta>();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}
