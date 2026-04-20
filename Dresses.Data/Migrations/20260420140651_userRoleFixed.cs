using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dresses.Data.Migrations
{
    /// <inheritdoc />
    public partial class userRoleFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Business_business_id",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_business_id",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "business_id",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Rentals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDepositReturned",
                table: "Rentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "businessId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Dresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Dresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cleaningDaysRequired",
                table: "Dresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "depositAmount",
                table: "Dresses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Dresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_businessId",
                table: "Rentals",
                column: "businessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Business_businessId",
                table: "Rentals",
                column: "businessId",
                principalTable: "Business",
                principalColumn: "business_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Business_businessId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_businessId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IsDepositReturned",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "businessId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Dresses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Dresses");

            migrationBuilder.DropColumn(
                name: "cleaningDaysRequired",
                table: "Dresses");

            migrationBuilder.DropColumn(
                name: "depositAmount",
                table: "Dresses");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Dresses");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "business_id",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_business_id",
                table: "Rentals",
                column: "business_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Business_business_id",
                table: "Rentals",
                column: "business_id",
                principalTable: "Business",
                principalColumn: "business_id");
        }
    }
}
