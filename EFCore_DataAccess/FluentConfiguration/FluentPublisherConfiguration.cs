using EFCore_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_DataAccess.FluentConfiguration
{
	public class FluentPublisherConfiguration : IEntityTypeConfiguration<Fluent_Publisher>
	{
		public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
		{
			modelBuilder.HasKey(p => p.Publisher_Id);
			modelBuilder.Property(p => p.Name)
						.IsRequired();
		}
	}
}