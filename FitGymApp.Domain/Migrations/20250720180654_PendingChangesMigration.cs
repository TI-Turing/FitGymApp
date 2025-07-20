using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PendingChangesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandMachine",
                table: "Machine");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineCategoryMachine",
                table: "Machine");

            migrationBuilder.DropTable(
                name: "MachineExercise");

            migrationBuilder.DropIndex(
                name: "IX_FK_MachineCategoryMachine",
                table: "Machine");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MachineCategory");

            migrationBuilder.DropColumn(
                name: "MachineCategory_Id",
                table: "Machine");

            migrationBuilder.RenameColumn(
                name: "Brand_Id",
                table: "Machine",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_FK_BrandMachine",
                table: "Machine",
                newName: "IX_Machine_BrandId");

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "MachineCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MachineCategoryTypeId",
                table: "MachineCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MachineId",
                table: "MachineCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Machine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ExerciseMachine",
                columns: table => new
                {
                    MachineExerciseMachinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMachine", x => new { x.MachineExerciseMachinesId, x.MachinesId });
                    table.ForeignKey(
                        name: "FK_ExerciseMachine_Exercise_MachineExerciseMachinesId",
                        column: x => x.MachineExerciseMachinesId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMachine_Machine_MachinesId",
                        column: x => x.MachinesId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineCategoryType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineCategoryType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineCategory_MachineCategoryTypeId",
                table: "MachineCategory",
                column: "MachineCategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineCategory_MachineId",
                table: "MachineCategory",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMachine_MachinesId",
                table: "ExerciseMachine",
                column: "MachinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Brand_BrandId",
                table: "Machine",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineCategory_MachineCategoryType_MachineCategoryTypeId",
                table: "MachineCategory",
                column: "MachineCategoryTypeId",
                principalTable: "MachineCategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineCategory_Machine_MachineId",
                table: "MachineCategory",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Brand_BrandId",
                table: "Machine");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineCategory_MachineCategoryType_MachineCategoryTypeId",
                table: "MachineCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineCategory_Machine_MachineId",
                table: "MachineCategory");

            migrationBuilder.DropTable(
                name: "ExerciseMachine");

            migrationBuilder.DropTable(
                name: "MachineCategoryType");

            migrationBuilder.DropIndex(
                name: "IX_MachineCategory_MachineCategoryTypeId",
                table: "MachineCategory");

            migrationBuilder.DropIndex(
                name: "IX_MachineCategory_MachineId",
                table: "MachineCategory");

            migrationBuilder.DropColumn(
                name: "MachineCategoryTypeId",
                table: "MachineCategory");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "MachineCategory");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Machine",
                newName: "Brand_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Machine_BrandId",
                table: "Machine",
                newName: "IX_FK_BrandMachine");

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "MachineCategory",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MachineCategory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Machine",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MachineCategory_Id",
                table: "Machine",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MachineExercise",
                columns: table => new
                {
                    Machine_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineExercise_Machine_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineExercise", x => new { x.Machine_Id, x.MachineExercise_Machine_Id });
                    table.ForeignKey(
                        name: "FK_MachineExercise_Exercise",
                        column: x => x.MachineExercise_Machine_Id,
                        principalTable: "Exercise",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MachineExercise_Machine",
                        column: x => x.Machine_Id,
                        principalTable: "Machine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK_MachineCategoryMachine",
                table: "Machine",
                column: "MachineCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FK_MachineExercise_Exercise",
                table: "MachineExercise",
                column: "MachineExercise_Machine_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandMachine",
                table: "Machine",
                column: "Brand_Id",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineCategoryMachine",
                table: "Machine",
                column: "MachineCategory_Id",
                principalTable: "MachineCategory",
                principalColumn: "Id");
        }
    }
}
