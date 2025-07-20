using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBranchDailyBranchIdV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchDaily",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_FK_BranchDaily",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "BranchDaily_BranchId",
                table: "Branch");

            migrationBuilder.AddColumn<Guid>(
                name: "DailyId",
                table: "Branch",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch_DailyId",
                table: "Branch",
                column: "DailyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Daily_DailyId",
                table: "Branch",
                column: "DailyId",
                principalTable: "Daily",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Daily_DailyId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_DailyId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "DailyId",
                table: "Branch");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchDaily_BranchId",
                table: "Branch",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FK_BranchDaily",
                table: "Branch",
                column: "BranchDaily_BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchDaily",
                table: "Branch",
                column: "BranchDaily_BranchId",
                principalTable: "Daily",
                principalColumn: "Id");
        }
    }
}
