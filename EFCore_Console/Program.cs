// See https://aka.ms/new-console-template for more information
using EFCore_DataAccess.Data;
using EFCore_DataAccess.Migrations;
using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;

//Console.WriteLine("Hello, World!");

using (ApplicationDbContext dbContext = new())
{
	// Create database if doesnot exist
	await dbContext.Database.EnsureCreatedAsync();

	if((await dbContext.Database.GetPendingMigrationsAsync()).Count() > 0)
	{
		await dbContext.Database.MigrateAsync();
	}

	var books = await GetAllBooks(dbContext);
	foreach (var book in books)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}

	Console.WriteLine("Creating a book");

	await AddBook(dbContext);

	books = await GetAllBooks(dbContext);
	foreach (var book in books)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}
}

async Task AddBook(ApplicationDbContext dbContext)
{
	Book newBook = new()
	{
		Title = "New EF Core Book",
		ISBN = "1234560000",
		Price = 50.99m,
		Publisher_Id = 2
	};

	await dbContext.AddAsync(newBook);
	await dbContext.SaveChangesAsync();
}

Console.ReadKey();

async Task<List<Book>> GetAllBooks(ApplicationDbContext dbContext)
{
	return await dbContext.Books.ToListAsync();
}