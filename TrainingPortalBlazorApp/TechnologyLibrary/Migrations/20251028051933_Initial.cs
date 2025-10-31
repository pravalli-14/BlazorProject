using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnologyLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technology",
                columns: table => new
                {
                    TechnologyId = table.Column<string>(type: "char(6)", nullable: false),
                    TechnologyName = table.Column<string>(type: "varchar(20)", nullable: false),
                    Level = table.Column<string>(type: "char(1)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technology", x => x.TechnologyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technology");
        }
    }
}
