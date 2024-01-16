using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Description", "Email", "IsEnable", "Name", "Password" },
                values: new object[] { 1, "boss", "test@morr.com", true, "Morrison", "$2a$12$/TJ5etIYa9oVJVcEcO0juOYaGQgt1viLJxZlJPoglr6gVWvtHnLt6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
