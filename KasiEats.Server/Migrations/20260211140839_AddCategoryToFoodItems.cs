using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KasiEats.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToFoodItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "FoodItems");
        }
    }
}
