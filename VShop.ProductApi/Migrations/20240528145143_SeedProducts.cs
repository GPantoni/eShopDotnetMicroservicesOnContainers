using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) " + "VALUES ('Caderno', 7.55, 'Caderno Espiral 100 folhas', 100, 'caderno.jpg', 1)");
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) " + "VALUES ('Caneta', 1.55, 'Caneta Azul', 1000, 'caneta.jpg', 1)");
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) " + "VALUES ('Clips', 0.55, 'Clips de metal', 1000, 'clips.jpg', 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products WHERE Name IN ('Caderno', 'Caneta', 'Clips')");
        }
    }
}
