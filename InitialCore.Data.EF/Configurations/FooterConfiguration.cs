using InitialCore.Data.EF.Extensions;
using InitialCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialCore.Data.EF.Configurations
{
	public class FooterConfiguration : DbEntityConfiguration<Footer>
	{
		public override void Configure(EntityTypeBuilder<Footer> entity)
		{
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Id).HasMaxLength(255)
				.HasColumnType("varchar(255)").IsRequired();
			// etc.
		}
	}
}