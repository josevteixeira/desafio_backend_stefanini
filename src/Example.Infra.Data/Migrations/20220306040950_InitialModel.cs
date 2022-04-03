using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Infra.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.Id);
                    table.ForeignKey("FK_PERSON_CITY", x => x.CityId, principalTable: "City", principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");
        }
    }
}
