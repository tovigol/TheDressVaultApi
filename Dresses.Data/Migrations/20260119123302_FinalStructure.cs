using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dresses.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DressRentals");

            migrationBuilder.DropColumn(
                name: "is_lender",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "dress_id",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_dress_id",
                table: "Rentals",
                column: "dress_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Dresses_dress_id",
                table: "Rentals",
                column: "dress_id",
                principalTable: "Dresses",
                principalColumn: "dress_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Dresses_dress_id",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_dress_id",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "dress_id",
                table: "Rentals");

            migrationBuilder.AddColumn<bool>(
                name: "is_lender",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DressRentals",
                columns: table => new
                {
                    Dressesdress_id = table.Column<int>(type: "int", nullable: false),
                    rentalsrental_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DressRentals", x => new { x.Dressesdress_id, x.rentalsrental_id });
                    table.ForeignKey(
                        name: "FK_DressRentals_Dresses_Dressesdress_id",
                        column: x => x.Dressesdress_id,
                        principalTable: "Dresses",
                        principalColumn: "dress_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DressRentals_Rentals_rentalsrental_id",
                        column: x => x.rentalsrental_id,
                        principalTable: "Rentals",
                        principalColumn: "rental_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DressRentals_rentalsrental_id",
                table: "DressRentals",
                column: "rentalsrental_id");
        }
    }
}
