﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AntonyWippich.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTabelaClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true),
                    mes = table.Column<int>(type: "INTEGER", nullable: false),
                    ano = table.Column<int>(type: "INTEGER", nullable: false),
                    m3Consumidos = table.Column<double>(type: "REAL", nullable: false),
                    bandeira = table.Column<string>(type: "TEXT", nullable: true),
                    possuiEsgoto = table.Column<bool>(type: "INTEGER", nullable: false),
                    consumoFaturado = table.Column<double>(type: "REAL", nullable: false),
                    tarifa = table.Column<double>(type: "REAL", nullable: false),
                    valorAgua = table.Column<double>(type: "REAL", nullable: false),
                    adicionalBandeira = table.Column<double>(type: "REAL", nullable: false),
                    taxaEsgoto = table.Column<double>(type: "REAL", nullable: false),
                    total = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
