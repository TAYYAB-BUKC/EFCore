using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_DataAccess.FluentConfiguration
{
	public class FluentBookDetailConfiguration : IEntityTypeConfiguration<Fluent_BookDetail>
	{
		public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
		{
			modelBuilder.ToTable("Fluent_BookDetails");
			modelBuilder.HasKey(bd => bd.BookDetail_Id);
			modelBuilder.Property(bd => bd.NumberOfChapters)
						.HasColumnName("NoOfChapters")
						.IsRequired();
			modelBuilder.HasOne(bd => bd.Book)
						.WithOne(b => b.Details)
						.HasForeignKey<Fluent_BookDetail>(bd => bd.Book_Id);
		}
	}
}