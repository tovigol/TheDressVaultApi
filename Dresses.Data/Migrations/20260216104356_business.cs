using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dresses.Data.Migrations
{
    /// <inheritdoc />
    public partial class business : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "business_id",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "business_id",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "businessId",
                table: "Dresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    business_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameBusiness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.business_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_business_id",
                table: "Users",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_business_id",
                table: "Rentals",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_Dresses_businessId",
                table: "Dresses",
                column: "businessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dresses_Business_businessId",
                table: "Dresses",
                column: "businessId",
                principalTable: "Business",
                principalColumn: "business_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Business_business_id",
                table: "Rentals",
                column: "business_id",
                principalTable: "Business",
                principalColumn: "business_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Business_business_id",
                table: "Users",
                column: "business_id",
                principalTable: "Business",
                principalColumn: "business_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dresses_Business_businessId",
                table: "Dresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Business_business_id",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Business_business_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropIndex(
                name: "IX_Users_business_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_business_id",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Dresses_businessId",
                table: "Dresses");

            migrationBuilder.DropColumn(
                name: "business_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "business_id",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "businessId",
                table: "Dresses");
        }
    }
}
