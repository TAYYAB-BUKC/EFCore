using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddViewAndStoredProcedureToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW GetBookDetails
                                AS
                                SELECT B.Title, B.Book_ISBN AS ISBN, B.Price FROM TBL_BOOKS B WITH (NOLOCK)");

			migrationBuilder.Sql(@"CREATE OR ALTER VIEW GetAllBooks
                                AS
                                SELECT * FROM TBL_BOOKS B WITH (NOLOCK)");

			migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE GetBookById
                                @BookId INT
                                AS
                                SELECT * FROM TBL_BOOKS B WITH (NOLOCK)
                                WHERE 1 = 1 AND B.IDBook = @BookId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW GetBookDetails");
			migrationBuilder.Sql("DROP VIEW GetAllBooks");
			migrationBuilder.Sql("DROP PROCEDURE GetBookById");
		}
    }
}
