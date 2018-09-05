﻿using InitialCore.Data.EF.Extensions;
using InitialCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialCore.Data.EF.Configurations
{
	public class ProductTagConfiguration : DbEntityConfiguration<ProductTag>
	{
		public override void Configure(EntityTypeBuilder<ProductTag> entity)
		{
			entity.Property(c => c.TagId).HasMaxLength(255).IsRequired()
			.HasColumnType("varchar(255)");
			// etc.
		}
	}
}