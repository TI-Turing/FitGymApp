using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymmetry.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGymModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gym_GymTypes_GymTypeId",
                table: "Gym");

            migrationBuilder.AlterColumn<Guid>(
                name: "GymTypeId",
                table: "Gym",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Gym_GymTypes_GymTypeId",
                table: "Gym",
                column: "GymTypeId",
                principalTable: "GymTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gym_GymTypes_GymTypeId",
                table: "Gym");

            migrationBuilder.AlterColumn<Guid>(
                name: "GymTypeId",
                table: "Gym",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gym_GymTypes_GymTypeId",
                table: "Gym",
                column: "GymTypeId",
                principalTable: "GymTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
