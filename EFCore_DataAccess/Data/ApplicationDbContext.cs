using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Book> Books { get; set; }

		public DbSet<Genre> Genres { get; set; }

		public DbSet<Author> Authors { get; set; }

		public DbSet<Publisher> Publishers { get; set; }

		public DbSet<SubCategory> SubCategories { get; set; }

		public DbSet<BookDetail> BookDetails { get; set; }

		// Rename table to Fluent_BookDetails
		public DbSet<Fluent_BookDetail> F_BookDetail { get; set; }

		public DbSet<Fluent_Book> Fluent_Books { get; set; }

		public DbSet<Fluent_Author> Fluent_Authors { get; set; }

		public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

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

			#region Fluent_Book
			modelBuilder.Entity<Fluent_Book>()
						.ToTable("TBL_FluentBooks");
			modelBuilder.Entity<Fluent_Book>()
						.HasKey(b => b.IDBook);
			modelBuilder.Entity<Fluent_Book>()
						.Property(b => b.Title)
						.HasMaxLength(50)
						.IsRequired();
			modelBuilder.Entity<Fluent_Book>()
						.Property(b => b.ISBN)
						.HasColumnName("Fluent_Book_ISBN");
			modelBuilder.Entity<Fluent_Book>()
						.Property(b => b.Price)
						.IsRequired();
			modelBuilder.Entity<Fluent_Book>()
						.Ignore(b => b.PriceRange);
			#endregion

			#region Fluent_BookDetail
			modelBuilder.Entity<Fluent_BookDetail>()
						.ToTable("Fluent_BookDetails");
			modelBuilder.Entity<Fluent_BookDetail>()
						.HasKey(bd => bd.BookDetail_Id);
			modelBuilder.Entity<Fluent_BookDetail>()
						.Property(bd => bd.NumberOfChapters)
						.HasColumnName("NoOfChapters")
						.IsRequired();
			modelBuilder.Entity<Fluent_BookDetail>()
						.HasOne(bd => bd.Book)
						.WithOne(b => b.Details)
						.HasForeignKey<Fluent_BookDetail>(bd => bd.Book_Id);
			#endregion

			#region Fluent_Author
			modelBuilder.Entity<Fluent_Author>()
						.HasKey(a => a.Author_Id);
			modelBuilder.Entity<Fluent_Author>()
						.Property(a => a.FirstName)
						.HasMaxLength(50)
						.IsRequired();
			modelBuilder.Entity<Fluent_Author>()
						.Property(a => a.LastName)
						.IsRequired();
			modelBuilder.Entity<Fluent_Author>()
						.Ignore(a => a.FullName);
			#endregion

			#region Fluent_Publisher	
			modelBuilder.Entity<Fluent_Publisher>()
						.HasKey(p => p.Publisher_Id);
			modelBuilder.Entity<Fluent_Publisher>()
						.Property(p => p.Name)
						.IsRequired();
			#endregion
		}
	}
}