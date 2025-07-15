using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGymApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddGymExtraFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingEmail",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandColor",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Gym",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LegalRepresentative",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxBranchesAllowed",
                table: "Gym",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerUserId",
                table: "Gym",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaLinks",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionPlanId",
                table: "Gym",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrialEndsAt",
                table: "Gym",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "Gym",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingEmail",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "BrandColor",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "LegalRepresentative",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "MaxBranchesAllowed",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "SocialMediaLinks",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "SubscriptionPlanId",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "TrialEndsAt",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "Gym");
        }
    }
}
