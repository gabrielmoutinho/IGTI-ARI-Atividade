using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    UF = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Id_Endereco = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_Id_Endereco",
                        column: x => x.Id_Endereco,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instalacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true),
                    Data_Instalacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Id_Cliente = table.Column<long>(type: "INTEGER", nullable: true),
                    Id_Endereco = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instalacao_Cliente_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instalacao_Endereco_Id_Endereco",
                        column: x => x.Id_Endereco,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true),
                    Data_Leitura = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Data_Vencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Numero_Leitura = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor_Conta = table.Column<float>(type: "REAL", nullable: false),
                    Id_Instalacao = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fatura_Instalacao_Id_Instalacao",
                        column: x => x.Id_Instalacao,
                        principalTable: "Instalacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id_Endereco",
                table: "Cliente",
                column: "Id_Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_Id_Instalacao",
                table: "Fatura",
                column: "Id_Instalacao");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacao_Id_Cliente",
                table: "Instalacao",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacao_Id_Endereco",
                table: "Instalacao",
                column: "Id_Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Instalacao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
