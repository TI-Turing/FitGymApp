using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymmetry.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessMethodType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessMethodType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryExercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryExercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRegisterDaily",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRegisterDaily", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Goal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExperienceLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GymPlanSelectedType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UsdPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymPlanSelectedType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GymTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymTypes", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "PaymentAttemptStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAttemptStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UsdPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UninstallOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UninstallOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerificationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machine_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PensionFund = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartContract = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndContract = table.Column<DateTime>(type: "datetime", nullable: true),
                    BankId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeType_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTypeEmployeeUser",
                        column: x => x.EmployeeType_Id,
                        principalTable: "EmployeeType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MachineCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineCategoryTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineCategory_MachineCategoryType_MachineCategoryTypeId",
                        column: x => x.MachineCategoryTypeId,
                        principalTable: "MachineCategoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineCategory_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JourneyEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartHour = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EndHour = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeUser_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeUserJourneyEmployee",
                        column: x => x.EmployeeUser_Id,
                        principalTable: "EmployeeUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ammount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillUserType",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchAccessMethod",
                        column: x => x.AccessMethodId,
                        principalTable: "AccessMethodType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchSchedule",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Daily",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutineExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyExercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Set = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Repetitions = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DailyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDailyExercise",
                        column: x => x.DailyId,
                        principalTable: "Daily",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DailyExerciseHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Set = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Repetitions = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DailyHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyExerciseHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsObjectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiresEquipment = table.Column<bool>(type: "bit", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DailyExerciseHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseCategoryExercise",
                        column: x => x.CategoryExerciseId,
                        principalTable: "CategoryExercise",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExerciseMachine",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Exercise_DailyExerciseHistory_DailyExerciseHistoryId",
                        column: x => x.DailyExerciseHistoryId,
                        principalTable: "DailyExerciseHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DailyHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutineExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchDailyHistory",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreakFast = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MidMorning = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Lunch = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MidAfternoon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Night = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MidNight = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gym",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NIT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaLinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalRepresentative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxBranchesAllowed = table.Column<int>(type: "int", nullable: true),
                    QrImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrialEndsAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GymTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gym", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gym_GymTypes_GymTypeId",
                        column: x => x.GymTypeId,
                        principalTable: "GymTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymPlanSelected",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GymPlanSelectedTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymPlanSelected", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymPlanSelectedTypeGymPlanSelected",
                        column: x => x.GymPlanSelectedTypeId,
                        principalTable: "GymPlanSelectedType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GymPlanSelected_Gym_GymId",
                        column: x => x.GymId,
                        principalTable: "Gym",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymPlan",
                        column: x => x.GymId,
                        principalTable: "Gym",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanTypePlan",
                        column: x => x.PlanTypeId,
                        principalTable: "PlanType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GymPlanSelectedModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GymPlanSelectedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymPlanSelectedModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymPlanSelectedGymPlanSelectedModule",
                        column: x => x.GymPlanSelectedId,
                        principalTable: "GymPlanSelected",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdEPS = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdGender = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RH = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    EmergencyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmergencyPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhysicalExceptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserFitUser_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserDiet_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GymUser_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeRegisterDailyUser_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleUser_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserEmployeeUser_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegistrationCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRegisterDailyUser",
                        column: x => x.EmployeeRegisterDailyUser_UserId,
                        principalTable: "EmployeeRegisterDaily",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduleUser",
                        column: x => x.ScheduleUser_UserId,
                        principalTable: "Schedule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDiet",
                        column: x => x.UserDiet_UserId,
                        principalTable: "Diet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEmployeeUser",
                        column: x => x.UserEmployeeUser_UserId,
                        principalTable: "EmployeeUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFitUser",
                        column: x => x.UserFitUser_UserId,
                        principalTable: "FitUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGymUser",
                        column: x => x.GymUser_Id,
                        principalTable: "Gym",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPlan",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserUserType",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Gym_GymId",
                        column: x => x.GymId,
                        principalTable: "Gym",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymPlanSelectedModuleModule_ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymPlanSelectedModuleModule",
                        column: x => x.GymPlanSelectedModuleModule_ModuleId,
                        principalTable: "GymPlanSelectedModule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTypeModule",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Table = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PastObject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvocationId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogChanges",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogLogin",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogUninstall",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnnistallOptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogUninstall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnnistallOptionsLogUnnistall",
                        column: x => x.UnnistallOptionsId,
                        principalTable: "UninstallOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserUnnistallLog",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    URLOption1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    URLOption2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Seen = table.Column<bool>(type: "bit", nullable: false),
                    Opened = table.Column<bool>(type: "bit", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotification",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentAttempt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gateway = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalPaymentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GymPlanSelectedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAttempt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentAttempt_GymPlanSelected_GymPlanSelectedId",
                        column: x => x.GymPlanSelectedId,
                        principalTable: "GymPlanSelected",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentAttempt_Gym_GymId",
                        column: x => x.GymId,
                        principalTable: "Gym",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentAttempt_PaymentAttemptStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PaymentAttemptStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentAttempt_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentAttempt_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    See = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Create = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Read = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Update = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Delete = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissions",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTypePermissions",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhysicalAssessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LeftArm = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RighArm = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LeftForearm = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RightForearm = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LeftThigh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RightThigh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LeftCalf = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RightCalf = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Abdomen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Chest = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpperBack = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LowerBack = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Neck = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Waist = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Hips = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Shoulders = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Wrist = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BodyFatPercentage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MuscleMass = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BMI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhysicalAssessment",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoutineAssigned",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineAssigned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoutineAssigned",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserOTP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    VerificationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOTP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOTP_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOTP_VerificationType",
                        column: x => x.VerificationTypeId,
                        principalTable: "VerificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchSubModule",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModuleSubModule",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Push = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    App = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    WhatsaApp = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SMS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationOptionNotification_NotificationOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationOptionNotification",
                        column: x => x.NotificationOptionNotification_NotificationOptionId,
                        principalTable: "Notification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserNotificationOption",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoutineTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutineUser_RoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutineAssignedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    TagsObjectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagsMachines = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBodyweight = table.Column<bool>(type: "bit", nullable: false),
                    RequiresEquipment = table.Column<bool>(type: "bit", nullable: false),
                    IsCalisthenic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymRoutine",
                        column: x => x.GymId,
                        principalTable: "Gym",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoutineAssignedRoutine",
                        column: x => x.RoutineAssignedId,
                        principalTable: "RoutineAssigned",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoutineUser",
                        column: x => x.RoutineUser_RoutineId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogErrors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Error = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErrors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubModuleLogErrors",
                        column: x => x.SubModuleId,
                        principalTable: "SubModule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLogErrors",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoutineDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutineId = table.Column<int>(type: "int", nullable: false),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Repetitions = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoutineTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineDay_RoutineTemplate_RoutineTemplateId",
                        column: x => x.RoutineTemplateId,
                        principalTable: "RoutineTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutineExercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Sets = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Repetitions = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RoutineTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseRoutineExercise",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoutineRoutineExercise",
                        column: x => x.RoutineTemplateId,
                        principalTable: "RoutineTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BillGym",
                table: "Bill",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BillUser",
                table: "Bill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BillUser1",
                table: "Bill",
                column: "UserSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BillUserType",
                table: "Bill",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_DailyId",
                table: "Branch",
                column: "DailyId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BranchAccessMethod",
                table: "Branch",
                column: "AccessMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_GymBranch",
                table: "Branch",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoutineExerciseDaily",
                table: "Daily",
                column: "RoutineExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserDaily",
                table: "Daily",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DailyDailyExercise",
                table: "DailyExercise",
                column: "DailyId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ExerciseDailyExercise",
                table: "DailyExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DailyHistoryDailyExerciseHistory",
                table: "DailyExerciseHistory",
                column: "DailyHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BranchDailyHistory",
                table: "DailyHistory",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoutineExerciseDailyHistory",
                table: "DailyHistory",
                column: "RoutineExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserDailyHistory",
                table: "DailyHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_DietUser",
                table: "Diet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_EmployeeTypeEmployeeUser",
                table: "EmployeeUser",
                column: "EmployeeType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_DailyExerciseHistoryId",
                table: "Exercise",
                column: "DailyExerciseHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_MachineId",
                table: "Exercise",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ExerciseDailyExerciseHistory",
                table: "Exercise",
                column: "CategoryExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Gym_GymTypeId",
                table: "Gym",
                column: "GymTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Gym_OwnerUserId",
                table: "Gym",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_GymPlanSelectedTypeGymPlanSelected",
                table: "GymPlanSelected",
                column: "GymPlanSelectedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GymPlanSelected_GymId",
                table: "GymPlanSelected",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_GymPlanSelectedGymPlanSelectedModule",
                table: "GymPlanSelectedModule",
                column: "GymPlanSelectedId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_EmployeeUserJourneyEmployee",
                table: "JourneyEmployee",
                column: "EmployeeUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserLogChanges",
                table: "LogChanges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_SubModuleLogErrors",
                table: "LogErrors",
                column: "SubModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserLogErrors",
                table: "LogErrors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserLogLogin",
                table: "LogLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UnnistallOptionsLogUnnistall",
                table: "LogUninstall",
                column: "UnnistallOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserUnnistallLog",
                table: "LogUninstall",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_BrandId",
                table: "Machine",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineCategory_MachineCategoryTypeId",
                table: "MachineCategory",
                column: "MachineCategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineCategory_MachineId",
                table: "MachineCategory",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_GymPlanSelectedModuleModule",
                table: "Module",
                column: "GymPlanSelectedModuleModule_ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserTypeModule",
                table: "Module",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserNotification",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_NotificationOptionNotification",
                table: "NotificationOption",
                column: "NotificationOptionNotification_NotificationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserNotificationOption",
                table: "NotificationOption",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAttempt_GymId",
                table: "PaymentAttempt",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAttempt_GymPlanSelectedId",
                table: "PaymentAttempt",
                column: "GymPlanSelectedId",
                unique: true,
                filter: "[GymPlanSelectedId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAttempt_PlanId",
                table: "PaymentAttempt",
                column: "PlanId",
                unique: true,
                filter: "[PlanId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAttempt_StatusId",
                table: "PaymentAttempt",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAttempt_UserId",
                table: "PaymentAttempt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserPermissions",
                table: "Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserTypePermissions",
                table: "Permissions",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserPhysicalAssessment",
                table: "PhysicalAssessment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_GymPlan",
                table: "Plan",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlanTypePlan",
                table: "Plan",
                column: "PlanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserRoutineAssigned",
                table: "RoutineAssigned",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineDay_RoutineTemplateId",
                table: "RoutineDay",
                column: "RoutineTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ExerciseRoutineExercise",
                table: "RoutineExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoutineRoutineExercise",
                table: "RoutineExercise",
                column: "RoutineTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_GymRoutine",
                table: "RoutineTemplate",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoutineAssignedRoutine",
                table: "RoutineTemplate",
                column: "RoutineAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoutineUser",
                table: "RoutineTemplate",
                column: "RoutineUser_RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BranchSchedule",
                table: "Schedule",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BranchSubModule",
                table: "SubModule",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ModuleSubModule",
                table: "SubModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_EmployeeRegisterDailyUser",
                table: "User",
                column: "EmployeeRegisterDailyUser_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ScheduleUser",
                table: "User",
                column: "ScheduleUser_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserDiet",
                table: "User",
                column: "UserDiet_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserEmployeeUser",
                table: "User",
                column: "UserEmployeeUser_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserFitUser",
                table: "User",
                column: "UserFitUser_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserGymUser",
                table: "User",
                column: "GymUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserPlan",
                table: "User",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserUserType",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GymId",
                table: "User",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOTP_UserId",
                table: "UserOTP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOTP_VerificationTypeId",
                table: "UserOTP",
                column: "VerificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillGym",
                table: "Bill",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillUser",
                table: "Bill",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillUser1",
                table: "Bill",
                column: "UserSellerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Daily_DailyId",
                table: "Branch",
                column: "DailyId",
                principalTable: "Daily",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GymBranch",
                table: "Branch",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExerciseDaily",
                table: "Daily",
                column: "RoutineExerciseId",
                principalTable: "RoutineExercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDaily",
                table: "Daily",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseDailyExercise",
                table: "DailyExercise",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyHistoryDailyExerciseHistory",
                table: "DailyExerciseHistory",
                column: "DailyHistoryId",
                principalTable: "DailyHistory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExerciseDailyHistory",
                table: "DailyHistory",
                column: "RoutineExerciseId",
                principalTable: "RoutineExercise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDailyHistory",
                table: "DailyHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DietUser",
                table: "Diet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GymOwnerUser",
                table: "Gym",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymBranch",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_GymPlan",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_GymRoutine",
                table: "RoutineTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGymUser",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Gym_GymId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDaily",
                table: "Daily");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDailyHistory",
                table: "DailyHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DietUser",
                table: "Diet");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutineAssigned",
                table: "RoutineAssigned");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineUser",
                table: "RoutineTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchAccessMethod",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Daily_DailyId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExerciseDailyHistory",
                table: "DailyHistory");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "DailyExercise");

            migrationBuilder.DropTable(
                name: "JourneyEmployee");

            migrationBuilder.DropTable(
                name: "LogChanges");

            migrationBuilder.DropTable(
                name: "LogErrors");

            migrationBuilder.DropTable(
                name: "LogLogin");

            migrationBuilder.DropTable(
                name: "LogUninstall");

            migrationBuilder.DropTable(
                name: "MachineCategory");

            migrationBuilder.DropTable(
                name: "NotificationOption");

            migrationBuilder.DropTable(
                name: "PaymentAttempt");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PhysicalAssessment");

            migrationBuilder.DropTable(
                name: "RoutineDay");

            migrationBuilder.DropTable(
                name: "UserOTP");

            migrationBuilder.DropTable(
                name: "SubModule");

            migrationBuilder.DropTable(
                name: "UninstallOptions");

            migrationBuilder.DropTable(
                name: "MachineCategoryType");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PaymentAttemptStatus");

            migrationBuilder.DropTable(
                name: "VerificationType");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "GymPlanSelectedModule");

            migrationBuilder.DropTable(
                name: "GymPlanSelected");

            migrationBuilder.DropTable(
                name: "GymPlanSelectedType");

            migrationBuilder.DropTable(
                name: "Gym");

            migrationBuilder.DropTable(
                name: "GymTypes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EmployeeRegisterDaily");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "EmployeeUser");

            migrationBuilder.DropTable(
                name: "FitUser");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "PlanType");

            migrationBuilder.DropTable(
                name: "AccessMethodType");

            migrationBuilder.DropTable(
                name: "Daily");

            migrationBuilder.DropTable(
                name: "RoutineExercise");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "RoutineTemplate");

            migrationBuilder.DropTable(
                name: "CategoryExercise");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "DailyExerciseHistory");

            migrationBuilder.DropTable(
                name: "RoutineAssigned");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "DailyHistory");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
