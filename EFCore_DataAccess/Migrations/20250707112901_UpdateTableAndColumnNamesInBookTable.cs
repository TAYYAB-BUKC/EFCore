using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableAndColumnNamesInBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "TBL_Books");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "TBL_Books",
                newName: "Book_ISBN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBL_Books",
                table: "TBL_Books",
                column: "IDBook");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TBL_Books",
                table: "TBL_Books");

            migrationBuilder.RenameTable(
                name: "TBL_Books",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "Book_ISBN",
                table: "Books",
                newName: "ISBN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "IDBook");
        }
    }
}
