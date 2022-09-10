using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddTechno2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgramingLanguageId" },
                values: new object[] { 1, "Spring", 1 });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgramingLanguageId" },
                values: new object[] { 2, "Jsp", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
