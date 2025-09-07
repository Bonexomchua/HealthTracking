using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTracking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserSettingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategories_UserSettings_UserSettingId",
                table: "FoodCategories");

            migrationBuilder.DropIndex(
                name: "IX_FoodCategories_UserSettingId",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "UserSettingId",
                table: "FoodCategories");

            migrationBuilder.AddColumn<string>(
                name: "Food",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Food",
                table: "UserSettings");

            migrationBuilder.AddColumn<int>(
                name: "UserSettingId",
                table: "FoodCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_UserSettingId",
                table: "FoodCategories",
                column: "UserSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCategories_UserSettings_UserSettingId",
                table: "FoodCategories",
                column: "UserSettingId",
                principalTable: "UserSettings",
                principalColumn: "Id");
        }
    }
}
