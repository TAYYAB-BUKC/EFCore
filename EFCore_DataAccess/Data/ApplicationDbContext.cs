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
		}
	}
}