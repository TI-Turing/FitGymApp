using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymmetry.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogLoginForRefreshTokenSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogLogin",
                table: "LogLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogLogin",
                table: "LogLogin");

            migrationBuilder.RenameTable(
                name: "LogLogin",
                newName: "LogLogins");

            migrationBuilder.RenameIndex(
                name: "IX_FK_UserLogLogin",
                table: "LogLogins",
                newName: "IX_LogLogins_UserId");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "LogLogins",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiration",
                table: "LogLogins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogLogins",
                table: "LogLogins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogLogins_User_UserId",
                table: "LogLogins",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogLogins_User_UserId",
                table: "LogLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogLogins",
                table: "LogLogins");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "LogLogins");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiration",
                table: "LogLogins");

            migrationBuilder.RenameTable(
                name: "LogLogins",
                newName: "LogLogin");

            migrationBuilder.RenameIndex(
                name: "IX_LogLogins_UserId",
                table: "LogLogin",
                newName: "IX_FK_UserLogLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogLogin",
                table: "LogLogin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogLogin",
                table: "LogLogin",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
