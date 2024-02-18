using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    public partial class Initb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "Name", "Type" },
                values: new object[] { 1, "Furniture", "Collection" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "Name", "Type" },
                values: new object[] { 2, "Bric n brac", "Collection" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "Name", "Type" },
                values: new object[] { 3, "Clothing", "Delivery" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
