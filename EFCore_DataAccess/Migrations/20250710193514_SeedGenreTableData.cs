using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenreTableData : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Action', 1);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Comedy', 2);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Drama', 3);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Horror', 4);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Romance', 5);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Sci-Fi', 6);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Documentary', 7);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Thriller', 8);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Fantasy', 9);");
			migrationBuilder.Sql("INSERT INTO Genres (GenreName, DisplayOrder) VALUES ('Animation', 10);");
		}


		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 1;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 2;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 3;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 4;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 5;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 6;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 7;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 8;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 9;");
			migrationBuilder.Sql("DELETE FROM Genres WHERE GenreId = 10;");
		}
	}
}