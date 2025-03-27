using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T5PR1Hugo2.Migrations
{
    /// <inheritdoc />
    public partial class Consums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consums",
                columns: table => new
                {
                    CodiComarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Any = table.Column<int>(type: "int", nullable: false),
                    Comarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poblacio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomesticXarxa = table.Column<double>(type: "float", nullable: false),
                    ActivitatsEconomiques = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ConsumDomesticPerCapita = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consums", x => x.CodiComarca);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consums");
        }
    }
}
