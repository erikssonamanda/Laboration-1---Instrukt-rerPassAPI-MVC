using Microsoft.EntityFrameworkCore.Migrations;

namespace InstruktorerPassAPI.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruktorer",
                columns: table => new
                {
                    In_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    In_Fornamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_Postnummer = table.Column<int>(type: "int", nullable: false),
                    In_Ort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_Epost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_Mobil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_Personnummer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruktorer", x => x.In_Id);
                });

            migrationBuilder.CreateTable(
                name: "InstruktorerPass",
                columns: table => new
                {
                    IP_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP_InstruktorId = table.Column<int>(type: "int", nullable: false),
                    IP_PassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstruktorerPass", x => x.IP_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pass",
                columns: table => new
                {
                    Pa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pa_Aktivitet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pass", x => x.Pa_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instruktorer");

            migrationBuilder.DropTable(
                name: "InstruktorerPass");

            migrationBuilder.DropTable(
                name: "Pass");
        }
    }
}
