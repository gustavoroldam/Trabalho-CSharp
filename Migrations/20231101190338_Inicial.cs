using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    unidade = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Qtde_Estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    crm = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    telefone = table.Column<int>(type: "int", nullable: false),
                    especialidade = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.crm);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    cpf = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    telefone = table.Column<int>(type: "int", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.cpf);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    MadicoId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    Qtde_Vacina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consulta_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_MadicoId",
                        column: x => x.MadicoId,
                        principalTable: "Medico",
                        principalColumn: "crm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Paciente",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MadicoId",
                table: "Consulta",
                column: "MadicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicamentoId",
                table: "Consulta",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteID",
                table: "Consulta",
                column: "PacienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
