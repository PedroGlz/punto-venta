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
            dataGridView1 = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // 
            // textCodigoBarras
            // 
            textCodigoBarras.Location = new Point(9, 110);
            textCodigoBarras.Name = "textCodigoBarras";
            textCodigoBarras.PlaceholderText = "Codigo de barras";
            textCodigoBarras.Size = new Size(191, 23);
            textCodigoBarras.TabIndex = 2;
            textCodigoBarras.TextChanged += textCodigoBarras_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(209, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(557, 410);
            dataGridView1.TabIndex = 3;
            // 
            // labelFechaHora
            // 
            labelFechaHora.AutoSize = true;
            labelFechaHora.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelFechaHora.Location = new Point(12, 9);
            labelFechaHora.Name = "labelFechaHora";
            labelFechaHora.Size = new Size(112, 28);
            labelFechaHora.TabIndex = 4;
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
            labelInfoTotal.TabIndex = 5;
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
            labelTotal.TabIndex = 6;
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
            labelInfoCantidadProductos.TabIndex = 7;
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
            textNumProductos.TabIndex = 9;
            // 
            // textSuPago
            // 
            textSuPago.Location = new Point(98, 172);
            textSuPago.Name = "textSuPago";
            textSuPago.Size = new Size(102, 23);
            textSuPago.TabIndex = 10;
            // 
            // textSuCambio
            // 
            textSuCambio.Location = new Point(98, 201);
            textSuCambio.Name = "textSuCambio";
            textSuCambio.ReadOnly = true;
            textSuCambio.Size = new Size(102, 23);
            textSuCambio.TabIndex = 11;
            // 
            // labelPago
            // 
            labelPago.AutoSize = true;
            labelPago.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPago.Location = new Point(9, 172);
            labelPago.Name = "labelPago";
            labelPago.Size = new Size(68, 19);
            labelPago.TabIndex = 12;
            labelPago.Text = "Su pago:";
            // 
            // labelCambio
            // 
            labelCambio.AutoSize = true;
            labelCambio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelCambio.Location = new Point(9, 205);
            labelCambio.Name = "labelCambio";
            labelCambio.Size = new Size(83, 19);
            labelCambio.TabIndex = 13;
            labelCambio.Text = "Su cambio:";
            // 
            // FormVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelCambio);
            Controls.Add(labelPago);
            Controls.Add(textSuCambio);
            Controls.Add(textSuPago);
            Controls.Add(textNumProductos);
            Controls.Add(labelInfoCantidadProductos);
            Controls.Add(labelTotal);
            Controls.Add(labelInfoTotal);
            Controls.Add(labelFechaHora);
            Controls.Add(dataGridView1);
            Controls.Add(textCodigoBarras);
            Controls.Add(textNumTicket);
            Controls.Add(labelTicket);
            Name = "FormVenta";
            Text = "Venta";
            Load += FormVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTicket;
        private TextBox textNumTicket;
        private TextBox textCodigoBarras;
        private DataGridView dataGridView1;
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
    }
}