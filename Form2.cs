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
using PuntoVenta.Models;
using Microsoft.EntityFrameworkCore;

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
        }

        private void GenerarNuevoFolio()
        {
            int maxFolio = dbContext.Ventas.Any() ? dbContext.Ventas.Max(v => v.Folio) : 0;
            textNumTicket.Text = (maxFolio + 1).ToString();
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

        }

        private void textCodigoBarras_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
