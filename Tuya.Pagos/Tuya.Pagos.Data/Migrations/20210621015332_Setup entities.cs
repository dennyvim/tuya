using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuya.Pagos.Data.Migrations
{
    public partial class Setupentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Transacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Transacciones_Tbl_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Tbl_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEvento = table.Column<int>(type: "int", nullable: false),
                    UltimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransaccionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Eventos_Tbl_Transacciones_TransaccionId",
                        column: x => x.TransaccionId,
                        principalTable: "Tbl_Transacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_TxDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    TransaccionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TxDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_TxDetalles_Tbl_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Tbl_Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_TxDetalles_Tbl_Transacciones_TransaccionId",
                        column: x => x.TransaccionId,
                        principalTable: "Tbl_Transacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Eventos_TransaccionId",
                table: "Tbl_Eventos",
                column: "TransaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Transacciones_UsuarioId",
                table: "Tbl_Transacciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TxDetalles_ProductoId",
                table: "Tbl_TxDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TxDetalles_TransaccionId",
                table: "Tbl_TxDetalles",
                column: "TransaccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
