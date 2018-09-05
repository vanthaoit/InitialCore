using InitialCore.Data.EF.Extensions;
using InitialCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialCore.Data.EF.Configurations
{
	public class FunctionConfiguration : DbEntityConfiguration<Function>
	{
		public override void Configure(EntityTypeBuilder<Function> entity)
		{
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Id).IsRequired()
			.HasColumnType("varchar(128)");
			// etc.
		}
	}
}