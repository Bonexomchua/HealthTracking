using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTracking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSettingIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentSettingId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentSettingId",
                table: "AspNetUsers");
        }
    }
}
