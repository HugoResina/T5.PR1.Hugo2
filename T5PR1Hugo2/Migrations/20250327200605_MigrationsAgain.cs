using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T5PR1Hugo2.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsAgain : Migration
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
                    AnyD = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Indicadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnyDt = table.Column<int>(type: "int", nullable: false),
                    ProduccioNeta = table.Column<double>(type: "float", nullable: false),
                    ConsumGasolina = table.Column<double>(type: "float", nullable: false),
                    DemandaElectrica = table.Column<double>(type: "float", nullable: false),
                    ProduccioDisponible = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicadors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoresSol = table.Column<double>(type: "float", nullable: false),
                    VelocitatVent = table.Column<double>(type: "float", nullable: false),
                    CabalAigua = table.Column<double>(type: "float", nullable: false),
                    Rati = table.Column<double>(type: "float", nullable: false),
                    EnergiaGenerada = table.Column<double>(type: "float", nullable: false),
                    CostKWh = table.Column<double>(type: "float", nullable: false),
                    PreuKWh = table.Column<double>(type: "float", nullable: false),
                    DataHora = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consums");

            migrationBuilder.DropTable(
                name: "Indicadors");

            migrationBuilder.DropTable(
                name: "Simulations");
        }
    }
}
