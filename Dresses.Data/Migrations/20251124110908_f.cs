using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dresses.Data.Migrations
{
    /// <inheritdoc />
    public partial class f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dresses",
                columns: table => new
                {
                    dress_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<int>(type: "int", nullable: false),
                    rental_price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dresses", x => x.dress_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_lender = table.Column<bool>(type: "bit", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    rental_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_price = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.rental_id);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_user_id1",
                table: "Rentals",
                column: "user_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DressRentals");

            migrationBuilder.DropTable(
                name: "Dresses");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
