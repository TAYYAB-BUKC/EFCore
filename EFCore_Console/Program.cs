// See https://aka.ms/new-console-template for more information
using EFCore_DataAccess.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (ApplicationDbContext dbContext = new())
{
	// Create database if doesnot exist
	await dbContext.Database.EnsureCreatedAsync();

	if((await dbContext.Database.GetPendingMigrationsAsync()).Count() > 0)
	{
		await dbContext.Database.MigrateAsync();
	}
}