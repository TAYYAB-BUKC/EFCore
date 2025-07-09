using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_DataAccess.FluentConfiguration
{
	public class FluentAuthorConfiguration : IEntityTypeConfiguration<Fluent_Author>
	{
		public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
		{
			modelBuilder.HasKey(a => a.Author_Id);
			modelBuilder.Property(a => a.FirstName)
						.HasMaxLength(50)
						.IsRequired();
			modelBuilder.Property(a => a.LastName)
						.IsRequired();
			modelBuilder.Ignore(a => a.FullName);
		}
	}
}