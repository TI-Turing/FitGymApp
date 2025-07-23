using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddVerificationTypeAndUserOTPRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationType",
                table: "UserOTP");

            migrationBuilder.AddColumn<Guid>(
                name: "VerificationTypeId",
                table: "UserOTP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VerificationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOTP_VerificationTypeId",
                table: "UserOTP",
                column: "VerificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOTP_VerificationType",
                table: "UserOTP",
                column: "VerificationTypeId",
                principalTable: "VerificationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOTP_VerificationType",
                table: "UserOTP");

            migrationBuilder.DropTable(
                name: "VerificationType");

            migrationBuilder.DropIndex(
                name: "IX_UserOTP_VerificationTypeId",
                table: "UserOTP");

            migrationBuilder.DropColumn(
                name: "VerificationTypeId",
                table: "UserOTP");

            migrationBuilder.AddColumn<string>(
                name: "VerificationType",
                table: "UserOTP",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
