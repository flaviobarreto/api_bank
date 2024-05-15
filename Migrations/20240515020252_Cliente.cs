using Microsoft.EntityFrameworkCore.Migrations;

namespace api_bank.Migrations
{
    public partial class Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AtivoName",
                table: "Ativos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "AtivoCliente",
                columns: table => new
                {
                    AtivosAtivoId = table.Column<int>(type: "INTEGER", nullable: false),
                    clientesClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivoCliente", x => new { x.AtivosAtivoId, x.clientesClienteId });
                    table.ForeignKey(
                        name: "FK_AtivoCliente_Ativos_AtivosAtivoId",
                        column: x => x.AtivosAtivoId,
                        principalTable: "Ativos",
                        principalColumn: "AtivoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtivoCliente_Clientes_clientesClienteId",
                        column: x => x.clientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteAtivos",
                columns: table => new
                {
                    ClienteAtivoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    AtivoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteAtivos", x => x.ClienteAtivoId);
                    table.ForeignKey(
                        name: "FK_ClienteAtivos_Ativos_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativos",
                        principalColumn: "AtivoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteAtivos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtivoCliente_clientesClienteId",
                table: "AtivoCliente",
                column: "clientesClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteAtivos_AtivoId",
                table: "ClienteAtivos",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteAtivos_ClienteId",
                table: "ClienteAtivos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtivoCliente");

            migrationBuilder.DropTable(
                name: "ClienteAtivos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "AtivoName",
                table: "Ativos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
