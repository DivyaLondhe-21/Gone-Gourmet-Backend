using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoneGourmetProject.Migrations
{
    /// <inheritdoc />
    public partial class migrationfirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnavailableItems_Locations_LocationId",
                table: "UnavailableItems");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RestaurantBrands");

            migrationBuilder.DropIndex(
                name: "IX_UnavailableItems_LocationId",
                table: "UnavailableItems");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "UnavailableItems");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "UnavailableItems",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UnavailableItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantBrand",
                table: "UnavailableItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "UnavailableItems");

            migrationBuilder.DropColumn(
                name: "RestaurantBrand",
                table: "UnavailableItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UnavailableItems",
                newName: "ItemId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "UnavailableItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RestaurantBrands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantBrands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_RestaurantBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "RestaurantBrands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnavailableItems_LocationId",
                table: "UnavailableItems",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BrandId",
                table: "Locations",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnavailableItems_Locations_LocationId",
                table: "UnavailableItems",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
