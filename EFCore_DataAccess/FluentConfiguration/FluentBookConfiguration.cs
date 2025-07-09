using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_DataAccess.FluentConfiguration
{
	public class FluentBookConfiguration : IEntityTypeConfiguration<Fluent_Book>
	{
		public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
		{
			modelBuilder.ToTable("TBL_FluentBooks");
			modelBuilder.HasKey(b => b.IDBook);
			modelBuilder.Property(b => b.Title)
						.HasMaxLength(50)
						.IsRequired();
			modelBuilder.Property(b => b.ISBN)
						.HasColumnName("Fluent_Book_ISBN");
			modelBuilder.Property(b => b.Price)
						.IsRequired();
			modelBuilder.Ignore(b => b.PriceRange);
			modelBuilder.HasOne(b => b.Publisher)
						.WithMany(p => p.Books)
						.HasForeignKey(b => b.Publisher_Id);
		}
	}
}