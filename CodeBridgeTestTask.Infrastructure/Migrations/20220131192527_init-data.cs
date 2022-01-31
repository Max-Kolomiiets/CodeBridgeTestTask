using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeBridgeTestTask.Infrastructure.Migrations
{
    public partial class initdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Color", "Name", "TailLength", "Weight" },
                values: new object[,]
                {
                    { 1, "red & amber", "Neo", 22, 32 },
                    { 2, "black & white", "Jessy", 7, 14 },
                    { 3, "black", "Donie", 20, 17 },
                    { 4, "brown", "Tom", 17, 25 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
