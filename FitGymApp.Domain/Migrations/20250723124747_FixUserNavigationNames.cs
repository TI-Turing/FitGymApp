using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FixUserNavigationNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VerificationType",
                keyColumn: "Id",
                keyValue: new Guid("b1a1e1c1-1111-4e1a-8e1a-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "VerificationType",
                keyColumn: "Id",
                keyValue: new Guid("b2b2e2c2-2222-4e2a-8e2a-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VerificationType",
                keyColumn: "Id",
                keyValue: new Guid("b1a1e1c1-1111-4e1a-8e1a-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 12, 43, 2, 219, DateTimeKind.Utc).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "VerificationType",
                keyColumn: "Id",
                keyValue: new Guid("b2b2e2c2-2222-4e2a-8e2a-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 12, 43, 2, 219, DateTimeKind.Utc).AddTicks(8376));
        }
    }
}
