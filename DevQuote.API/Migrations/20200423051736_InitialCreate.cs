using Microsoft.EntityFrameworkCore.Migrations;

namespace DevQuote.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tprofessional",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    monthPay = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tprofessional", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tprojecttype",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tprojecttype", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tuser",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    password = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tuser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tprojecttypemechanism",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    projectTypeId = table.Column<int>(nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    devMonthsQuantity = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tprojecttypemechanism", x => x.id);
                    table.ForeignKey(
                        name: "FK_tprojecttypemechanism_tprojecttype_id",
                        column: x => x.id,
                        principalTable: "tprojecttype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tprojecttypemechanism_tprojecttype_projectTypeId",
                        column: x => x.projectTypeId,
                        principalTable: "tprojecttype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tassignproject",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    professionalId = table.Column<int>(nullable: false),
                    projectTypeMechanismId = table.Column<int>(nullable: false),
                    professionalMonthQuantity = table.Column<int>(nullable: false),
                    addProfessional = table.Column<bool>(nullable: false),
                    addProfessionalReducedMonth = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tassignproject", x => x.id);
                    table.ForeignKey(
                        name: "FK_tassignproject_tprofessional_id",
                        column: x => x.id,
                        principalTable: "tprofessional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tassignproject_tprojecttypemechanism_id",
                        column: x => x.id,
                        principalTable: "tprojecttypemechanism",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tassignproject_tprofessional_professionalId",
                        column: x => x.professionalId,
                        principalTable: "tprofessional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tassignproject_tprojecttypemechanism_projectTypeMechanismId",
                        column: x => x.projectTypeMechanismId,
                        principalTable: "tprojecttypemechanism",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tassignproject_professionalId",
                table: "tassignproject",
                column: "professionalId");

            migrationBuilder.CreateIndex(
                name: "IX_tassignproject_projectTypeMechanismId",
                table: "tassignproject",
                column: "projectTypeMechanismId");

            migrationBuilder.CreateIndex(
                name: "IX_tprojecttypemechanism_projectTypeId",
                table: "tprojecttypemechanism",
                column: "projectTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tassignproject");

            migrationBuilder.DropTable(
                name: "tuser");

            migrationBuilder.DropTable(
                name: "tprofessional");

            migrationBuilder.DropTable(
                name: "tprojecttypemechanism");

            migrationBuilder.DropTable(
                name: "tprojecttype");
        }
    }
}
