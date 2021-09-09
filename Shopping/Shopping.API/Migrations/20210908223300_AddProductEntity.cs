using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.API.Migrations
{
    public partial class AddProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageFile = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFile", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Smart Phone", "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.", "product-1.png", "IPhone X", 950.00m },
                    { 2, "Smart Phone", "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.", "product-2.png", "Samsung 10", 840.00m },
                    { 3, "White Appliances", "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.", "product-3.png", "Huawei Plus", 650.00m },
                    { 4, "White Appliances", "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.", "product-4.png", "Xiaomi Mi 9", 470.00m },
                    { 5, "Smart Phone", "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.", "product-5.png", "HTC U11+ Plus", 380.00m },
                    { 6, "Home Kitchen", "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.", "product-6.png", "LG G7 ThinQ EndofCourse", 240.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
