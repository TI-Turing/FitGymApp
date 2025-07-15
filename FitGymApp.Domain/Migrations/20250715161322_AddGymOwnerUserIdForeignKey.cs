using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddGymOwnerUserIdForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Gym_OwnerUserId",
                table: "Gym",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GymOwnerUser",
                table: "Gym",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymOwnerUser",
                table: "Gym");

            migrationBuilder.DropIndex(
                name: "IX_Gym_OwnerUserId",
                table: "Gym");
        }
    }
}
