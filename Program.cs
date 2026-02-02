using PuntoVenta.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PuntoVenta
{
    static class Program
    {
        [STAThread]
        static void Main()
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
    }
}
