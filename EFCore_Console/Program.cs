// See https://aka.ms/new-console-template for more information
using EFCore_DataAccess.Data;
using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;

//Console.WriteLine("Hello, World!");

using (ApplicationDbContext dbContext = null)
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

	//Console.WriteLine("Creating a book");

	//await AddBook(dbContext);

	//books = await GetAllBooks(dbContext);
	//foreach (var book in books)
	//{
	//	Console.WriteLine($"{book.Title} - {book.ISBN}");
	//}

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

	Console.WriteLine($"------------------GetBookUsingFind--------------------------------");
	var bookUsingFind = await GetBookUsingFind(dbContext, 6);
	Console.WriteLine($"{bookUsingFind?.Title} - {bookUsingFind?.ISBN}");

	Console.WriteLine($"------------------GetBookUsingSingle--------------------------------");
	var bookUsingSingle = await GetBookUsingSingle(dbContext);
	Console.WriteLine($"{bookUsingSingle?.Title} - {bookUsingSingle?.ISBN}");

	Console.WriteLine($"------------------GetBooksUsingLike--------------------------------");
	books = await GetBooksUsingLike(dbContext);
	foreach (var book in books)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}

	Console.WriteLine($"------------------GetBooksUsingDeferredExecution--------------------------------");
	var booksUsingDeferredExecution = GetBooksUsingDeferredExecution(dbContext);
	foreach (var book in booksUsingDeferredExecution)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}

	Console.WriteLine($"------------------GetBooksUsingMultipleOrderBy--------------------------------");
	books = await GetBooksUsingMultipleOrderBy(dbContext);
	foreach (var book in books)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}

	Console.WriteLine($"------------------GetBooksByPagination--------------------------------");
	books = await GetBooksByPagination(dbContext, 0, 2);
	foreach (var book in books)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}

	Console.WriteLine($"------------------GetBooksByPagination--------------------------------");
	books = await GetBooksByPagination(dbContext, 2, 4);
	foreach (var book in books)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}

	Console.WriteLine($"------------------UpdateBook--------------------------------");
	var updatedBook = await UpdateBook(dbContext);
	Console.WriteLine($"{updatedBook?.Title} - {updatedBook?.ISBN}");

	Console.WriteLine($"------------------UpdateMultipleBooks--------------------------------");
	books = await UpdateMultipleBooks(dbContext, 1);
	foreach (var book in books)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}

	Console.WriteLine($"------------------DeleteBookById--------------------------------");
	var deletedBook = await DeleteBookById(dbContext, 8);
	Console.WriteLine($"{deletedBook.Title} - {deletedBook.ISBN}");

	Console.WriteLine($"------------------DeleteBooksByTitle--------------------------------");
	var deletedBooksByTitle = await DeleteBooksByTitle(dbContext, "New EF Core Book");
	foreach (var book in deletedBooksByTitle)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}
}

async Task<List<Book>> DeleteBooksByTitle(ApplicationDbContext dbContext, string title)
{
	var books = await dbContext.Books.Where(b => b.Title == title).ToListAsync();
	dbContext.RemoveRange(books);
	await dbContext.SaveChangesAsync();
	return books;
}

async Task<Book> DeleteBookById(ApplicationDbContext dbContext, int id)
{
	var book = await dbContext.Books.FindAsync(id);
	dbContext.Remove(book);
	await dbContext.SaveChangesAsync();
	return book;
}

async Task<List<Book>> UpdateMultipleBooks(ApplicationDbContext dbContext, int publisherID)
{
	var books = await dbContext.Books.Where(b => b.Publisher_Id == publisherID).ToListAsync();
	foreach (var book in books)
	{
		book.Price = 99.99m;
	}
	
	await dbContext.SaveChangesAsync();
	return books;
}

async Task<Book> UpdateBook(ApplicationDbContext dbContext)
{
	var book = await dbContext.Books.FindAsync(7);
	if(book is not null)
	{
		book.ISBN = "Updated ISBN By EF Core";
	}
	await dbContext.SaveChangesAsync();
	return book;
}

async Task<List<Book>> GetBooksByPagination(ApplicationDbContext dbContext, int skip, int take)
{
	return await dbContext.Books.Skip(skip).Take(take).ToListAsync();
}

async Task<List<Book>> GetBooksUsingMultipleOrderBy(ApplicationDbContext dbContext)
{
	return await dbContext.Books.OrderBy(b => b.Title).ThenByDescending(b => b.ISBN).ToListAsync();
}

DbSet<Book> GetBooksUsingDeferredExecution(ApplicationDbContext dbContext)
{
	return dbContext.Books;
}

async Task<List<Book>> GetBooksUsingLike(ApplicationDbContext dbContext)
{
	// it uses this pattern in LIKE '%a%'
	//return await dbContext.Books.Where(b => b.ISBN.Contains("12")).ToListAsync();

	// it uses this pattern in LIKE 'a%'
	return await dbContext.Books.Where(b => EF.Functions.Like(b.ISBN, "12%")).ToListAsync();
}

async Task<Book> GetBookUsingSingle(ApplicationDbContext dbContext)
{
	// Throw exception if no book found
	//return await dbContext.Books.SingleAsync(b => b.ISBN == "1234456789");

	// Throws exception if two book found
	//return await dbContext.Books.SingleOrDefaultAsync(b => b.Publisher_Id == 3);

	// return null if book not found
	return await dbContext.Books.SingleOrDefaultAsync(b => b.ISBN == "123456789");
}

async Task<Book> GetBookUsingFind(ApplicationDbContext dbContext, int id)
{
	// Only works for primary key column and return null if not found
	return await dbContext.Books.FindAsync(id);
}

async Task<Book> GetBookByTitle(ApplicationDbContext dbContext, string title)
{
	return await dbContext.Books.FirstOrDefaultAsync(b => b.Title == title);
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