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
            labelTicket.Size = new Size(111, 37);
            labelTicket.TabIndex = 0;
            labelTicket.Text = "Ticket:";
            labelTicket.Click += label1_Click;
            // 
            // textNumTicket
            // 
            textNumTicket.Font = new Font("Microsoft Sans Serif", 16.2F);
            textNumTicket.Location = new Point(34, 174);
            textNumTicket.Margin = new Padding(5, 6, 5, 6);
            textNumTicket.Name = "textNumTicket";
            textNumTicket.ReadOnly = true;
            textNumTicket.Size = new Size(603, 38);
            textNumTicket.TabIndex = 1;
            textNumTicket.TabStop = false;
            // 
            // textCodigoBarras
            // 
            textCodigoBarras.Font = new Font("Microsoft Sans Serif", 16.2F);
            textCodigoBarras.Location = new Point(34, 224);
            textCodigoBarras.Margin = new Padding(5, 6, 5, 6);
            textCodigoBarras.Name = "textCodigoBarras";
            textCodigoBarras.PlaceholderText = "Codigo de barras";
            textCodigoBarras.Size = new Size(603, 38);
            textCodigoBarras.TabIndex = 0;
            textCodigoBarras.TextChanged += textCodigoBarras_TextChanged;
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
            // 
            // labelFechaHora
            // 
            labelFechaHora.AutoSize = true;
            labelFechaHora.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            labelFechaHora.ForeColor = Color.FromArgb(128, 128, 255);
            labelFechaHora.Location = new Point(34, 17);
            labelFechaHora.Margin = new Padding(5, 0, 5, 0);
            labelFechaHora.Name = "labelFechaHora";
            labelFechaHora.Size = new Size(279, 67);
            labelFechaHora.TabIndex = 0;
            labelFechaHora.Text = "FechaHora";
            labelFechaHora.Click += label1_Click_1;
            // 
            // labelInfoTotal
            // 
            labelInfoTotal.AutoSize = true;
            labelInfoTotal.Font = new Font("Microsoft Sans Serif", 19F);
            labelInfoTotal.Location = new Point(34, 559);
            labelInfoTotal.Margin = new Padding(5, 0, 5, 0);
            labelInfoTotal.Name = "labelInfoTotal";
            labelInfoTotal.Size = new Size(98, 37);
            labelInfoTotal.TabIndex = 0;
            labelInfoTotal.Text = "Total:";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.BackColor = Color.WhiteSmoke;
            labelTotal.Font = new Font("Segoe UI", 75F, FontStyle.Bold);
            labelTotal.ForeColor = Color.Green;
            labelTotal.Location = new Point(101, 596);
            labelTotal.Margin = new Padding(5, 0, 5, 0);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(536, 166);
            labelTotal.TabIndex = 0;
            labelTotal.Text = "0000.00";
            labelTotal.Click += label2_Click;
            // 
            // labelInfoCantidadProductos
            // 
            labelInfoCantidadProductos.AutoSize = true;
            labelInfoCantidadProductos.Font = new Font("Microsoft Sans Serif", 19F);
            labelInfoCantidadProductos.Location = new Point(383, 400);
            labelInfoCantidadProductos.Margin = new Padding(5, 0, 5, 0);
            labelInfoCantidadProductos.Name = "labelInfoCantidadProductos";
            labelInfoCantidadProductos.Size = new Size(215, 37);
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
            textSuPago.Location = new Point(218, 339);
            textSuPago.Margin = new Padding(5, 6, 5, 6);
            textSuPago.Name = "textSuPago";
            textSuPago.Size = new Size(419, 38);
            textSuPago.TabIndex = 2;
            textSuPago.TextChanged += textSuPago_TextChanged;
            // 
            // labelPago
            // 
            labelPago.AutoSize = true;
            labelPago.Font = new Font("Microsoft Sans Serif", 19F);
            labelPago.Location = new Point(34, 340);
            labelPago.Margin = new Padding(5, 0, 5, 0);
            labelPago.Name = "labelPago";
            labelPago.Size = new Size(146, 37);
            labelPago.TabIndex = 0;
            labelPago.Text = "Su pago:";
            // 
            // labelCambio
            // 
            labelCambio.AutoSize = true;
            labelCambio.Font = new Font("Microsoft Sans Serif", 19F);
            labelCambio.Location = new Point(34, 400);
            labelCambio.Margin = new Padding(5, 0, 5, 0);
            labelCambio.Name = "labelCambio";
            labelCambio.Size = new Size(178, 37);
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
            labelTipoPago.Size = new Size(173, 37);
            labelTipoPago.TabIndex = 0;
            labelTipoPago.Text = "Tipo Pago:";
            // 
            // comboBoxTipoPago
            // 
            comboBoxTipoPago.Font = new Font("Microsoft Sans Serif", 16.2F);
            comboBoxTipoPago.FormattingEnabled = true;
            comboBoxTipoPago.Location = new Point(218, 283);
            comboBoxTipoPago.Margin = new Padding(5, 6, 5, 6);
            comboBoxTipoPago.Name = "comboBoxTipoPago";
            comboBoxTipoPago.Size = new Size(419, 39);
            comboBoxTipoPago.TabIndex = 1;
            // 
            // btnFinalizarVenta
            // 
            btnFinalizarVenta.Location = new Point(375, 797);
            btnFinalizarVenta.Margin = new Padding(5, 4, 5, 4);
            btnFinalizarVenta.Name = "btnFinalizarVenta";
            btnFinalizarVenta.Size = new Size(176, 43);
            btnFinalizarVenta.TabIndex = 12;
            btnFinalizarVenta.Text = "button1";
            btnFinalizarVenta.UseVisualStyleBackColor = true;
            btnFinalizarVenta.Click += btnFinalizarVenta_Click;
            // 
            // labelSuCambio
            // 
            labelSuCambio.AutoSize = true;
            labelSuCambio.BackColor = SystemColors.ButtonHighlight;
            labelSuCambio.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold);
            labelSuCambio.ForeColor = Color.Blue;
            labelSuCambio.Location = new Point(218, 403);
            labelSuCambio.Margin = new Padding(5, 0, 5, 0);
            labelSuCambio.Name = "labelSuCambio";
            labelSuCambio.Size = new Size(126, 33);
            labelSuCambio.TabIndex = 13;
            labelSuCambio.Text = "0000.00";
            // 
            // labelNumProductos
            // 
            labelNumProductos.AutoSize = true;
            labelNumProductos.BackColor = SystemColors.ButtonHighlight;
            labelNumProductos.Font = new Font("Microsoft Sans Serif", 17F);
            labelNumProductos.ForeColor = Color.Blue;
            labelNumProductos.Location = new Point(590, 403);
            labelNumProductos.Margin = new Padding(5, 0, 5, 0);
            labelNumProductos.Name = "labelNumProductos";
            labelNumProductos.Size = new Size(47, 33);
            labelNumProductos.TabIndex = 14;
            labelNumProductos.Text = "00";
            labelNumProductos.Click += labelNumProductos_Click;
            // 
            // FormVenta
            // 
            AutoScaleDimensions = new SizeF(15F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1017);
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
    }
}