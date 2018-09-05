using InitialCore.Data.EF.Extensions;
using InitialCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialCore.Data.EF.Configurations
{
	public class TagConfiguration : DbEntityConfiguration<Tag>
	{
		public override void Configure(EntityTypeBuilder<Tag> entity)
		{
			entity.Property(c => c.Id).HasMaxLength(50)
				.IsRequired().HasColumnType("varchar(50)");
		}
	}
}