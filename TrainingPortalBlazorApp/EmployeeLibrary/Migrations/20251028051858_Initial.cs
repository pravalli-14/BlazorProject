using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpId = table.Column<string>(type: "char(6)", nullable: false),
                    EmpName = table.Column<string>(type: "varchar(30)", nullable: false),
                    Designation = table.Column<string>(type: "varchar(30)", nullable: false),
                    EmpEmail = table.Column<string>(type: "varchar(40)", nullable: false),
                    EmpPhoneNo = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
