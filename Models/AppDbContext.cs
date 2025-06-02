using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuntoVenta.Models;

namespace PuntoVenta.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<TipoPago> TiposPago { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=punto_venta.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Claves primarias automáticas
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioId);
            modelBuilder.Entity<Venta>().HasKey(v => v.VentaId);
            modelBuilder.Entity<DetalleVenta>().HasKey(d => d.DetalleVentaId);
            modelBuilder.Entity<TipoPago>().HasKey(d => d.TipoPagoId);

            // Relaciones
            modelBuilder.Entity<Venta>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(v => v.UsuarioId);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne<Venta>()
                .WithMany()
                .HasForeignKey(d => d.VentaId);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne<Producto>()
                .WithMany()
                .HasForeignKey(d => d.ProductoId);

        }
    }

}
