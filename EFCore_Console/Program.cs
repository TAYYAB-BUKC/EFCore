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

	var firstBook = await GetFirstBook(dbContext);
	Console.WriteLine($"{firstBook.Title} - {firstBook.ISBN}");

	var fluentBook = await GetFirstFluentBook(dbContext);
	Console.WriteLine($"{fluentBook?.Title} - {fluentBook?.ISBN}");

	books = await GetBooksByPublisher(dbContext);
	foreach (var book in books)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}

	var bookByTitle = await GetBookByTitle(dbContext, "New EF Core Book");
	Console.WriteLine($"{bookByTitle.Title} - {bookByTitle.ISBN}");
}

async Task<Book> GetBookByTitle(ApplicationDbContext dbContext, string title)
{
	return await dbContext.Books.Where(b => b.Title == title).FirstOrDefaultAsync();
}

async Task<List<Book>> GetBooksByPublisher(ApplicationDbContext dbContext)
{
	return await dbContext.Books.Where(b => b.Publisher_Id == 3 && b.Price >= 20).ToListAsync();
}

async Task<Book> GetFirstBook(ApplicationDbContext dbContext)
{
	// Throws error if no book is found
	//return await dbContext.Books.FirstAsync();

	// Not throws error if no book is found
	return await dbContext.Books.FirstOrDefaultAsync();
}

async Task<Fluent_Book> GetFirstFluentBook(ApplicationDbContext dbContext)
{
	// Throws error if no book is found
	//return await dbContext.Fluent_Books.FirstAsync();

	// Not throws error if no book is found
	return await dbContext.Fluent_Books.FirstOrDefaultAsync();
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