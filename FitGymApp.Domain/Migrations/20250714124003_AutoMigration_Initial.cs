using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymGymPlanSelected",
                table: "Gym");

            migrationBuilder.DropForeignKey(
                name: "FK_GymPlanSelected_Gym_GymId1",
                table: "GymPlanSelected");

            migrationBuilder.DropIndex(
                name: "IX_GymPlanSelected_GymId1",
                table: "GymPlanSelected");

            migrationBuilder.DropIndex(
                name: "IX_FK_GymGymPlanSelected",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "GymId1",
                table: "GymPlanSelected");

            migrationBuilder.AlterColumn<Guid>(
                name: "GymId",
                table: "GymPlanSelected",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gym_GymPlanSelected_GymPlanSelectedId1",
                table: "Gym");

            migrationBuilder.DropIndex(
                name: "IX_Gym_GymPlanSelectedId1",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "GymPlanSelectedId1",
                table: "Gym");

            migrationBuilder.AlterColumn<Guid>(
                name: "GymId",
                table: "GymPlanSelected",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_FK_GymGymPlanSelected",
                table: "Gym",
                column: "GymPlanSelectedId");

            migrationBuilder.AddForeignKey(
                name: "FK_GymGymPlanSelected",
                table: "Gym",
                column: "GymPlanSelectedId",
                principalTable: "GymPlanSelected",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GymPlanSelected_Gym_GymId1",
                table: "GymPlanSelected",
                column: "GymId1",
                principalTable: "Gym",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
