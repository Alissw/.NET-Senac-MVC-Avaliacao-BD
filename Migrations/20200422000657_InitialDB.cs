using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blockbuster.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCliente = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<string>(nullable: false),
                    CpfCliente = table.Column<string>(nullable: false),
                    DiasDevolucao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    IdFilme = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: false),
                    DataLancamento = table.Column<string>(nullable: false),
                    Sinopse = table.Column<string>(nullable: false),
                    ValorLocacaoFilme = table.Column<double>(nullable: false),
                    EstoqueFilme = table.Column<int>(nullable: false),
                    FilmeLocado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.IdFilme);
                });

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    IdLocacao = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteIdCliente = table.Column<int>(nullable: true),
                    IdCliente = table.Column<int>(nullable: false),
                    DataLocacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.IdLocacao);
                    table.ForeignKey(
                        name: "FK_Locacoes_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocacaoFilme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdLocacao = table.Column<int>(nullable: false),
                    LocacaoIdLocacao = table.Column<int>(nullable: true),
                    IdFilme = table.Column<int>(nullable: false),
                    FilmeIdFilme = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoFilme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocacaoFilme_Filmes_FilmeIdFilme",
                        column: x => x.FilmeIdFilme,
                        principalTable: "Filmes",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocacaoFilme_Locacoes_LocacaoIdLocacao",
                        column: x => x.LocacaoIdLocacao,
                        principalTable: "Locacoes",
                        principalColumn: "IdLocacao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoFilme_FilmeIdFilme",
                table: "LocacaoFilme",
                column: "FilmeIdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoFilme_LocacaoIdLocacao",
                table: "LocacaoFilme",
                column: "LocacaoIdLocacao");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_ClienteIdCliente",
                table: "Locacoes",
                column: "ClienteIdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoFilme");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
