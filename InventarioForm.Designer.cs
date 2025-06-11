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
            ((System.ComponentModel.ISupportInitialize)tablaProductos).BeginInit();
            SuspendLayout();
            // 
            // tablaProductos
            // 
            tablaProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tablaProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaProductos.Location = new Point(14, 192);
            tablaProductos.Margin = new Padding(3, 4, 3, 4);
            tablaProductos.Name = "tablaProductos";
            tablaProductos.RowHeadersWidth = 51;
            tablaProductos.Size = new Size(1540, 392);
            tablaProductos.TabIndex = 8;
            tablaProductos.TabStop = false;
            tablaProductos.CellContentClick += tablaProductos_CellContentClick;
            tablaProductos.CellDoubleClick += tablaProductos_CellDoubleClick;
            tablaProductos.CellFormatting += tablaProductos_CellFormatting;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(253, 57);
            textNombre.Margin = new Padding(3, 4, 3, 4);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(335, 27);
            textNombre.TabIndex = 1;
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Location = new Point(598, 57);
            txtPrecioCompra.Margin = new Padding(3, 4, 3, 4);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(101, 27);
            txtPrecioCompra.TabIndex = 2;
            txtPrecioCompra.TextChanged += txtPrecioCompra_TextChanged;
            // 
            // textCantDisponible
            // 
            textCantDisponible.Location = new Point(1208, 58);
            textCantDisponible.Margin = new Padding(3, 4, 3, 4);
            textCantDisponible.Name = "textCantDisponible";
            textCantDisponible.Size = new Size(114, 27);
            textCantDisponible.TabIndex = 6;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(0, 64, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(1440, 53);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 39);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(253, 33);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(67, 20);
            labelNombre.TabIndex = 10;
            labelNombre.Text = "Nombre:";
            // 
            // labelPrecioCompra
            // 
            labelPrecioCompra.AutoSize = true;
            labelPrecioCompra.Location = new Point(598, 33);
            labelPrecioCompra.Name = "labelPrecioCompra";
            labelPrecioCompra.Size = new Size(110, 20);
            labelPrecioCompra.TabIndex = 11;
            labelPrecioCompra.Text = "Precio Compra:";
            // 
            // labelCantDisponible
            // 
            labelCantDisponible.AutoSize = true;
            labelCantDisponible.Location = new Point(1208, 34);
            labelCantDisponible.Name = "labelCantDisponible";
            labelCantDisponible.Size = new Size(121, 20);
            labelCantDisponible.TabIndex = 14;
            labelCantDisponible.Text = "Cant. Disponible:";
            // 
            // labelCantMin
            // 
            labelCantMin.AutoSize = true;
            labelCantMin.Location = new Point(1329, 34);
            labelCantMin.Name = "labelCantMin";
            labelCantMin.Size = new Size(99, 20);
            labelCantMin.TabIndex = 15;
            labelCantMin.Text = "Cant. Minima:";
            // 
            // textCantMin
            // 
            textCantMin.Location = new Point(1329, 58);
            textCantMin.Margin = new Padding(3, 4, 3, 4);
            textCantMin.Name = "textCantMin";
            textCantMin.Size = new Size(93, 27);
            textCantMin.TabIndex = 7;
            // 
            // labelPrecioVentaUnitario
            // 
            labelPrecioVentaUnitario.AutoSize = true;
            labelPrecioVentaUnitario.Location = new Point(705, 9);
            labelPrecioVentaUnitario.Name = "labelPrecioVentaUnitario";
            labelPrecioVentaUnitario.Size = new Size(75, 40);
            labelPrecioVentaUnitario.TabIndex = 12;
            labelPrecioVentaUnitario.Text = "Precio\r\nVenta Uni:";
            labelPrecioVentaUnitario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPrecioVentaUnitario
            // 
            textPrecioVentaUnitario.Location = new Point(706, 57);
            textPrecioVentaUnitario.Margin = new Padding(3, 4, 3, 4);
            textPrecioVentaUnitario.Name = "textPrecioVentaUnitario";
            textPrecioVentaUnitario.Size = new Size(85, 27);
            textPrecioVentaUnitario.TabIndex = 3;
            textPrecioVentaUnitario.TextChanged += textPrecioVentaUnitario_TextChanged;
            // 
            // labelGtin
            // 
            labelGtin.AutoSize = true;
            labelGtin.Location = new Point(14, 33);
            labelGtin.Name = "labelGtin";
            labelGtin.Size = new Size(45, 20);
            labelGtin.TabIndex = 9;
            labelGtin.Text = "GTIN:";
            // 
            // textGtin
            // 
            textGtin.Location = new Point(14, 57);
            textGtin.Margin = new Padding(3, 4, 3, 4);
            textGtin.Name = "textGtin";
            textGtin.Size = new Size(231, 27);
            textGtin.TabIndex = 0;
            textGtin.KeyDown += textGtin_KeyDown;
            // 
            // labelUtilidadUnitaria
            // 
            labelUtilidadUnitaria.AutoSize = true;
            labelUtilidadUnitaria.Location = new Point(797, 33);
            labelUtilidadUnitaria.Name = "labelUtilidadUnitaria";
            labelUtilidadUnitaria.Size = new Size(91, 20);
            labelUtilidadUnitaria.TabIndex = 13;
            labelUtilidadUnitaria.Text = "Utilidad Uni:";
            // 
            // textUtilidadUnitaria
            // 
            textUtilidadUnitaria.Location = new Point(797, 57);
            textUtilidadUnitaria.Margin = new Padding(3, 4, 3, 4);
            textUtilidadUnitaria.Name = "textUtilidadUnitaria";
            textUtilidadUnitaria.ReadOnly = true;
            textUtilidadUnitaria.Size = new Size(91, 27);
            textUtilidadUnitaria.TabIndex = 0;
            textUtilidadUnitaria.TabStop = false;
            // 
            // btnGuardarEdicion
            // 
            btnGuardarEdicion.BackColor = Color.FromArgb(0, 64, 0);
            btnGuardarEdicion.ForeColor = Color.White;
            btnGuardarEdicion.Location = new Point(14, 108);
            btnGuardarEdicion.Margin = new Padding(3, 4, 3, 4);
            btnGuardarEdicion.Name = "btnGuardarEdicion";
            btnGuardarEdicion.Size = new Size(94, 39);
            btnGuardarEdicion.TabIndex = 11;
            btnGuardarEdicion.Text = "Guardar";
            btnGuardarEdicion.UseVisualStyleBackColor = false;
            btnGuardarEdicion.Visible = false;
            btnGuardarEdicion.Click += btnGuardarEdicion_Click;
            // 
            // btnCancelarEdicion
            // 
            btnCancelarEdicion.Location = new Point(114, 108);
            btnCancelarEdicion.Margin = new Padding(3, 4, 3, 4);
            btnCancelarEdicion.Name = "btnCancelarEdicion";
            btnCancelarEdicion.Size = new Size(94, 39);
            btnCancelarEdicion.TabIndex = 12;
            btnCancelarEdicion.Text = "Cancelar";
            btnCancelarEdicion.UseVisualStyleBackColor = true;
            btnCancelarEdicion.Visible = false;
            btnCancelarEdicion.Click += btnCancelarEdicion_Click;
            // 
            // textBuscar
            // 
            textBuscar.Location = new Point(1119, 153);
            textBuscar.Margin = new Padding(3, 4, 3, 4);
            textBuscar.Name = "textBuscar";
            textBuscar.Size = new Size(343, 27);
            textBuscar.TabIndex = 9;
            textBuscar.TextChanged += textBuscar_TextChanged;
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Location = new Point(889, 156);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(224, 20);
            labelBuscar.TabIndex = 0;
            labelBuscar.Text = "Buscar (Nombre/Código Barras):";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1573, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // buttonLimpiarBuscar
            // 
            buttonLimpiarBuscar.Location = new Point(1470, 149);
            buttonLimpiarBuscar.Margin = new Padding(3, 4, 3, 4);
            buttonLimpiarBuscar.Name = "buttonLimpiarBuscar";
            buttonLimpiarBuscar.Size = new Size(64, 35);
            buttonLimpiarBuscar.TabIndex = 10;
            buttonLimpiarBuscar.Text = "Borrar";
            buttonLimpiarBuscar.UseVisualStyleBackColor = true;
            buttonLimpiarBuscar.Click += buttonLimpiarBuscar_Click;
            // 
            // labelPrecioVentaMsyoreo
            // 
            labelPrecioVentaMsyoreo.AutoSize = true;
            labelPrecioVentaMsyoreo.Location = new Point(894, 13);
            labelPrecioVentaMsyoreo.Name = "labelPrecioVentaMsyoreo";
            labelPrecioVentaMsyoreo.Size = new Size(81, 40);
            labelPrecioVentaMsyoreo.TabIndex = 24;
            labelPrecioVentaMsyoreo.Text = "Precio\r\nVenta May:";
            labelPrecioVentaMsyoreo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPrecioVentaMayoreo
            // 
            textPrecioVentaMayoreo.Location = new Point(894, 58);
            textPrecioVentaMayoreo.Margin = new Padding(3, 4, 3, 4);
            textPrecioVentaMayoreo.Name = "textPrecioVentaMayoreo";
            textPrecioVentaMayoreo.Size = new Size(85, 27);
            textPrecioVentaMayoreo.TabIndex = 4;
            textPrecioVentaMayoreo.TextChanged += textPrecioVentaMayoreo_TextChanged;
            // 
            // labelUtilidadMayoreo
            // 
            labelUtilidadMayoreo.AutoSize = true;
            labelUtilidadMayoreo.Location = new Point(985, 34);
            labelUtilidadMayoreo.Name = "labelUtilidadMayoreo";
            labelUtilidadMayoreo.Size = new Size(97, 20);
            labelUtilidadMayoreo.TabIndex = 26;
            labelUtilidadMayoreo.Text = "Utilidad May:";
            // 
            // textUtilidadMayoreo
            // 
            textUtilidadMayoreo.Location = new Point(985, 58);
            textUtilidadMayoreo.Margin = new Padding(3, 4, 3, 4);
            textUtilidadMayoreo.Name = "textUtilidadMayoreo";
            textUtilidadMayoreo.ReadOnly = true;
            textUtilidadMayoreo.Size = new Size(97, 27);
            textUtilidadMayoreo.TabIndex = 0;
            textUtilidadMayoreo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1088, 13);
            label1.Name = "label1";
            label1.Size = new Size(100, 40);
            label1.TabIndex = 28;
            label1.Text = "Cant. \r\nMin Mayoreo:";
            // 
            // textCantMinMayoreo
            // 
            textCantMinMayoreo.Location = new Point(1088, 58);
            textCantMinMayoreo.Margin = new Padding(3, 4, 3, 4);
            textCantMinMayoreo.Name = "textCantMinMayoreo";
            textCantMinMayoreo.Size = new Size(114, 27);
            textCantMinMayoreo.TabIndex = 5;
            // 
            // InventarioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1573, 600);
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
            Margin = new Padding(3, 4, 3, 4);
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
    }
}
