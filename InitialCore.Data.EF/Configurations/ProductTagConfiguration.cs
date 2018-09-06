using InitialCore.Data.EF.Extensions;
using InitialCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialCore.Data.EF.Configurations
{
	public class ProductTagConfiguration : DbEntityConfiguration<ProductTag>
	{
		public override void Configure(EntityTypeBuilder<ProductTag> entity)
		{
			entity.Property(c => c.TagId).HasMaxLength(50).IsRequired()
		   .HasColumnType("varchar(50)");
			// etc.
		}
	}
}