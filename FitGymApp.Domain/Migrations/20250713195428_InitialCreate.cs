using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GymPlanSelectedType_Id",
                table: "GymPlanSelected",
                newName: "GymPlanSelectedTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GymPlanSelectedTypeId",
                table: "GymPlanSelected",
                newName: "GymPlanSelectedType_Id");
        }
    }
}
