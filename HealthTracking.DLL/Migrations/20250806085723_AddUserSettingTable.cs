using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTracking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSettingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserSettingId",
                table: "FoodCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SettingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterAmount = table.Column<double>(type: "float", nullable: false),
                    ExerciseDuration = table.Column<double>(type: "float", nullable: false),
                    ExerciseRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_UserSettingId",
                table: "FoodCategories",
                column: "UserSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCategories_UserSettings_UserSettingId",
                table: "FoodCategories",
                column: "UserSettingId",
                principalTable: "UserSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategories_UserSettings_UserSettingId",
                table: "FoodCategories");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_FoodCategories_UserSettingId",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "UserSettingId",
                table: "FoodCategories");
        }
    }
}
