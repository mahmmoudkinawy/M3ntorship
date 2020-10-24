using Microsoft.EntityFrameworkCore.Migrations;

namespace Laptop.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "laptops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Color = table.Column<string>(maxLength: 40, nullable: false),
                    Generation = table.Column<int>(nullable: false),
                    Model = table.Column<int>(nullable: false),
                    Ram = table.Column<int>(nullable: false),
                    HardDisk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laptops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "laptops");
        }
    }
}
