using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddQrImageUrlToGym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QrImageUrl",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrImageUrl",
                table: "Gym");
        }
    }
}
