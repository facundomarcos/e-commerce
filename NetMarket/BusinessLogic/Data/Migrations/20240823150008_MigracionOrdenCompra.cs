using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionOrdenCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipoEnvios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoEnvios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompradorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdenCompraFecha = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DireccionEnvio_Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionEnvio_Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionEnvio_CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionEnvio_Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEnvioId = table.Column<int>(type: "int", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagoIntentoId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenCompras_tipoEnvios_TipoEnvioId",
                        column: x => x.TipoEnvioId,
                        principalTable: "tipoEnvios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrdenItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemOrdenado_ProductoItemId = table.Column<int>(type: "int", nullable: true),
                    ItemOrdenado_ProductoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemOrdenado_ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    OrdenComprasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenItems_OrdenCompras_OrdenComprasId",
                        column: x => x.OrdenComprasId,
                        principalTable: "OrdenCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompras_TipoEnvioId",
                table: "OrdenCompras",
                column: "TipoEnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItems_OrdenComprasId",
                table: "OrdenItems",
                column: "OrdenComprasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenItems");

            migrationBuilder.DropTable(
                name: "OrdenCompras");

            migrationBuilder.DropTable(
                name: "tipoEnvios");
        }
    }
}
