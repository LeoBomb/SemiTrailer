using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TenantDb.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContainerNumber = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Chassis = table.Column<int>(type: "integer", nullable: false),
                    IsCollect = table.Column<bool>(type: "boolean", nullable: false, comment: "是否領取"),
                    IsSend = table.Column<bool>(type: "boolean", nullable: false, comment: "是否送達"),
                    IsReceived = table.Column<bool>(type: "boolean", nullable: false, comment: "是否收穫"),
                    IsHandOver = table.Column<bool>(type: "boolean", nullable: false, comment: "是否交櫃"),
                    ShippingPrice = table.Column<decimal>(type: "numeric", nullable: false, comment: "運費"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReport", x => x.Id);
                },
                comment: "日報表");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReport");
        }
    }
}
