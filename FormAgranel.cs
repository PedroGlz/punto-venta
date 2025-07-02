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
    public partial class FormAgranel : Form
    {
        public decimal Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }

        private decimal precioPorKilo;
        private bool actualizando = false;
        private decimal gramosDefault = 1000; // Valor por defecto en gramos

        public FormAgranel(string nombreProducto, decimal precioPorKilo)
        {
            InitializeComponent();
            this.precioPorKilo = precioPorKilo;
            labelProducto.Text = nombreProducto;
            //labelProducto.Text = $"{producto.Nombre} - ${producto.PrecioVentaUnitario:0.00}";
            textPrecio.Text = precioPorKilo.ToString("0.00");
            textGramos.Text = gramosDefault.ToString();
            textImporte.Text = ((precioPorKilo / gramosDefault) * gramosDefault).ToString("0.00");
        }

        private void radioCantidad_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioImporte_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormAgranel_Load(object sender, EventArgs e)
        {

        }

        private void textPrecio_TextChanged(object sender, EventArgs e)
        {
            textGramos.Text = string.Empty;
            textImporte.Text = string.Empty;

        }

        private void textGramos_TextChanged(object sender, EventArgs e)
        {
            if (actualizando) return;
            actualizando = true;
            if (decimal.TryParse(textPrecio.Text, out decimal precio) && decimal.TryParse(textGramos.Text, out decimal gramos) && gramos > 0)
            {
                decimal importe = (precio / this.gramosDefault) * gramos;
                textImporte.Text = importe.ToString("0.00");
            }
            else
            {
                textImporte.Text = string.Empty;
            }
            actualizando = false;
        }

        private void textImporte_TextChanged(object sender, EventArgs e)
        {
            if (actualizando) return;
            actualizando = true;
            if (decimal.TryParse(textPrecio.Text, out decimal precio) && decimal.TryParse(textImporte.Text, out decimal importe) && precio > 0)
            {
                decimal gramos = (importe * this.gramosDefault) / precio;
                textGramos.Text = gramos.ToString("0.##");
            }
            else
            {
                textGramos.Text = string.Empty;
            }
            actualizando = false;
        }
    }
}
