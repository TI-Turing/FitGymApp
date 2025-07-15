using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddGymIdToGymPlanSelected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GymId",
                table: "GymPlanSelected",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GymId1",
                table: "GymPlanSelected",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GymPlanSelected_GymId1",
                table: "GymPlanSelected",
                column: "GymId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GymPlanSelected_Gym_GymId1",
                table: "GymPlanSelected",
                column: "GymId1",
                principalTable: "Gym",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymPlanSelected_Gym_GymId1",
                table: "GymPlanSelected");

            migrationBuilder.DropIndex(
                name: "IX_GymPlanSelected_GymId1",
                table: "GymPlanSelected");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "GymPlanSelected");

            migrationBuilder.DropColumn(
                name: "GymId1",
                table: "GymPlanSelected");
        }
    }
}
