using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiELection.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centre",
                columns: table => new
                {
                    NumC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreBureau = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centre", x => x.NumC);
                });

            migrationBuilder.CreateTable(
                name: "Bureau",
                columns: table => new
                {
                    NumB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    CentreNumC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bureau", x => x.NumB);
                    table.ForeignKey(
                        name: "FK_Bureau_Centre_CentreNumC",
                        column: x => x.CentreNumC,
                        principalTable: "Centre",
                        principalColumn: "NumC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Electeur",
                columns: table => new
                {
                    NumE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lieu_residence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BureauNumB = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electeur", x => x.NumE);
                    table.ForeignKey(
                        name: "FK_Electeur_Bureau_BureauNumB",
                        column: x => x.BureauNumB,
                        principalTable: "Bureau",
                        principalColumn: "NumB",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bureau_CentreNumC",
                table: "Bureau",
                column: "CentreNumC");

            migrationBuilder.CreateIndex(
                name: "IX_Electeur_BureauNumB",
                table: "Electeur",
                column: "BureauNumB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Electeur");

            migrationBuilder.DropTable(
                name: "Bureau");

            migrationBuilder.DropTable(
                name: "Centre");
        }
    }
}
