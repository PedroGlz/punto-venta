using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PuntoVenta.Models;

namespace PuntoVenta
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ConfigurarManejoGlobalDeErrores();

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ApplicationConfiguration.Initialize();
                InicializarBaseDatos();

                FormLogin login = new FormLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Usuario user = login.UsuarioAutenticado;
                    Application.Run(new MDIParent1(user));
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                EscribirLogFatal("Excepción fatal en Main()", ex);
                MostrarMensajeError(ex);
            }
        }

        private static void ConfigurarManejoGlobalDeErrores()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += (sender, exArgs) =>
            {
                EscribirLogFatal("Excepción no controlada en hilo de UI", exArgs.Exception);
                MostrarMensajeError(exArgs.Exception);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, exArgs) =>
            {
                Exception ex = exArgs.ExceptionObject as Exception
                               ?? new Exception("Se produjo una excepción no controlada no convertible a Exception.");

                EscribirLogFatal("Excepción no controlada de AppDomain", ex);
                MostrarMensajeError(ex);
            };
        }

        private static void InicializarBaseDatos()
        {
            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            GarantizarTipoUsuario(db, 1, "admin");
            GarantizarTipoUsuario(db, 2, "vendedor");

            var usuarioSuper = db.Usuarios.FirstOrDefault(u => u.UsuarioId == 1);
            if (usuarioSuper == null)
            {
                db.Usuarios.Add(new Usuario
                {
                    UsuarioId = 1,
                    NombreUsuario = "super",
                    Password = "123",
                    TipoUsuarioId = 1
                });
            }
            else
            {
                usuarioSuper.NombreUsuario = "super";
                usuarioSuper.Password = "123";
                usuarioSuper.TipoUsuarioId = 1;
            }

            db.SaveChanges();
        }

        private static void GarantizarTipoUsuario(AppDbContext db, int tipoUsuarioId, string tipo)
        {
            var registro = db.TiposUsuario.FirstOrDefault(t => t.TipoUsuarioId == tipoUsuarioId);
            if (registro == null)
            {
                db.TiposUsuario.Add(new TipoUsuario
                {
                    TipoUsuarioId = tipoUsuarioId,
                    Tipo = tipo
                });
                return;
            }

            registro.Tipo = tipo;
        }

        private static void EscribirLogFatal(string titulo, Exception ex)
        {
            try
            {
                string rutaLog = ObtenerRutaLog();
                string separador = new string('=', 100);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(separador);
                sb.AppendLine("PUNTOVENTA - LOG FATAL");
                sb.AppendLine(separador);
                sb.AppendLine($"Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                sb.AppendLine($"Equipo: {Environment.MachineName}");
                sb.AppendLine($"Usuario Windows: {Environment.UserName}");
                sb.AppendLine($"Sistema Operativo: {Environment.OSVersion}");
                sb.AppendLine($"Versión .NET: {Environment.Version}");
                sb.AppendLine($"Directorio actual: {Environment.CurrentDirectory}");
                sb.AppendLine($"BaseDirectory: {AppDomain.CurrentDomain.BaseDirectory}");
                sb.AppendLine($"Título: {titulo}");
                sb.AppendLine();

                if (ex != null)
                {
                    sb.AppendLine("Mensaje:");
                    sb.AppendLine(ex.Message);
                    sb.AppendLine();

                    sb.AppendLine("Tipo de excepción:");
                    sb.AppendLine(ex.GetType().FullName);
                    sb.AppendLine();

                    sb.AppendLine("StackTrace:");
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine();

                    Exception inner = ex.InnerException;
                    int nivel = 1;

                    while (inner != null)
                    {
                        sb.AppendLine($"InnerException Nivel {nivel}:");
                        sb.AppendLine(inner.GetType().FullName);
                        sb.AppendLine(inner.Message);
                        sb.AppendLine(inner.StackTrace);
                        sb.AppendLine();

                        inner = inner.InnerException;
                        nivel++;
                    }
                }
                else
                {
                    sb.AppendLine("No se recibió información de la excepción.");
                }

                sb.AppendLine();

                File.AppendAllText(rutaLog, sb.ToString(), Encoding.UTF8);
            }
            catch
            {
                // Si incluso el log falla, evitamos otro crash aquí.
            }
        }

        private static string ObtenerRutaLog()
        {
            try
            {
                string rutaExe = AppDomain.CurrentDomain.BaseDirectory;
                string rutaLogExe = Path.Combine(rutaExe, "fatal.log");

                using (FileStream fs = new FileStream(rutaLogExe, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    // Solo probamos que se pueda escribir.
                }

                return rutaLogExe;
            }
            catch
            {
                string carpetaLocal = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "PuntoVenta"
                );

                Directory.CreateDirectory(carpetaLocal);
                return Path.Combine(carpetaLocal, "fatal.log");
            }
        }

        private static void MostrarMensajeError(Exception ex)
        {
            try
            {
                string rutaLog = ObtenerRutaLog();

                MessageBox.Show(
                    "La aplicación encontró un error y se cerrará.\n\n" +
                    "Se generó un archivo de diagnóstico en:\n" +
                    rutaLog + "\n\n" +
                    "Detalle:\n" + ex.Message,
                    "Error en PuntoVenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch
            {
                MessageBox.Show(
                    "La aplicación encontró un error y se cerrará.",
                    "Error en PuntoVenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}