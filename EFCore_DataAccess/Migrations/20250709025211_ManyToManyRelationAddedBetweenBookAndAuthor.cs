﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationAddedBetweenBookAndAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false),
                    BooksIDBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthor_Id, x.BooksIDBook });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsAuthor_Id",
                        column: x => x.AuthorsAuthor_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_TBL_Books_BooksIDBook",
                        column: x => x.BooksIDBook,
                        principalTable: "TBL_Books",
                        principalColumn: "IDBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksIDBook",
                table: "AuthorBook",
                column: "BooksIDBook");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");
        }
    }
}
