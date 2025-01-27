using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Solteq_server.Migrations
{
    /// <inheritdoc />
    public partial class database_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    CustomText = table.Column<string>(type: "text", nullable: false),
                    ProductWeight = table.Column<string>(type: "text", nullable: false),
                    ProductWarning = table.Column<string>(type: "text", nullable: false),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    ProductContains = table.Column<string>(type: "text", nullable: false),
                    ProductDoesNotContain = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Calories = table.Column<string>(type: "text", nullable: false),
                    Fat = table.Column<string>(type: "text", nullable: false),
                    SaturatedFat = table.Column<string>(type: "text", nullable: false),
                    Carbohydrates = table.Column<string>(type: "text", nullable: false),
                    Sugars = table.Column<string>(type: "text", nullable: false),
                    Polyols = table.Column<string>(type: "text", nullable: false),
                    Protein = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionalDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalDetails_ProductId",
                table: "NutritionalDetails",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutritionalDetails");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
