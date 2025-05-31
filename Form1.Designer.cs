namespace PuntoVenta
{
    partial class Form1
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
            labelPrecioVenta = new Label();
            textPrecioVenta = new TextBox();
            labelGtin = new Label();
            textGtin = new TextBox();
            labelUtilidad = new Label();
            textUtilidad = new TextBox();
            btnGuardarEdicion = new Button();
            btnCancelarEdicion = new Button();
            textBuscar = new TextBox();
            labelBuscar = new Label();
            menuStrip1 = new MenuStrip();
            ((System.ComponentModel.ISupportInitialize)tablaProductos).BeginInit();
            SuspendLayout();
            // 
            // tablaProductos
            // 
            tablaProductos.Anchor = AnchorStyles.None;
            tablaProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaProductos.Location = new Point(12, 126);
            tablaProductos.Name = "tablaProductos";
            tablaProductos.Size = new Size(714, 312);
            tablaProductos.TabIndex = 8;
            tablaProductos.TabStop = false;
            tablaProductos.CellContentClick += tablaProductos_CellContentClick;
            tablaProductos.CellDoubleClick += tablaProductos_CellDoubleClick;
            tablaProductos.CellFormatting += tablaProductos_CellFormatting;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(118, 43);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(160, 23);
            textNombre.TabIndex = 1;
            textNombre.TextChanged += textNombre_TextChanged;
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Location = new Point(284, 43);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(89, 23);
            txtPrecioCompra.TabIndex = 2;
            txtPrecioCompra.TextChanged += txtPrecioCompra_TextChanged;
            txtPrecioCompra.KeyPress += SoloNumerosDecimalesPositivos;
            // 
            // textCantDisponible
            // 
            textCantDisponible.Location = new Point(538, 43);
            textCantDisponible.Name = "textCantDisponible";
            textCantDisponible.Size = new Size(100, 23);
            textCantDisponible.TabIndex = 5;
            textCantDisponible.TextChanged += textBox3_TextChanged;
            textCantDisponible.KeyPress += SoloNumerosDecimalesPositivos;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(644, 81);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(82, 29);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(118, 25);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(54, 15);
            labelNombre.TabIndex = 10;
            labelNombre.Text = "Nombre:";
            labelNombre.Click += label1_Click;
            // 
            // labelPrecioCompra
            // 
            labelPrecioCompra.AutoSize = true;
            labelPrecioCompra.Location = new Point(284, 25);
            labelPrecioCompra.Name = "labelPrecioCompra";
            labelPrecioCompra.Size = new Size(89, 15);
            labelPrecioCompra.TabIndex = 11;
            labelPrecioCompra.Text = "Precio Compra:";
            labelPrecioCompra.Click += label2_Click;
            // 
            // labelCantDisponible
            // 
            labelCantDisponible.AutoSize = true;
            labelCantDisponible.Location = new Point(538, 25);
            labelCantDisponible.Name = "labelCantDisponible";
            labelCantDisponible.Size = new Size(97, 15);
            labelCantDisponible.TabIndex = 14;
            labelCantDisponible.Text = "Cant. Disponible:";
            labelCantDisponible.Click += label3_Click;
            // 
            // labelCantMin
            // 
            labelCantMin.AutoSize = true;
            labelCantMin.Location = new Point(644, 25);
            labelCantMin.Name = "labelCantMin";
            labelCantMin.Size = new Size(82, 15);
            labelCantMin.TabIndex = 15;
            labelCantMin.Text = "Cant. Minima:";
            labelCantMin.Click += label4_Click;
            // 
            // textCantMin
            // 
            textCantMin.Location = new Point(644, 43);
            textCantMin.Name = "textCantMin";
            textCantMin.Size = new Size(82, 23);
            textCantMin.TabIndex = 6;
            textCantMin.KeyPress += SoloNumerosDecimalesPositivos;
            // 
            // labelPrecioVenta
            // 
            labelPrecioVenta.AutoSize = true;
            labelPrecioVenta.Location = new Point(379, 25);
            labelPrecioVenta.Name = "labelPrecioVenta";
            labelPrecioVenta.Size = new Size(75, 15);
            labelPrecioVenta.TabIndex = 12;
            labelPrecioVenta.Text = "Precio Venta:";
            labelPrecioVenta.Click += label5_Click;
            // 
            // textPrecioVenta
            // 
            textPrecioVenta.Location = new Point(379, 43);
            textPrecioVenta.Name = "textPrecioVenta";
            textPrecioVenta.Size = new Size(75, 23);
            textPrecioVenta.TabIndex = 3;
            textPrecioVenta.TextChanged += textPrecioVenta_TextChanged;
            textPrecioVenta.KeyPress += SoloNumerosDecimalesPositivos;
            // 
            // labelGtin
            // 
            labelGtin.AutoSize = true;
            labelGtin.Location = new Point(12, 25);
            labelGtin.Name = "labelGtin";
            labelGtin.Size = new Size(36, 15);
            labelGtin.TabIndex = 9;
            labelGtin.Text = "GTIN:";
            labelGtin.Click += label6_Click;
            // 
            // textGtin
            // 
            textGtin.Location = new Point(12, 43);
            textGtin.Name = "textGtin";
            textGtin.Size = new Size(100, 23);
            textGtin.TabIndex = 0;
            textGtin.KeyDown += textGtin_KeyDown;
            // 
            // labelUtilidad
            // 
            labelUtilidad.AutoSize = true;
            labelUtilidad.Location = new Point(460, 25);
            labelUtilidad.Name = "labelUtilidad";
            labelUtilidad.Size = new Size(51, 15);
            labelUtilidad.TabIndex = 13;
            labelUtilidad.Text = "Utilidad:";
            // 
            // textUtilidad
            // 
            textUtilidad.Location = new Point(460, 43);
            textUtilidad.Name = "textUtilidad";
            textUtilidad.ReadOnly = true;
            textUtilidad.Size = new Size(72, 23);
            textUtilidad.TabIndex = 4;
            textUtilidad.TabStop = false;
            // 
            // btnGuardarEdicion
            // 
            btnGuardarEdicion.Location = new Point(12, 81);
            btnGuardarEdicion.Name = "btnGuardarEdicion";
            btnGuardarEdicion.Size = new Size(82, 29);
            btnGuardarEdicion.TabIndex = 16;
            btnGuardarEdicion.Text = "Guardar";
            btnGuardarEdicion.UseVisualStyleBackColor = true;
            btnGuardarEdicion.Visible = false;
            btnGuardarEdicion.Click += btnGuardarEdicion_Click;
            // 
            // btnCancelarEdicion
            // 
            btnCancelarEdicion.Location = new Point(100, 81);
            btnCancelarEdicion.Name = "btnCancelarEdicion";
            btnCancelarEdicion.Size = new Size(82, 29);
            btnCancelarEdicion.TabIndex = 17;
            btnCancelarEdicion.Text = "Cancelar";
            btnCancelarEdicion.UseVisualStyleBackColor = true;
            btnCancelarEdicion.Visible = false;
            btnCancelarEdicion.Click += btnCancelarEdicion_Click;
            // 
            // textBuscar
            // 
            textBuscar.Location = new Point(395, 85);
            textBuscar.Name = "textBuscar";
            textBuscar.Size = new Size(240, 23);
            textBuscar.TabIndex = 18;
            textBuscar.TextChanged += textBuscar_TextChanged;
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Location = new Point(289, 88);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(100, 15);
            labelBuscar.TabIndex = 20;
            labelBuscar.Text = "Buscar (Nombre):";
            labelBuscar.Click += label2_Click_1;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(743, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 450);
            Controls.Add(labelBuscar);
            Controls.Add(textBuscar);
            Controls.Add(btnCancelarEdicion);
            Controls.Add(btnGuardarEdicion);
            Controls.Add(labelUtilidad);
            Controls.Add(textUtilidad);
            Controls.Add(labelGtin);
            Controls.Add(textGtin);
            Controls.Add(labelPrecioVenta);
            Controls.Add(textPrecioVenta);
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
            Name = "Form1";
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
        private TextBox textPrecioVenta;
        private TextBox textGtin;
        private TextBox textUtilidad;


        private Button btnAgregar;
        private Label labelNombre;
        private Label labelPrecioCompra;
        private Label labelCantDisponible;
        private Label labelCantMin;
        private Label labelPrecioVenta;
        private Label labelGtin;
        private Label labelUtilidad;
        private Button btnGuardarEdicion;
        private Button btnCancelarEdicion;
        private TextBox textBuscar;
        private Label labelBuscar;
        private MenuStrip menuStrip1;
    }
}
