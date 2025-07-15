using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddInvocationIdToLogChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvocationId",
                table: "LogChanges",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvocationId",
                table: "LogChanges");
        }
    }
}
