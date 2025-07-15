using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGymGymPlanSelectedRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gym_GymPlanSelected_GymPlanSelectedId1",
                table: "Gym");

            migrationBuilder.DropIndex(
                name: "IX_Gym_GymPlanSelectedId1",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "GymPlanSelectedId",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "GymPlanSelectedId1",
                table: "Gym");

            migrationBuilder.CreateIndex(
                name: "IX_GymPlanSelected_GymId",
                table: "GymPlanSelected",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_GymPlanSelected_Gym_GymId",
                table: "GymPlanSelected",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymPlanSelected_Gym_GymId",
                table: "GymPlanSelected");

            migrationBuilder.DropIndex(
                name: "IX_GymPlanSelected_GymId",
                table: "GymPlanSelected");

            migrationBuilder.AddColumn<Guid>(
                name: "GymPlanSelectedId",
                table: "Gym",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GymPlanSelectedId1",
                table: "Gym",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Gym_GymPlanSelectedId1",
                table: "Gym",
                column: "GymPlanSelectedId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Gym_GymPlanSelected_GymPlanSelectedId1",
                table: "Gym",
                column: "GymPlanSelectedId1",
                principalTable: "GymPlanSelected",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
