using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solteq_server.Migrations
{
    /// <inheritdoc />
    public partial class fixschemamismatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionalDetails_Products_ProductId",
                table: "NutritionalDetails");

            migrationBuilder.RenameColumn(
                name: "ProductWeight",
                table: "Products",
                newName: "Weight");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "NutritionalDetails",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_Code",
                table: "Products",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionalDetails_Products_ProductId",
                table: "NutritionalDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionalDetails_Products_ProductId",
                table: "NutritionalDetails");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_Code",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Products",
                newName: "ProductWeight");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "NutritionalDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionalDetails_Products_ProductId",
                table: "NutritionalDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
