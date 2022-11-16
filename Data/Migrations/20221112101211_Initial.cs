using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagonal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TVs_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "White" },
                    { 2, "Black" },
                    { 3, "Gray" }
                });

            migrationBuilder.InsertData(
                table: "TVs",
                columns: new[] { "Id", "ColorId", "Diagonal", "ImagePath", "Model", "Price", "Resolution", "Year" },
                values: new object[,]
                {
                    { 1, 1, "55″", "https://samsungshop.com.ua/res/cache/images/7d/15/7d153c06cf8aeafa0307b002847130ad/ad6844aa1e4caa49c317ac5114ec9346.jpg", "Samsung QE55QN90BAUXUA Neo", 73999m, "3840x2160 UHD 4K", 2022 },
                    { 2, 1, "65″", "https://samsungshop.com.ua/res/cache/images/1d/90/1d90f289e972b72228c32289202be042/e8d9a3ca400b66bf8c8c692f14da64a2.jpg", "Samsung QE65Q70BAUXUA", 62999m, "3840x2160 UHD 4K", 2022 },
                    { 3, 3, "65″", "https://samsungshop.com.ua/res/cache/images/40/19/401937ab040b932e4f2c1e9337ddd3c0/15a98e0cd6a396d4bca1ca2dc6617e43.jpg", "Samsung QE65Q60BAUXUA", 52199m, "3840x2160 UHD 4K", 2022 },
                    { 4, 2, "55″", "https://samsungshop.com.ua/res/cache/images/1c/4f/1c4f73fd470d63249f4a0763dff03d89/4262c548db10324900e61c6853ce44f8.jpg", "Samsung UE55BU8500UXUA", 28399m, "3840x2160 UHD 4K", 2022 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVs_ColorId",
                table: "TVs",
                column: "ColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVs");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
