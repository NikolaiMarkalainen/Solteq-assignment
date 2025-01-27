using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Solteq_server.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(type: "text", nullable: false),
                    custom_text = table.Column<string>(type: "text", nullable: false),
                    weight = table.Column<string>(type: "text", nullable: false),
                    warning = table.Column<string>(type: "text", nullable: false),
                    ingredients = table.Column<string>(type: "text", nullable: false),
                    product_contains = table.Column<string>(type: "text", nullable: false),
                    product_does_not_contain = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nutritional_details",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    calories = table.Column<string>(type: "text", nullable: false),
                    fat = table.Column<string>(type: "text", nullable: false),
                    saturated_fat = table.Column<string>(type: "text", nullable: false),
                    carbohydrates = table.Column<string>(type: "text", nullable: false),
                    sugars = table.Column<string>(type: "text", nullable: false),
                    polyols = table.Column<string>(type: "text", nullable: false),
                    protein = table.Column<string>(type: "text", nullable: false),
                    salt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritional_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_nutritional_details_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nutritional_details_product_id",
                table: "nutritional_details",
                column: "product_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nutritional_details");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
