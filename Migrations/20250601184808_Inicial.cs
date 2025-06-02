using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuntoVenta.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVentas_Productos_ProductoId",
                table: "DetalleVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVentas_Ventas_VentaId",
                table: "DetalleVentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleVentas",
                table: "DetalleVentas");

            migrationBuilder.RenameTable(
                name: "DetalleVentas",
                newName: "DetallesVenta");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleVentas_VentaId",
                table: "DetallesVenta",
                newName: "IX_DetallesVenta_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleVentas_ProductoId",
                table: "DetallesVenta",
                newName: "IX_DetallesVenta_ProductoId");

            migrationBuilder.AddColumn<decimal>(
                name: "TipoPagoId",
                table: "Ventas",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesVenta",
                table: "DetallesVenta",
                column: "DetalleVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesVenta_Productos_ProductoId",
                table: "DetallesVenta",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesVenta_Ventas_VentaId",
                table: "DetallesVenta",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesVenta_Productos_ProductoId",
                table: "DetallesVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesVenta_Ventas_VentaId",
                table: "DetallesVenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesVenta",
                table: "DetallesVenta");

            migrationBuilder.DropColumn(
                name: "TipoPagoId",
                table: "Ventas");

            migrationBuilder.RenameTable(
                name: "DetallesVenta",
                newName: "DetalleVentas");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesVenta_VentaId",
                table: "DetalleVentas",
                newName: "IX_DetalleVentas_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesVenta_ProductoId",
                table: "DetalleVentas",
                newName: "IX_DetalleVentas_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleVentas",
                table: "DetalleVentas",
                column: "DetalleVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVentas_Productos_ProductoId",
                table: "DetalleVentas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVentas_Ventas_VentaId",
                table: "DetalleVentas",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
