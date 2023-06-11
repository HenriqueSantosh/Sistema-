using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Sistema.Infra.CrossCutting.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CPF = table.Column<string>(maxLength: 15, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    RG = table.Column<string>(nullable: true),
                    DataExpedicao = table.Column<DateTime>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    OrGaoExpedicao = table.Column<string>(maxLength: 10, nullable: false),
                    UF = table.Column<string>(maxLength: 2, nullable: false),
                    Sexo = table.Column<string>(maxLength: 10, nullable: false),
                    EstadoCivil = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Cep = table.Column<string>(maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 100, nullable: false),
                    Numero = table.Column<string>(maxLength: 6, nullable: false),
                    Complemento = table.Column<string>(maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    UF = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CPF",
                table: "Usuarios",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
