using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dresses.Data.Migrations
{
    /// <inheritdoc />
    public partial class id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Users_user_id1",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_user_id1",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "user_id1",
                table: "Rentals");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_user_id",
                table: "Rentals",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Users_user_id",
                table: "Rentals",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Users_user_id",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_user_id",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "user_id1",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_user_id1",
                table: "Rentals",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Users_user_id1",
                table: "Rentals",
                column: "user_id1",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
