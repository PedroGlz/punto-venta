using PuntoVenta.Models;
using System;
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
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated(); // Crea la base si no existe
            }

            FormLogin login = new FormLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                // Si el login fue exitoso, abrimos el formulario principal
                Usuario user = login.UsuarioAutenticado;
                Application.Run(new MDIParent1(user)); // Cambia "Form1" por el nombre de tu formulario principal real
            }
            else
            {
                // Si se cierra el login o falla, terminamos la aplicación
                Application.Exit();
            }
        }
    }
}
