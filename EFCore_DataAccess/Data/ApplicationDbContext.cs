﻿using EFCore_DataAccess.FluentConfiguration;
using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
		{			
		}

		public DbSet<Book> Books { get; set; }

		public DbSet<Genre> Genres { get; set; }

		public DbSet<Author> Authors { get; set; }

		public DbSet<Publisher> Publishers { get; set; }

		public DbSet<SubCategory> SubCategories { get; set; }

		public DbSet<BookDetail> BookDetails { get; set; }

		public DbSet<BookAuthorMapping> BookAuthorMappings { get; set; }

		// Rename table to Fluent_BookDetails
		public DbSet<Fluent_BookDetail> F_BookDetail { get; set; }

		public DbSet<Fluent_Book> Fluent_Books { get; set; }

		public DbSet<Fluent_Author> Fluent_Authors { get; set; }

		public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

		public DbSet<Fluent_BookAuthorMapping> Fluent_BookAuthorMappings { get; set; }

		public DbSet<ViewBook> BookView { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer("Server=DESKTOP-MTIIACB\\SQLEXPRESS;Database=EFCore;TrustServerCertificate=True;Trusted_Connection=True;")
			//			  .LogTo(Console.WriteLine, new []{ DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
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
					Price = 10.99m,
					Publisher_Id = 1
				},
				new Book
				{
					IDBook = 2,
					ISBN = "123456456",
					Title = "Fortune Of Time",
					Price = 11.99m,
					Publisher_Id = 2
				});

			var bookList = new Book[]
			{
				new Book
				{
					IDBook = 3,
					ISBN = "123456789",
					Title = "Fake Sunday",
					Price = 20.99m,
					Publisher_Id = 2
				},
				new Book
				{
					IDBook = 4,
					ISBN = "0123456789",
					Title = "Cookie Jar",
					Price = 25.99m,
					Publisher_Id = 3
				},
				new Book
				{
					IDBook = 5,
					ISBN = "1234567890",
					Title = "Cloudy Forest",
					Price = 40.99m,
					Publisher_Id = 3
				}
			};

			modelBuilder.Entity<Book>().HasData(bookList);

			var publisherList = new Publisher[] {
				new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago" },
				new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
				new Publisher { Publisher_Id = 3, Name = "Pub 1 Ben", Location = "Hawaii" },
			};

			modelBuilder.Entity<Publisher>().HasData(publisherList);

			modelBuilder.Entity<BookAuthorMapping>().HasKey(b => new { b.Author_Id, b.Book_Id });

			var subCategoryList = new SubCategory[] {
				new SubCategory { SubCategory_Id = 1, Name = "Cat 1" },
				new SubCategory { SubCategory_Id = 2, Name = "Cat 2" },
				new SubCategory { SubCategory_Id = 3, Name = "Cat 3" },
			};

			modelBuilder.Entity<SubCategory>().HasData(subCategoryList);

			modelBuilder.ApplyConfiguration(new FluentAuthorConfiguration());
			modelBuilder.ApplyConfiguration(new FluentBookConfiguration());
			modelBuilder.ApplyConfiguration(new FluentBookDetailConfiguration());
			modelBuilder.ApplyConfiguration(new FluentPublisherConfiguration());
			modelBuilder.ApplyConfiguration(new FluentBookAuthorMappingConfiguration());

			modelBuilder.Entity<ViewBook>().HasNoKey().ToView("GetBookDetails");
		}
	}
}