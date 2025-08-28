using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticERP.Migrations
{
    /// <inheritdoc />
    public partial class AddNotaFiscal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motoristas_Viagens_ViagemID",
                table: "Motoristas");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Viagens_ViagemID",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_ViagemID",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Motoristas_ViagemID",
                table: "Motoristas");

            migrationBuilder.DropColumn(
                name: "ViagemID",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "ViagemID",
                table: "Motoristas");

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataEmissao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CnpjEmitente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CnpjDestinatario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ViagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Viagens_ViagemId",
                        column: x => x.ViagemId,
                        principalTable: "Viagens",
                        principalColumn: "ViagemID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_MotoristaID",
                table: "Viagens",
                column: "MotoristaID");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_VeiculoID",
                table: "Viagens",
                column: "VeiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_ViagemId",
                table: "NotasFiscais",
                column: "ViagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Motoristas_MotoristaID",
                table: "Viagens",
                column: "MotoristaID",
                principalTable: "Motoristas",
                principalColumn: "MotoristaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Veiculos_VeiculoID",
                table: "Viagens",
                column: "VeiculoID",
                principalTable: "Veiculos",
                principalColumn: "VeiculoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Motoristas_MotoristaID",
                table: "Viagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Veiculos_VeiculoID",
                table: "Viagens");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_MotoristaID",
                table: "Viagens");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_VeiculoID",
                table: "Viagens");

            migrationBuilder.AddColumn<int>(
                name: "ViagemID",
                table: "Veiculos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViagemID",
                table: "Motoristas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ViagemID",
                table: "Veiculos",
                column: "ViagemID");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_ViagemID",
                table: "Motoristas",
                column: "ViagemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Motoristas_Viagens_ViagemID",
                table: "Motoristas",
                column: "ViagemID",
                principalTable: "Viagens",
                principalColumn: "ViagemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Viagens_ViagemID",
                table: "Veiculos",
                column: "ViagemID",
                principalTable: "Viagens",
                principalColumn: "ViagemID");
        }
    }
}
