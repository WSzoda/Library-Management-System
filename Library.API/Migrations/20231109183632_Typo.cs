using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class Typo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CusotmerId",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "CusotmerId",
                table: "Rentals",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CusotmerId",
                table: "Rentals",
                newName: "IX_Rentals_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Rentals",
                newName: "CusotmerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                newName: "IX_Rentals_CusotmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CusotmerId",
                table: "Rentals",
                column: "CusotmerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
