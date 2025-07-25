using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymmetry.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseToRoutineDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoutineId",
                table: "RoutineDay");

            migrationBuilder.AddColumn<Guid>(
                name: "ExerciseId",
                table: "RoutineDay",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutineDay_ExerciseId",
                table: "RoutineDay",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineDay_Exercise_ExerciseId",
                table: "RoutineDay",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineDay_Exercise_ExerciseId",
                table: "RoutineDay");

            migrationBuilder.DropIndex(
                name: "IX_RoutineDay_ExerciseId",
                table: "RoutineDay");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "RoutineDay");

            migrationBuilder.AddColumn<int>(
                name: "RoutineId",
                table: "RoutineDay",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
