using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVerificationTypeSeedFromModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VerificationType",
                keyColumn: "Id",
                keyValue: new Guid("b1a1e1c1-1111-4e1a-8e1a-111111111111"));

            migrationBuilder.DeleteData(
                table: "VerificationType",
                keyColumn: "Id",
                keyValue: new Guid("b2b2e2c2-2222-4e2a-8e2a-222222222222"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VerificationType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Ip", "IsActive", "Nombre", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b1a1e1c1-1111-4e1a-8e1a-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, true, "Email", null },
                    { new Guid("b2b2e2c2-2222-4e2a-8e2a-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, true, "Phone", null }
                });
        }
    }
}
