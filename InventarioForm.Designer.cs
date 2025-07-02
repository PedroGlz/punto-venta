namespace PuntoVenta
{
    partial class InventarioForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tablaProductos = new DataGridView();
            textNombre = new TextBox();
            txtPrecioCompra = new TextBox();
            textCantDisponible = new TextBox();
            btnAgregar = new Button();
            labelNombre = new Label();
            labelPrecioCompra = new Label();
            labelCantDisponible = new Label();
            labelCantMin = new Label();
            textCantMin = new TextBox();
            labelPrecioVentaUnitario = new Label();
            textPrecioVentaUnitario = new TextBox();
            labelGtin = new Label();
            textGtin = new TextBox();
            labelUtilidadUnitaria = new Label();
            textUtilidadUnitaria = new TextBox();
            btnGuardarEdicion = new Button();
            btnCancelarEdicion = new Button();
            textBuscar = new TextBox();
            labelBuscar = new Label();
            menuStrip1 = new MenuStrip();
            buttonLimpiarBuscar = new Button();
            labelPrecioVentaMsyoreo = new Label();
            textPrecioVentaMayoreo = new TextBox();
            labelUtilidadMayoreo = new Label();
            textUtilidadMayoreo = new TextBox();
            label1 = new Label();
            textCantMinMayoreo = new TextBox();
            checkAgranel = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)tablaProductos).BeginInit();
            SuspendLayout();
            // 
            // tablaProductos
            // 
            tablaProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tablaProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaProductos.Location = new Point(12, 144);
            tablaProductos.Name = "tablaProductos";
            tablaProductos.RowHeadersWidth = 51;
            tablaProductos.Size = new Size(1386, 294);
            tablaProductos.TabIndex = 8;
            tablaProductos.TabStop = false;
            tablaProductos.CellContentClick += tablaProductos_CellContentClick;
            tablaProductos.CellDoubleClick += tablaProductos_CellDoubleClick;
            tablaProductos.CellFormatting += tablaProductos_CellFormatting;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(221, 43);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(294, 23);
            textNombre.TabIndex = 1;
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Location = new Point(591, 43);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(89, 23);
            txtPrecioCompra.TabIndex = 2;
            txtPrecioCompra.TextChanged += txtPrecioCompra_TextChanged;
            // 
            // textCantDisponible
            // 
            textCantDisponible.Location = new Point(1125, 44);
            textCantDisponible.Name = "textCantDisponible";
            textCantDisponible.Size = new Size(100, 23);
            textCantDisponible.TabIndex = 6;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(0, 64, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(1319, 40);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(82, 29);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(221, 25);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(54, 15);
            labelNombre.TabIndex = 10;
            labelNombre.Text = "Nombre:";
            // 
            // labelPrecioCompra
            // 
            labelPrecioCompra.AutoSize = true;
            labelPrecioCompra.Location = new Point(591, 25);
            labelPrecioCompra.Name = "labelPrecioCompra";
            labelPrecioCompra.Size = new Size(89, 15);
            labelPrecioCompra.TabIndex = 11;
            labelPrecioCompra.Text = "Precio Compra:";
            // 
            // labelCantDisponible
            // 
            labelCantDisponible.AutoSize = true;
            labelCantDisponible.Location = new Point(1125, 26);
            labelCantDisponible.Name = "labelCantDisponible";
            labelCantDisponible.Size = new Size(97, 15);
            labelCantDisponible.TabIndex = 14;
            labelCantDisponible.Text = "Cant. Disponible:";
            // 
            // labelCantMin
            // 
            labelCantMin.AutoSize = true;
            labelCantMin.Location = new Point(1231, 26);
            labelCantMin.Name = "labelCantMin";
            labelCantMin.Size = new Size(82, 15);
            labelCantMin.TabIndex = 15;
            labelCantMin.Text = "Cant. Minima:";
            // 
            // textCantMin
            // 
            textCantMin.Location = new Point(1231, 44);
            textCantMin.Name = "textCantMin";
            textCantMin.Size = new Size(82, 23);
            textCantMin.TabIndex = 7;
            // 
            // labelPrecioVentaUnitario
            // 
            labelPrecioVentaUnitario.AutoSize = true;
            labelPrecioVentaUnitario.Location = new Point(685, 7);
            labelPrecioVentaUnitario.Name = "labelPrecioVentaUnitario";
            labelPrecioVentaUnitario.Size = new Size(60, 30);
            labelPrecioVentaUnitario.TabIndex = 12;
            labelPrecioVentaUnitario.Text = "Precio\r\nVenta Uni:";
            labelPrecioVentaUnitario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPrecioVentaUnitario
            // 
            textPrecioVentaUnitario.Location = new Point(686, 43);
            textPrecioVentaUnitario.Name = "textPrecioVentaUnitario";
            textPrecioVentaUnitario.Size = new Size(75, 23);
            textPrecioVentaUnitario.TabIndex = 3;
            textPrecioVentaUnitario.TextChanged += textPrecioVentaUnitario_TextChanged;
            // 
            // labelGtin
            // 
            labelGtin.AutoSize = true;
            labelGtin.Location = new Point(12, 25);
            labelGtin.Name = "labelGtin";
            labelGtin.Size = new Size(37, 15);
            labelGtin.TabIndex = 9;
            labelGtin.Text = "GTIN:";
            // 
            // textGtin
            // 
            textGtin.Location = new Point(12, 43);
            textGtin.Name = "textGtin";
            textGtin.Size = new Size(203, 23);
            textGtin.TabIndex = 0;
            textGtin.KeyDown += textGtin_KeyDown;
            // 
            // labelUtilidadUnitaria
            // 
            labelUtilidadUnitaria.AutoSize = true;
            labelUtilidadUnitaria.Location = new Point(765, 25);
            labelUtilidadUnitaria.Name = "labelUtilidadUnitaria";
            labelUtilidadUnitaria.Size = new Size(72, 15);
            labelUtilidadUnitaria.TabIndex = 13;
            labelUtilidadUnitaria.Text = "Utilidad Uni:";
            // 
            // textUtilidadUnitaria
            // 
            textUtilidadUnitaria.Location = new Point(765, 43);
            textUtilidadUnitaria.Name = "textUtilidadUnitaria";
            textUtilidadUnitaria.ReadOnly = true;
            textUtilidadUnitaria.Size = new Size(80, 23);
            textUtilidadUnitaria.TabIndex = 0;
            textUtilidadUnitaria.TabStop = false;
            // 
            // btnGuardarEdicion
            // 
            btnGuardarEdicion.BackColor = Color.FromArgb(0, 64, 0);
            btnGuardarEdicion.ForeColor = Color.White;
            btnGuardarEdicion.Location = new Point(12, 81);
            btnGuardarEdicion.Name = "btnGuardarEdicion";
            btnGuardarEdicion.Size = new Size(82, 29);
            btnGuardarEdicion.TabIndex = 11;
            btnGuardarEdicion.Text = "Guardar";
            btnGuardarEdicion.UseVisualStyleBackColor = false;
            btnGuardarEdicion.Visible = false;
            btnGuardarEdicion.Click += btnGuardarEdicion_Click;
            // 
            // btnCancelarEdicion
            // 
            btnCancelarEdicion.Location = new Point(100, 81);
            btnCancelarEdicion.Name = "btnCancelarEdicion";
            btnCancelarEdicion.Size = new Size(82, 29);
            btnCancelarEdicion.TabIndex = 12;
            btnCancelarEdicion.Text = "Cancelar";
            btnCancelarEdicion.UseVisualStyleBackColor = true;
            btnCancelarEdicion.Visible = false;
            btnCancelarEdicion.Click += btnCancelarEdicion_Click;
            // 
            // textBuscar
            // 
            textBuscar.Location = new Point(1038, 115);
            textBuscar.Name = "textBuscar";
            textBuscar.Size = new Size(301, 23);
            textBuscar.TabIndex = 9;
            textBuscar.TextChanged += textBuscar_TextChanged;
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Location = new Point(837, 117);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(179, 15);
            labelBuscar.TabIndex = 0;
            labelBuscar.Text = "Buscar (Nombre/Código Barras):";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1414, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // buttonLimpiarBuscar
            // 
            buttonLimpiarBuscar.Location = new Point(1345, 112);
            buttonLimpiarBuscar.Name = "buttonLimpiarBuscar";
            buttonLimpiarBuscar.Size = new Size(56, 26);
            buttonLimpiarBuscar.TabIndex = 10;
            buttonLimpiarBuscar.Text = "Borrar";
            buttonLimpiarBuscar.UseVisualStyleBackColor = true;
            buttonLimpiarBuscar.Click += buttonLimpiarBuscar_Click;
            // 
            // labelPrecioVentaMsyoreo
            // 
            labelPrecioVentaMsyoreo.AutoSize = true;
            labelPrecioVentaMsyoreo.Location = new Point(850, 10);
            labelPrecioVentaMsyoreo.Name = "labelPrecioVentaMsyoreo";
            labelPrecioVentaMsyoreo.Size = new Size(65, 30);
            labelPrecioVentaMsyoreo.TabIndex = 24;
            labelPrecioVentaMsyoreo.Text = "Precio\r\nVenta May:";
            labelPrecioVentaMsyoreo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPrecioVentaMayoreo
            // 
            textPrecioVentaMayoreo.Location = new Point(850, 44);
            textPrecioVentaMayoreo.Name = "textPrecioVentaMayoreo";
            textPrecioVentaMayoreo.Size = new Size(75, 23);
            textPrecioVentaMayoreo.TabIndex = 4;
            textPrecioVentaMayoreo.TextChanged += textPrecioVentaMayoreo_TextChanged;
            // 
            // labelUtilidadMayoreo
            // 
            labelUtilidadMayoreo.AutoSize = true;
            labelUtilidadMayoreo.Location = new Point(930, 26);
            labelUtilidadMayoreo.Name = "labelUtilidadMayoreo";
            labelUtilidadMayoreo.Size = new Size(77, 15);
            labelUtilidadMayoreo.TabIndex = 26;
            labelUtilidadMayoreo.Text = "Utilidad May:";
            // 
            // textUtilidadMayoreo
            // 
            textUtilidadMayoreo.Location = new Point(930, 44);
            textUtilidadMayoreo.Name = "textUtilidadMayoreo";
            textUtilidadMayoreo.ReadOnly = true;
            textUtilidadMayoreo.Size = new Size(85, 23);
            textUtilidadMayoreo.TabIndex = 0;
            textUtilidadMayoreo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1020, 10);
            label1.Name = "label1";
            label1.Size = new Size(81, 30);
            label1.TabIndex = 28;
            label1.Text = "Cant. \r\nMin Mayoreo:";
            // 
            // textCantMinMayoreo
            // 
            textCantMinMayoreo.Location = new Point(1020, 44);
            textCantMinMayoreo.Name = "textCantMinMayoreo";
            textCantMinMayoreo.Size = new Size(100, 23);
            textCantMinMayoreo.TabIndex = 5;
            // 
            // checkAgranel
            // 
            checkAgranel.AutoSize = true;
            checkAgranel.Location = new Point(521, 48);
            checkAgranel.Name = "checkAgranel";
            checkAgranel.Size = new Size(67, 19);
            checkAgranel.TabIndex = 29;
            checkAgranel.Text = "Por Kilo";
            checkAgranel.UseVisualStyleBackColor = true;
            checkAgranel.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // InventarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 450);
            Controls.Add(checkAgranel);
            Controls.Add(label1);
            Controls.Add(textCantMinMayoreo);
            Controls.Add(labelUtilidadMayoreo);
            Controls.Add(textUtilidadMayoreo);
            Controls.Add(labelPrecioVentaMsyoreo);
            Controls.Add(textPrecioVentaMayoreo);
            Controls.Add(buttonLimpiarBuscar);
            Controls.Add(labelBuscar);
            Controls.Add(textBuscar);
            Controls.Add(btnCancelarEdicion);
            Controls.Add(btnGuardarEdicion);
            Controls.Add(labelUtilidadUnitaria);
            Controls.Add(textUtilidadUnitaria);
            Controls.Add(labelGtin);
            Controls.Add(textGtin);
            Controls.Add(labelPrecioVentaUnitario);
            Controls.Add(textPrecioVentaUnitario);
            Controls.Add(labelCantMin);
            Controls.Add(textCantMin);
            Controls.Add(labelCantDisponible);
            Controls.Add(labelPrecioCompra);
            Controls.Add(labelNombre);
            Controls.Add(btnAgregar);
            Controls.Add(textCantDisponible);
            Controls.Add(txtPrecioCompra);
            Controls.Add(textNombre);
            Controls.Add(tablaProductos);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "InventarioForm";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)tablaProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tablaProductos;
        private TextBox textNombre;
        private TextBox txtPrecioCompra;
        private TextBox textCantDisponible;
        private TextBox textCantMin;
        private TextBox textPrecioVentaUnitario;
        private TextBox textGtin;
        private TextBox textUtilidadUnitaria;


        private Button btnAgregar;
        private Label labelNombre;
        private Label labelPrecioCompra;
        private Label labelCantDisponible;
        private Label labelCantMin;
        private Label labelPrecioVentaUnitario;
        private Label labelGtin;
        private Label labelUtilidadUnitaria;
        private Button btnGuardarEdicion;
        private Button btnCancelarEdicion;
        private TextBox textBuscar;
        private Label labelBuscar;
        private MenuStrip menuStrip1;
        private Button buttonLimpiarBuscar;
        private Label labelPrecioVentaMsyoreo;
        private TextBox textPrecioVentaMayoreo;
        private Label labelUtilidadMayoreo;
        private TextBox textUtilidadMayoreo;
        private Label label1;
        private TextBox textCantMinMayoreo;
        private CheckBox checkAgranel;
    }
}
