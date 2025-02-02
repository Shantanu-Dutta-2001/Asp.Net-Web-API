using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CollegeAPI_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class addDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EstablishedYear = table.Column<int>(type: "int", nullable: false),
                    TotalFaculty = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalStudents = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "DepartmentName", "Description", "EstablishedYear", "TotalFaculty", "TotalStudents" },
                values: new object[,]
                {
                    { 1, "ECE", "Electronic & Communication", "Deals with electronic devices, circuits, and communication systems", 1995, 25, 450 },
                    { 2, "CSE", "Computer Science & Engineering", "Focuses on computing, programming, and software development", 2000, 30, 600 },
                    { 3, "ME", "Mechanical Engineering", "Covers machine design, manufacturing, and automation", 1985, 20, 400 },
                    { 4, "CE", "Civil Engineering", "Involves construction, design, and infrastructure development", 1980, 22, 350 },
                    { 5, "EE", "Electrical Engineering", "Deals with electrical systems, power generation, and electronics", 1990, 24, 420 }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartmentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Students");
        }
    }
}
