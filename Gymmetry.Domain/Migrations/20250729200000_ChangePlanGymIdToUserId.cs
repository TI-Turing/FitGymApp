using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Gymmetry.Domain.Migrations
{
    public partial class ChangePlanGymIdToUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymPlan",
                table: "Plan");
            migrationBuilder.DropIndex(
                name: "IX_FK_GymPlan",
                table: "Plan");
            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Plan");
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Plan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.Empty);
            migrationBuilder.CreateIndex(
                name: "IX_Plan_UserId",
                table: "Plan",
                column: "UserId");
            migrationBuilder.AddForeignKey(
                name: "FK_Plan_User_UserId",
                table: "Plan",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_User_UserId",
                table: "Plan");
            migrationBuilder.DropIndex(
                name: "IX_Plan_UserId",
                table: "Plan");
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plan");
            migrationBuilder.AddColumn<Guid>(
                name: "GymId",
                table: "Plan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.Empty);
            migrationBuilder.CreateIndex(
                name: "IX_FK_GymPlan",
                table: "Plan",
                column: "GymId");
            migrationBuilder.AddForeignKey(
                name: "FK_GymPlan",
                table: "Plan",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");
        }
    }
}
