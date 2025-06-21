namespace PuntoVenta
{
    partial class FormVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelTicket = new Label();
            textNumTicket = new TextBox();
            textCodigoBarras = new TextBox();
            dataGridVenta = new DataGridView();
            labelFechaHora = new Label();
            labelInfoTotal = new Label();
            labelTotal = new Label();
            labelInfoCantidadProductos = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textSuPago = new TextBox();
            labelPago = new Label();
            labelCambio = new Label();
            labelTipoPago = new Label();
            comboBoxTipoPago = new ComboBox();
            btnFinalizarVenta = new Button();
            labelSuCambio = new Label();
            labelNumProductos = new Label();
            buttonCancelarVenta = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridVenta).BeginInit();
            SuspendLayout();
            // 
            // labelTicket
            // 
            labelTicket.AutoSize = true;
            labelTicket.Font = new Font("Microsoft Sans Serif", 19F);
            labelTicket.Location = new Point(34, 131);
            labelTicket.Margin = new Padding(5, 0, 5, 0);
            labelTicket.Name = "labelTicket";
            labelTicket.Size = new Size(89, 30);
            labelTicket.TabIndex = 0;
            labelTicket.Text = "Ticket:";
            // 
            // textNumTicket
            // 
            textNumTicket.Font = new Font("Microsoft Sans Serif", 16.2F);
            textNumTicket.Location = new Point(34, 174);
            textNumTicket.Margin = new Padding(5, 6, 5, 6);
            textNumTicket.Name = "textNumTicket";
            textNumTicket.ReadOnly = true;
            textNumTicket.Size = new Size(603, 32);
            textNumTicket.TabIndex = 1;
            textNumTicket.TabStop = false;
            textNumTicket.TextChanged += textNumTicket_TextChanged;
            // 
            // textCodigoBarras
            // 
            textCodigoBarras.Font = new Font("Microsoft Sans Serif", 16.2F);
            textCodigoBarras.Location = new Point(34, 224);
            textCodigoBarras.Margin = new Padding(5, 6, 5, 6);
            textCodigoBarras.Name = "textCodigoBarras";
            textCodigoBarras.PlaceholderText = "Codigo de barras";
            textCodigoBarras.Size = new Size(603, 32);
            textCodigoBarras.TabIndex = 0;
            textCodigoBarras.KeyDown += textCodigoBarras_KeyDown;
            // 
            // dataGridVenta
            // 
            dataGridVenta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVenta.Location = new Point(722, 17);
            dataGridVenta.Margin = new Padding(5, 6, 5, 6);
            dataGridVenta.Name = "dataGridVenta";
            dataGridVenta.RowHeadersWidth = 51;
            dataGridVenta.Size = new Size(1152, 980);
            dataGridVenta.TabIndex = 3;
            dataGridVenta.TabStop = false;
            dataGridVenta.CellContentClick += dataGridVenta_CellContentClick;
            // 
            // labelFechaHora
            // 
            labelFechaHora.AutoSize = true;
            labelFechaHora.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            labelFechaHora.ForeColor = Color.FromArgb(128, 128, 255);
            labelFechaHora.Location = new Point(34, 17);
            labelFechaHora.Margin = new Padding(5, 0, 5, 0);
            labelFechaHora.Name = "labelFechaHora";
            labelFechaHora.Size = new Size(224, 54);
            labelFechaHora.TabIndex = 0;
            labelFechaHora.Text = "FechaHora";
            // 
            // labelInfoTotal
            // 
            labelInfoTotal.AutoSize = true;
            labelInfoTotal.Font = new Font("Microsoft Sans Serif", 19F);
            labelInfoTotal.Location = new Point(93, 449);
            labelInfoTotal.Margin = new Padding(5, 0, 5, 0);
            labelInfoTotal.Name = "labelInfoTotal";
            labelInfoTotal.Size = new Size(77, 30);
            labelInfoTotal.TabIndex = 0;
            labelInfoTotal.Text = "Total:";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.BackColor = Color.FromArgb(255, 255, 238);
            labelTotal.Font = new Font("Segoe UI", 85F, FontStyle.Bold);
            labelTotal.ForeColor = Color.Green;
            labelTotal.Location = new Point(176, 416);
            labelTotal.Margin = new Padding(5, 0, 5, 0);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(491, 152);
            labelTotal.TabIndex = 0;
            labelTotal.Text = "0000.00";
            labelTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelInfoCantidadProductos
            // 
            labelInfoCantidadProductos.AutoSize = true;
            labelInfoCantidadProductos.Font = new Font("Microsoft Sans Serif", 19F);
            labelInfoCantidadProductos.Location = new Point(412, 283);
            labelInfoCantidadProductos.Margin = new Padding(5, 0, 5, 0);
            labelInfoCantidadProductos.Name = "labelInfoCantidadProductos";
            labelInfoCantidadProductos.Size = new Size(171, 30);
            labelInfoCantidadProductos.TabIndex = 0;
            labelInfoCantidadProductos.Text = "N° Productos:";
            labelInfoCantidadProductos.Click += labelInfoCantidadProductos_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textSuPago
            // 
            textSuPago.Font = new Font("Microsoft Sans Serif", 16.2F);
            textSuPago.Location = new Point(176, 340);
            textSuPago.Margin = new Padding(5, 6, 5, 6);
            textSuPago.Name = "textSuPago";
            textSuPago.Size = new Size(184, 32);
            textSuPago.TabIndex = 2;
            // 
            // labelPago
            // 
            labelPago.AutoSize = true;
            labelPago.Font = new Font("Microsoft Sans Serif", 19F);
            labelPago.Location = new Point(34, 340);
            labelPago.Margin = new Padding(5, 0, 5, 0);
            labelPago.Name = "labelPago";
            labelPago.Size = new Size(114, 30);
            labelPago.TabIndex = 0;
            labelPago.Text = "Su pago:";
            // 
            // labelCambio
            // 
            labelCambio.AutoSize = true;
            labelCambio.Font = new Font("Microsoft Sans Serif", 19F);
            labelCambio.Location = new Point(29, 594);
            labelCambio.Margin = new Padding(5, 0, 5, 0);
            labelCambio.Name = "labelCambio";
            labelCambio.Size = new Size(141, 30);
            labelCambio.TabIndex = 0;
            labelCambio.Text = "Su cambio:";
            // 
            // labelTipoPago
            // 
            labelTipoPago.AutoSize = true;
            labelTipoPago.Font = new Font("Microsoft Sans Serif", 19F);
            labelTipoPago.Location = new Point(34, 283);
            labelTipoPago.Margin = new Padding(5, 0, 5, 0);
            labelTipoPago.Name = "labelTipoPago";
            labelTipoPago.Size = new Size(136, 30);
            labelTipoPago.TabIndex = 0;
            labelTipoPago.Text = "Tipo Pago:";
            // 
            // comboBoxTipoPago
            // 
            comboBoxTipoPago.Font = new Font("Microsoft Sans Serif", 16.2F);
            comboBoxTipoPago.FormattingEnabled = true;
            comboBoxTipoPago.Location = new Point(176, 284);
            comboBoxTipoPago.Margin = new Padding(5, 6, 5, 6);
            comboBoxTipoPago.Name = "comboBoxTipoPago";
            comboBoxTipoPago.Size = new Size(184, 34);
            comboBoxTipoPago.TabIndex = 1;
            comboBoxTipoPago.SelectedIndexChanged += comboBoxTipoPago_SelectedIndexChanged;
            // 
            // btnFinalizarVenta
            // 
            btnFinalizarVenta.BackColor = Color.FromArgb(0, 64, 64);
            btnFinalizarVenta.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFinalizarVenta.ForeColor = Color.White;
            btnFinalizarVenta.Location = new Point(462, 776);
            btnFinalizarVenta.Margin = new Padding(5, 4, 5, 4);
            btnFinalizarVenta.Name = "btnFinalizarVenta";
            btnFinalizarVenta.Size = new Size(175, 70);
            btnFinalizarVenta.TabIndex = 3;
            btnFinalizarVenta.Text = "Finalizar";
            btnFinalizarVenta.UseVisualStyleBackColor = false;
            btnFinalizarVenta.Click += btnFinalizarVenta_Click;
            // 
            // labelSuCambio
            // 
            labelSuCambio.AutoSize = true;
            labelSuCambio.BackColor = Color.FromArgb(255, 255, 238);
            labelSuCambio.Font = new Font("Microsoft Sans Serif", 38F, FontStyle.Bold);
            labelSuCambio.ForeColor = Color.Blue;
            labelSuCambio.Location = new Point(176, 594);
            labelSuCambio.Margin = new Padding(5, 0, 5, 0);
            labelSuCambio.Name = "labelSuCambio";
            labelSuCambio.Size = new Size(214, 59);
            labelSuCambio.TabIndex = 13;
            labelSuCambio.Text = "0000.00";
            labelSuCambio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelNumProductos
            // 
            labelNumProductos.AutoSize = true;
            labelNumProductos.BackColor = SystemColors.ButtonHighlight;
            labelNumProductos.Font = new Font("Microsoft Sans Serif", 17F);
            labelNumProductos.ForeColor = Color.MidnightBlue;
            labelNumProductos.Location = new Point(598, 284);
            labelNumProductos.Margin = new Padding(5, 0, 5, 0);
            labelNumProductos.Name = "labelNumProductos";
            labelNumProductos.Size = new Size(39, 29);
            labelNumProductos.TabIndex = 14;
            labelNumProductos.Text = "00";
            labelNumProductos.Click += labelNumProductos_Click;
            // 
            // buttonCancelarVenta
            // 
            buttonCancelarVenta.BackColor = Color.FromArgb(255, 192, 192);
            buttonCancelarVenta.ForeColor = SystemColors.ActiveCaptionText;
            buttonCancelarVenta.Location = new Point(38, 776);
            buttonCancelarVenta.Margin = new Padding(5, 4, 5, 4);
            buttonCancelarVenta.Name = "buttonCancelarVenta";
            buttonCancelarVenta.Size = new Size(175, 70);
            buttonCancelarVenta.TabIndex = 0;
            buttonCancelarVenta.TabStop = false;
            buttonCancelarVenta.Text = "Cancelar";
            buttonCancelarVenta.UseVisualStyleBackColor = false;
            buttonCancelarVenta.Click += buttonCancelarVenta_Click;
            // 
            // FormVenta
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1017);
            Controls.Add(buttonCancelarVenta);
            Controls.Add(labelNumProductos);
            Controls.Add(labelSuCambio);
            Controls.Add(btnFinalizarVenta);
            Controls.Add(comboBoxTipoPago);
            Controls.Add(labelTipoPago);
            Controls.Add(labelCambio);
            Controls.Add(labelPago);
            Controls.Add(textSuPago);
            Controls.Add(labelInfoCantidadProductos);
            Controls.Add(labelTotal);
            Controls.Add(labelInfoTotal);
            Controls.Add(labelFechaHora);
            Controls.Add(dataGridVenta);
            Controls.Add(textCodigoBarras);
            Controls.Add(textNumTicket);
            Controls.Add(labelTicket);
            Font = new Font("Microsoft Sans Serif", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FormVenta";
            Text = "Venta";
            Load += FormVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTicket;
        private TextBox textNumTicket;
        private TextBox textCodigoBarras;
        private DataGridView dataGridVenta;
        private Label labelFechaHora;
        private Label labelInfoTotal;
        private Label labelTotal;
        private Label labelInfoCantidadProductos;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textSuPago;
        private Label labelPago;
        private Label labelCambio;
        private Label labelTipoPago;
        private ComboBox comboBoxTipoPago;
        private Button btnFinalizarVenta;
        private Label labelSuCambio;
        private Label labelNumProductos;
        private Button buttonCancelarVenta;
    }
}