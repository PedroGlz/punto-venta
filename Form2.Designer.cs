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
            textNumProductos = new TextBox();
            textSuPago = new TextBox();
            textSuCambio = new TextBox();
            labelPago = new Label();
            labelCambio = new Label();
            labelTipoPago = new Label();
            comboBoxTipoPago = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridVenta).BeginInit();
            SuspendLayout();
            // 
            // labelTicket
            // 
            labelTicket.AutoSize = true;
            labelTicket.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTicket.Location = new Point(9, 63);
            labelTicket.Name = "labelTicket";
            labelTicket.Size = new Size(45, 15);
            labelTicket.TabIndex = 0;
            labelTicket.Text = "Ticket:";
            labelTicket.Click += label1_Click;
            // 
            // textNumTicket
            // 
            textNumTicket.Location = new Point(9, 81);
            textNumTicket.Name = "textNumTicket";
            textNumTicket.ReadOnly = true;
            textNumTicket.Size = new Size(191, 23);
            textNumTicket.TabIndex = 1;
            textNumTicket.TabStop = false;
            // 
            // textCodigoBarras
            // 
            textCodigoBarras.Location = new Point(9, 110);
            textCodigoBarras.Name = "textCodigoBarras";
            textCodigoBarras.PlaceholderText = "Codigo de barras";
            textCodigoBarras.Size = new Size(191, 23);
            textCodigoBarras.TabIndex = 0;
            textCodigoBarras.TextChanged += textCodigoBarras_TextChanged;
            textCodigoBarras.KeyDown += textCodigoBarras_KeyDown;
            // 
            // dataGridVenta
            // 
            dataGridVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVenta.Location = new Point(209, 12);
            dataGridVenta.Name = "dataGridVenta";
            dataGridVenta.Size = new Size(557, 410);
            dataGridVenta.TabIndex = 3;
            // 
            // labelFechaHora
            // 
            labelFechaHora.AutoSize = true;
            labelFechaHora.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelFechaHora.Location = new Point(12, 9);
            labelFechaHora.Name = "labelFechaHora";
            labelFechaHora.Size = new Size(112, 28);
            labelFechaHora.TabIndex = 0;
            labelFechaHora.Text = "FechaHora";
            labelFechaHora.Click += label1_Click_1;
            // 
            // labelInfoTotal
            // 
            labelInfoTotal.AutoSize = true;
            labelInfoTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelInfoTotal.Location = new Point(12, 262);
            labelInfoTotal.Name = "labelInfoTotal";
            labelInfoTotal.Size = new Size(46, 19);
            labelInfoTotal.TabIndex = 0;
            labelInfoTotal.Text = "Total:";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.BackColor = SystemColors.ButtonHighlight;
            labelTotal.Font = new Font("Segoe UI", 38F, FontStyle.Bold);
            labelTotal.ForeColor = Color.Green;
            labelTotal.Location = new Point(12, 281);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(188, 68);
            labelTotal.TabIndex = 0;
            labelTotal.Text = "500.50";
            labelTotal.Click += label2_Click;
            // 
            // labelInfoCantidadProductos
            // 
            labelInfoCantidadProductos.AutoSize = true;
            labelInfoCantidadProductos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelInfoCantidadProductos.Location = new Point(9, 146);
            labelInfoCantidadProductos.Name = "labelInfoCantidadProductos";
            labelInfoCantidadProductos.Size = new Size(117, 19);
            labelInfoCantidadProductos.TabIndex = 0;
            labelInfoCantidadProductos.Text = "Num Productos:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textNumProductos
            // 
            textNumProductos.Location = new Point(132, 143);
            textNumProductos.Name = "textNumProductos";
            textNumProductos.ReadOnly = true;
            textNumProductos.Size = new Size(68, 23);
            textNumProductos.TabIndex = 0;
            textNumProductos.TabStop = false;
            // 
            // textSuPago
            // 
            textSuPago.Location = new Point(98, 201);
            textSuPago.Name = "textSuPago";
            textSuPago.Size = new Size(102, 23);
            textSuPago.TabIndex = 2;
            textSuPago.TextChanged += textSuPago_TextChanged;
            // 
            // textSuCambio
            // 
            textSuCambio.Location = new Point(98, 230);
            textSuCambio.Name = "textSuCambio";
            textSuCambio.ReadOnly = true;
            textSuCambio.Size = new Size(102, 23);
            textSuCambio.TabIndex = 11;
            textSuCambio.TabStop = false;
            // 
            // labelPago
            // 
            labelPago.AutoSize = true;
            labelPago.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPago.Location = new Point(9, 201);
            labelPago.Name = "labelPago";
            labelPago.Size = new Size(68, 19);
            labelPago.TabIndex = 0;
            labelPago.Text = "Su pago:";
            // 
            // labelCambio
            // 
            labelCambio.AutoSize = true;
            labelCambio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelCambio.Location = new Point(9, 234);
            labelCambio.Name = "labelCambio";
            labelCambio.Size = new Size(83, 19);
            labelCambio.TabIndex = 0;
            labelCambio.Text = "Su cambio:";
            // 
            // labelTipoPago
            // 
            labelTipoPago.AutoSize = true;
            labelTipoPago.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTipoPago.Location = new Point(9, 172);
            labelTipoPago.Name = "labelTipoPago";
            labelTipoPago.Size = new Size(82, 19);
            labelTipoPago.TabIndex = 0;
            labelTipoPago.Text = "Tipo Pago:";
            // 
            // comboBoxTipoPago
            // 
            comboBoxTipoPago.FormattingEnabled = true;
            comboBoxTipoPago.Location = new Point(97, 172);
            comboBoxTipoPago.Name = "comboBoxTipoPago";
            comboBoxTipoPago.Size = new Size(103, 23);
            comboBoxTipoPago.TabIndex = 1;
            // 
            // FormVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxTipoPago);
            Controls.Add(labelTipoPago);
            Controls.Add(labelCambio);
            Controls.Add(labelPago);
            Controls.Add(textSuCambio);
            Controls.Add(textSuPago);
            Controls.Add(textNumProductos);
            Controls.Add(labelInfoCantidadProductos);
            Controls.Add(labelTotal);
            Controls.Add(labelInfoTotal);
            Controls.Add(labelFechaHora);
            Controls.Add(dataGridVenta);
            Controls.Add(textCodigoBarras);
            Controls.Add(textNumTicket);
            Controls.Add(labelTicket);
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
        private TextBox textNumProductos;
        private TextBox textSuPago;
        private TextBox textSuCambio;
        private Label labelPago;
        private Label labelCambio;
        private Label labelTipoPago;
        private ComboBox comboBoxTipoPago;
    }
}