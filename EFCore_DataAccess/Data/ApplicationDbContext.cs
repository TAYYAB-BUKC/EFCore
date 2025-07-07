using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Book> Books { get; set; }

		public DbSet<Genre> Genres { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-MTIIACB\\SQLEXPRESS;Database=EFCore;TrustServerCertificate=True;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10, 6);

			modelBuilder.Entity<Book>().HasData(
				new Book
				{
					IDBook = 1,
					ISBN = "123456",
					Title = "Spider Without Duty",
					Price = 10.99m
				},
				new Book
				{
					IDBook = 2,
					ISBN = "123456456",
					Title = "Fortune Of Time",
					Price = 11.99m
				});

			var bookList = new Book[]
			{
				new Book
				{
					IDBook = 3,
					ISBN = "123456789",
					Title = "Fake Sunday",
					Price = 20.99m
				},
				new Book
				{
					IDBook = 4,
					ISBN = "0123456789",
					Title = "Cookie Jar",
					Price = 25.99m
				},
				new Book
				{
					IDBook = 5,
					ISBN = "1234567890",
					Title = "Cloudy Forest",
					Price = 40.99m
				}
			};
		}
	}
}