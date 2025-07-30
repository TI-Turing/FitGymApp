using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymmetry.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PlanUserOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymPlan",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlan",
                table: "User");

            migrationBuilder.RenameIndex(
                name: "IX_FK_GymPlan",
                table: "Plan",
                newName: "IX_Plan_GymId");

            migrationBuilder.AlterColumn<Guid>(
                name: "GymId",
                table: "Plan",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Plan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Plan_UserId",
                table: "Plan",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_UserId1",
                table: "Plan",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Gym_GymId",
                table: "Plan",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_User_UserId",
                table: "Plan",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Gym_GymId",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_User_UserId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Plan_UserId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Plan_UserId1",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plan");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_GymId",
                table: "Plan",
                newName: "IX_FK_GymPlan");

            migrationBuilder.AlterColumn<Guid>(
                name: "GymId",
                table: "Plan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GymPlan",
                table: "Plan",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlan",
                table: "User",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");
        }
    }
}
