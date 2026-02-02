using Microsoft.EntityFrameworkCore;
using PuntoVenta.Models;
using System.Text;

namespace PuntoVenta
{
    public class ReportesForm : Form
    {
        private readonly Usuario usuarioActual;
        private DateTimePicker dtpDesde = null!;
        private DateTimePicker dtpHasta = null!;
        private Button btnFiltrar = null!;
        private Button btnRestablecer = null!;
        private Button btnExportarVentas = null!;
        private Button btnExportarDetalle = null!;
        private DataGridView tablaVentas = null!;
        private DataGridView tablaDetalle = null!;
        private SplitContainer splitTablas = null!;

        private sealed class VentaReporteRow
        {
            public int VentaId { get; set; }
            public int Folio { get; set; }
            public DateTime Fecha { get; set; }
            public string Usuario { get; set; } = string.Empty;
            public string TipoPago { get; set; } = string.Empty;
            public int Productos { get; set; }
            public decimal Total { get; set; }
            public decimal Pago { get; set; }
            public decimal Cambio { get; set; }
        }

        private sealed class DetalleReporteRow
        {
            public int DetalleVentaId { get; set; }
            public int VentaId { get; set; }
            public int Folio { get; set; }
            public DateTime Fecha { get; set; }
            public string Producto { get; set; } = string.Empty;
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal { get; set; }
        }

        public ReportesForm(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
            ConfigurarTablas();
            EstablecerRangoInicial();
            CargarVentas();
        }

        private void InitializeComponent()
        {
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnRestablecer = new Button();
            btnExportarVentas = new Button();
            btnExportarDetalle = new Button();
            tablaVentas = new DataGridView();
            tablaDetalle = new DataGridView();
            splitTablas = new SplitContainer();
            var labelDesde = new Label();
            var labelHasta = new Label();
            var labelGeneral = new Label();
            var labelDetalle = new Label();

            SuspendLayout();

            labelDesde.AutoSize = true;
            labelDesde.Location = new Point(16, 18);
            labelDesde.Text = "Desde:";

            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(64, 14);
            dtpDesde.Size = new Size(130, 23);

            labelHasta.AutoSize = true;
            labelHasta.Location = new Point(212, 18);
            labelHasta.Text = "Hasta:";

            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(260, 14);
            dtpHasta.Size = new Size(130, 23);

            btnFiltrar.BackColor = Color.FromArgb(0, 64, 64);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(410, 11);
            btnFiltrar.Size = new Size(88, 29);
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;

            btnRestablecer.Location = new Point(506, 11);
            btnRestablecer.Size = new Size(98, 29);
            btnRestablecer.Text = "Restablecer";
            btnRestablecer.UseVisualStyleBackColor = true;
            btnRestablecer.Click += btnRestablecer_Click;

            btnExportarVentas.Location = new Point(620, 11);
            btnExportarVentas.Size = new Size(148, 29);
            btnExportarVentas.Text = "Exportar General";
            btnExportarVentas.UseVisualStyleBackColor = true;
            btnExportarVentas.Click += btnExportarVentas_Click;

            btnExportarDetalle.Location = new Point(776, 11);
            btnExportarDetalle.Size = new Size(148, 29);
            btnExportarDetalle.Text = "Exportar Detalle";
            btnExportarDetalle.UseVisualStyleBackColor = true;
            btnExportarDetalle.Click += btnExportarDetalle_Click;

            splitTablas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitTablas.Location = new Point(16, 52);
            splitTablas.Size = new Size(1248, 610);
            splitTablas.Orientation = Orientation.Horizontal;
            splitTablas.SplitterDistance = 285;

            labelGeneral.AutoSize = true;
            labelGeneral.Location = new Point(8, 8);
            labelGeneral.Text = "Ventas Generales";

            tablaVentas.AllowUserToAddRows = false;
            tablaVentas.AllowUserToDeleteRows = false;
            tablaVentas.ReadOnly = true;
            tablaVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaVentas.MultiSelect = false;
            tablaVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tablaVentas.Location = new Point(8, 28);
            tablaVentas.Size = new Size(1232, 248);
            tablaVentas.SelectionChanged += tablaVentas_SelectionChanged;

            labelDetalle.AutoSize = true;
            labelDetalle.Location = new Point(8, 8);
            labelDetalle.Text = "Detalle de la Venta Seleccionada";

            tablaDetalle.AllowUserToAddRows = false;
            tablaDetalle.AllowUserToDeleteRows = false;
            tablaDetalle.ReadOnly = true;
            tablaDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaDetalle.MultiSelect = false;
            tablaDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tablaDetalle.Location = new Point(8, 28);
            tablaDetalle.Size = new Size(1232, 281);

            splitTablas.Panel1.Controls.Add(labelGeneral);
            splitTablas.Panel1.Controls.Add(tablaVentas);
            splitTablas.Panel2.Controls.Add(labelDetalle);
            splitTablas.Panel2.Controls.Add(tablaDetalle);

            ClientSize = new Size(1280, 680);
            Controls.Add(labelDesde);
            Controls.Add(dtpDesde);
            Controls.Add(labelHasta);
            Controls.Add(dtpHasta);
            Controls.Add(btnFiltrar);
            Controls.Add(btnRestablecer);
            Controls.Add(btnExportarVentas);
            Controls.Add(btnExportarDetalle);
            Controls.Add(splitTablas);
            Name = "ReportesForm";
            Text = $"Reportes de Ventas - Usuario: {usuarioActual.NombreUsuario}";

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigurarTablas()
        {
            tablaVentas.AutoGenerateColumns = false;
            tablaVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tablaVentas.Columns.Clear();

            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "VentaId", DataPropertyName = "VentaId", Visible = false });
            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Folio", DataPropertyName = "Folio" });
            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "Fecha", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Usuario", DataPropertyName = "Usuario" });
            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tipo Pago", DataPropertyName = "TipoPago" });
            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Productos", DataPropertyName = "Productos" });
            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", DataPropertyName = "Total", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Pago", DataPropertyName = "Pago", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            tablaVentas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cambio", DataPropertyName = "Cambio", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });

