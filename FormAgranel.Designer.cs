namespace PuntoVenta
{
    partial class FormAgranel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si se deben desechar los recursos administrados; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método requerido para admitir el Diseñador. No se debe modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            labelProducto = new Label();
            label1 = new Label();
            textGramos = new TextBox();
            label2 = new Label();
            textImporte = new TextBox();
            btnAgregarGranel = new Button();
            btnCancelar = new Button();
            textPrecio = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // labelProducto
            // 
            labelProducto.AutoSize = true;
            labelProducto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelProducto.Location = new Point(24, 20);
            labelProducto.Name = "labelProducto";
            labelProducto.Size = new Size(139, 21);
            labelProducto.TabIndex = 0;
            labelProducto.Text = "Producto: Jamón";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 103);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 1;
            label1.Text = "Cantidad (gramos):";
            // 
            // textGramos
            // 
            textGramos.Location = new Point(150, 100);
            textGramos.Name = "textGramos";
            textGramos.Size = new Size(100, 23);
            textGramos.TabIndex = 3;
            textGramos.TextChanged += textGramos_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 138);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 3;
            label2.Text = "Importe (pesos):";
            // 
            // textImporte
            // 
            textImporte.Location = new Point(150, 135);
            textImporte.Name = "textImporte";
            textImporte.Size = new Size(100, 23);
            textImporte.TabIndex = 1;
            textImporte.TextChanged += textImporte_TextChanged;
            // 
            // btnAgregarGranel
            // 
            btnAgregarGranel.BackColor = Color.FromArgb(192, 192, 255);
            btnAgregarGranel.Location = new Point(150, 176);
            btnAgregarGranel.Name = "btnAgregarGranel";
            btnAgregarGranel.Size = new Size(100, 30);
            btnAgregarGranel.TabIndex = 2;
            btnAgregarGranel.Text = "Agregar";
            btnAgregarGranel.UseVisualStyleBackColor = false;
            btnAgregarGranel.Click += btnAgregarGranel_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.AllowDrop = true;
            btnCancelar.Location = new Point(24, 176);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.TabIndex = 6;
            btnCancelar.TabStop = false;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // textPrecio
            // 
            textPrecio.Location = new Point(150, 66);
            textPrecio.Name = "textPrecio";
            textPrecio.Size = new Size(100, 23);
            textPrecio.TabIndex = 0;
            textPrecio.TabStop = false;
            textPrecio.TextChanged += textPrecio_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 69);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 7;
            label3.Text = "Precio por kg:";
            label3.Click += label3_Click;
            // 
            // FormAgranel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 227);
            Controls.Add(textPrecio);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregarGranel);
            Controls.Add(textImporte);
            Controls.Add(label2);
            Controls.Add(textGramos);
            Controls.Add(label1);
            Controls.Add(labelProducto);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormAgranel";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Producto a Granel";
            Load += FormAgranel_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textGramos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textImporte;
        private System.Windows.Forms.Button btnAgregarGranel;
        private System.Windows.Forms.Button btnCancelar;
        private TextBox textPrecio;
        private Label label3;
    }
}
