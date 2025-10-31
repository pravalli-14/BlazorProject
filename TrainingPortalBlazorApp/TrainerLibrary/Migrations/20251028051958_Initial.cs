using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    TrainerId = table.Column<string>(type: "char(6)", nullable: false),
                    TrainerName = table.Column<string>(type: "varchar(30)", nullable: false),
                    TrainerType = table.Column<string>(type: "char(1)", nullable: false),
                    TrainerEmail = table.Column<string>(type: "varchar(40)", nullable: false),
                    TrainerPhoneNo = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