            tablaDetalle.AutoGenerateColumns = false;
            tablaDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tablaDetalle.Columns.Clear();

            tablaDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "DetalleVentaId", DataPropertyName = "DetalleVentaId", Visible = false });
            tablaDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "VentaId", DataPropertyName = "VentaId", Visible = false });
            tablaDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Folio", DataPropertyName = "Folio" });
            tablaDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "Fecha", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            tablaDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Producto", DataPropertyName = "Producto" });
            tablaDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "Cantidad" });
            tablaDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio Unit.", DataPropertyName = "PrecioUnitario", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            tablaDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Subtotal", DataPropertyName = "Subtotal", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
        }

        private void EstablecerRangoInicial()
        {
            using var db = new AppDbContext();
            var primeraVenta = db.Ventas.AsNoTracking().OrderBy(v => v.Fecha).Select(v => (DateTime?)v.Fecha).FirstOrDefault();
            var ultimaVenta = db.Ventas.AsNoTracking().OrderByDescending(v => v.Fecha).Select(v => (DateTime?)v.Fecha).FirstOrDefault();

            if (primeraVenta.HasValue && ultimaVenta.HasValue)
            {
                dtpDesde.Value = primeraVenta.Value.Date;
                dtpHasta.Value = ultimaVenta.Value.Date;
            }
            else
            {
                dtpDesde.Value = DateTime.Today;
                dtpHasta.Value = DateTime.Today;
            }
        }

        private void CargarVentas()
        {
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            if (hasta < desde)
            {
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicial.", "Filtro invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();

            var reporte = db.Ventas
                .AsNoTracking()
                .Include(v => v.Usuario)
                .Include(v => v.TipoPago)
                .Where(v => v.Fecha >= desde && v.Fecha <= hasta)
                .OrderByDescending(v => v.Fecha)
                .Select(v => new VentaReporteRow
                {
                    VentaId = v.VentaId,
                    Folio = v.Folio,
                    Fecha = v.Fecha,
                    Usuario = v.Usuario.NombreUsuario,
                    TipoPago = v.TipoPago.Tipo,
                    Productos = v.NumeroProductos,
                    Total = v.TotalVenta,
                    Pago = v.Pago,
                    Cambio = v.Cambio
                })
                .ToList();

            tablaVentas.DataSource = reporte;

            if (reporte.Count > 0)
            {
                tablaVentas.ClearSelection();
                tablaVentas.Rows[0].Selected = true;
                CargarDetalleVenta(reporte[0].VentaId);
            }
            else
            {
                tablaDetalle.DataSource = new List<DetalleReporteRow>();
            }
        }

        private void CargarDetalleVenta(int ventaId)
        {
            using var db = new AppDbContext();

            var detalle = db.DetallesVenta
                .AsNoTracking()
                .Where(d => d.VentaId == ventaId)
                .Join(db.Ventas.AsNoTracking(),
                    d => d.VentaId,
                    v => v.VentaId,
                    (d, v) => new { d, v })
                .Join(db.Productos.AsNoTracking(),
                    dv => dv.d.ProductoId,
                    p => p.ProductoId,
                    (dv, p) => new DetalleReporteRow
                    {
                        DetalleVentaId = dv.d.DetalleVentaId,
                        VentaId = dv.v.VentaId,
                        Folio = dv.v.Folio,
                        Fecha = dv.v.Fecha,
                        Producto = p.Nombre,
                        Cantidad = dv.d.Cantidad,
                        PrecioUnitario = dv.d.PrecioUnitario,
                        Subtotal = dv.d.Subtotal
                    })
                .OrderBy(d => d.DetalleVentaId)
                .ToList();

            tablaDetalle.DataSource = detalle;
        }

        private void btnFiltrar_Click(object? sender, EventArgs e)
        {
            CargarVentas();
        }

        private void btnRestablecer_Click(object? sender, EventArgs e)
        {
            EstablecerRangoInicial();
            CargarVentas();
        }

        private void tablaVentas_SelectionChanged(object? sender, EventArgs e)
        {
            if (tablaVentas.CurrentRow?.DataBoundItem is VentaReporteRow venta)
            {
                CargarDetalleVenta(venta.VentaId);
            }
        }

        private void btnExportarVentas_Click(object? sender, EventArgs e)
        {
            ExportarDataGridACsv(tablaVentas, "reporte_ventas_general");
        }

        private void btnExportarDetalle_Click(object? sender, EventArgs e)
        {
            ExportarDataGridACsv(tablaDetalle, "reporte_ventas_detalle");
        }

        private static void ExportarDataGridACsv(DataGridView grid, string nombreBase)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "CSV compatible con Excel (*.csv)|*.csv",
                FileName = $"{nombreBase}_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var columnasVisibles = grid.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                var sb = new StringBuilder();
                sb.AppendLine(string.Join(",", columnasVisibles.Select(c => EscaparCsv(c.HeaderText))));

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    var valores = columnasVisibles.Select(col =>
                    {
                        var valor = row.Cells[col.Index].Value?.ToString() ?? string.Empty;
                        return EscaparCsv(valor);
                    });

                    sb.AppendLine(string.Join(",", valores));
                }

                File.WriteAllText(dialog.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Archivo exportado correctamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo exportar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscaparCsv(string valor)
        {
            var limpio = valor.Replace("\"", "\"\"");
            return $"\"{limpio}\"";
        }
    }
}
