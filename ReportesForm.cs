using Microsoft.EntityFrameworkCore;
using PuntoVenta.Models;

namespace PuntoVenta
{
    public class ReportesForm : Form
    {
        private readonly Usuario usuarioActual;
        private DateTimePicker dtpDesde = null!;
        private DateTimePicker dtpHasta = null!;
        private Button btnFiltrar = null!;
        private Button btnRestablecer = null!;
        private DataGridView tablaReportes = null!;

        public ReportesForm(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
            ConfigurarTabla();
            EstablecerRangoInicial();
            CargarVentas();
        }

        private void InitializeComponent()
        {
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnRestablecer = new Button();
            tablaReportes = new DataGridView();
            var labelDesde = new Label();
            var labelHasta = new Label();

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

            tablaReportes.AllowUserToAddRows = false;
            tablaReportes.AllowUserToDeleteRows = false;
            tablaReportes.ReadOnly = true;
            tablaReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaReportes.MultiSelect = false;
            tablaReportes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tablaReportes.Location = new Point(16, 52);
            tablaReportes.Size = new Size(1248, 610);

            ClientSize = new Size(1280, 680);
            Controls.Add(labelDesde);
            Controls.Add(dtpDesde);
            Controls.Add(labelHasta);
            Controls.Add(dtpHasta);
            Controls.Add(btnFiltrar);
            Controls.Add(btnRestablecer);
            Controls.Add(tablaReportes);
            Name = "ReportesForm";
            Text = $"Reportes de Ventas - Usuario: {usuarioActual.NombreUsuario}";

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigurarTabla()
        {
            tablaReportes.AutoGenerateColumns = true;
            tablaReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicial.", "Filtro inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();

            var reporte = db.Ventas
                .AsNoTracking()
                .Include(v => v.Usuario)
                .Include(v => v.TipoPago)
                .Where(v => v.Fecha >= desde && v.Fecha <= hasta)
                .OrderByDescending(v => v.Fecha)
                .Select(v => new
                {
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

            tablaReportes.DataSource = reporte;

            if (tablaReportes.Columns.Contains("Fecha"))
                tablaReportes.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            if (tablaReportes.Columns.Contains("Total"))
                tablaReportes.Columns["Total"].DefaultCellStyle.Format = "C2";

            if (tablaReportes.Columns.Contains("Pago"))
                tablaReportes.Columns["Pago"].DefaultCellStyle.Format = "C2";

            if (tablaReportes.Columns.Contains("Cambio"))
                tablaReportes.Columns["Cambio"].DefaultCellStyle.Format = "C2";
        }

        private void btnFiltrar_Click(object? sender, EventArgs e)
        {
            CargarVentas();
        }

        private void btnRestablecer_Click(object? sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            CargarVentas();
        }
    }
}
