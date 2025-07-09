using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_DataAccess.FluentConfiguration
{
	public class FluentBookAuthorMappingConfiguration : IEntityTypeConfiguration<Fluent_BookAuthorMapping>
	{
		public void Configure(EntityTypeBuilder<Fluent_BookAuthorMapping> modelBuilder)
		{
			modelBuilder.HasKey(b => new { b.Author_Id, b.Book_Id });
			modelBuilder.HasOne(ba => ba.Author)
						.WithMany(ba => ba.AuthorBooks)
						.HasForeignKey(ba => ba.Author_Id);
			modelBuilder.HasOne(b => b.Book)
						.WithMany(b => b.BookAuthors)
						.HasForeignKey(b => b.Book_Id);
		}
	}
}