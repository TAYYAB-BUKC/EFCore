using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedSubCategoryTableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategory_Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cat 1" },
                    { 2, "Cat 2" },
                    { 3, "Cat 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategory_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategory_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategory_Id",
                keyValue: 3);
        }
    }
}
