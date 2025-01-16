using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CollegeAPI_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class addDataForStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Gujarat,India", new DateTime(2001, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aarav@gmail.in", "Aarav" },
                    { 2, "Melbourne,Australia", new DateTime(2002, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bishops@gmail.com", "Bishops" },
                    { 3, "Maharashtra,India", new DateTime(2001, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chirag@gmail.in", "Chirag" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
