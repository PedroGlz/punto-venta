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
        public MDIParent1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        // Método genérico para abrir formularios hijos dentro del MDI
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

        // Evento del menú para abrir el CRUD de productos (Form1)
        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form1>(); // Asegúrate que Form1 está en el mismo namespace
        }

        // Puedes conservar estos si los usas
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

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormVenta>();

        }
    }
}
