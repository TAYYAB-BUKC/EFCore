using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DbSetAddedForBookAuthorMappingAndFluentBookAuthorMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMapping_Authors_Author_Id",
                table: "BookAuthorMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMapping_TBL_Books_Book_Id",
                table: "BookAuthorMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMapping_Fluent_Authors_Author_Id",
                table: "Fluent_BookAuthorMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMapping_TBL_FluentBooks_Book_Id",
                table: "Fluent_BookAuthorMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMapping",
                table: "Fluent_BookAuthorMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMapping",
                table: "BookAuthorMapping");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthorMapping",
                newName: "Fluent_BookAuthorMappings");

            migrationBuilder.RenameTable(
                name: "BookAuthorMapping",
                newName: "BookAuthorMappings");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthorMapping_Book_Id",
                table: "Fluent_BookAuthorMappings",
                newName: "IX_Fluent_BookAuthorMappings_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMapping_Book_Id",
                table: "BookAuthorMappings",
                newName: "IX_BookAuthorMappings_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMappings",
                table: "Fluent_BookAuthorMappings",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMappings",
                table: "BookAuthorMappings",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMappings_Authors_Author_Id",
                table: "BookAuthorMappings",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMappings_TBL_Books_Book_Id",
                table: "BookAuthorMappings",
                column: "Book_Id",
                principalTable: "TBL_Books",
                principalColumn: "IDBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMappings_Fluent_Authors_Author_Id",
                table: "Fluent_BookAuthorMappings",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMappings_TBL_FluentBooks_Book_Id",
                table: "Fluent_BookAuthorMappings",
                column: "Book_Id",
                principalTable: "TBL_FluentBooks",
                principalColumn: "IDBook",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMappings_Authors_Author_Id",
                table: "BookAuthorMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMappings_TBL_Books_Book_Id",
                table: "BookAuthorMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMappings_Fluent_Authors_Author_Id",
                table: "Fluent_BookAuthorMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMappings_TBL_FluentBooks_Book_Id",
                table: "Fluent_BookAuthorMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMappings",
                table: "Fluent_BookAuthorMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMappings",
                table: "BookAuthorMappings");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthorMappings",
                newName: "Fluent_BookAuthorMapping");

            migrationBuilder.RenameTable(
                name: "BookAuthorMappings",
                newName: "BookAuthorMapping");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthorMappings_Book_Id",
                table: "Fluent_BookAuthorMapping",
                newName: "IX_Fluent_BookAuthorMapping_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMappings_Book_Id",
                table: "BookAuthorMapping",
                newName: "IX_BookAuthorMapping_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMapping",
                table: "Fluent_BookAuthorMapping",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMapping",
                table: "BookAuthorMapping",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMapping_Authors_Author_Id",
                table: "BookAuthorMapping",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMapping_TBL_Books_Book_Id",
                table: "BookAuthorMapping",
                column: "Book_Id",
                principalTable: "TBL_Books",
                principalColumn: "IDBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMapping_Fluent_Authors_Author_Id",
                table: "Fluent_BookAuthorMapping",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMapping_TBL_FluentBooks_Book_Id",
                table: "Fluent_BookAuthorMapping",
                column: "Book_Id",
                principalTable: "TBL_FluentBooks",
                principalColumn: "IDBook",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
