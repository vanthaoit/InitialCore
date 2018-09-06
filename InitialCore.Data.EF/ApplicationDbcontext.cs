using System;
using System.IO;
using System.Linq;
using InitialCore.Data.EF.Configurations;
using InitialCore.Data.EF.Extensions;
using InitialCore.Data.Entities;
using InitialCore.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InitialCore.Data.EF
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Language> Languages { set; get; }
		public DbSet<SystemConfig> SystemConfigs { get; set; }
		public DbSet<Function> Functions { get; set; }

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<ApplicationRole> ApplicationRoles { get; set; }
		public DbSet<Announcement> Announcements { set; get; }
		public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }

		public DbSet<Blog> Bills { set; get; }
		public DbSet<BillDetail> BillDetails { set; get; }
		public DbSet<Blog> Blogs { set; get; }
		public DbSet<BlogTag> BlogTags { set; get; }
		public DbSet<Color> Colors { set; get; }
		public DbSet<Contact> Contacts { set; get; }
		public DbSet<Feedback> Feedbacks { set; get; }
		public DbSet<Footer> Footers { set; get; }
		public DbSet<Page> Pages { set; get; }
		public DbSet<Product> Products { set; get; }
		public DbSet<ProductCategory> ProductCategories { set; get; }
		public DbSet<ProductImage> ProductImages { set; get; }
		public DbSet<ProductQuantity> ProductQuantities { set; get; }
		public DbSet<ProductTag> ProductTags { set; get; }

		public DbSet<Size> Sizes { set; get; }
		public DbSet<Slide> Slides { set; get; }

		public DbSet<Tag> Tags { set; get; }

		public DbSet<Permission> Permissions { get; set; }
		public DbSet<WholePrice> WholePrices { get; set; }

		public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
		public DbSet<Advertistment> Advertistments { get; set; }
		public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			#region Identity Config

			builder.Entity<IdentityUserClaim<Guid>>().ToTable("ApplicationUserClaims").HasKey(x => x.Id);

			builder.Entity<IdentityRoleClaim<Guid>>().ToTable("ApplicationRoleClaims")
				.HasKey(x => x.Id);

			builder.Entity<IdentityUserLogin<Guid>>().ToTable("ApplicationUserLogins").HasKey(x => x.UserId);

			builder.Entity<IdentityUserRole<Guid>>().ToTable("ApplicationUserRoles")
				.HasKey(x => new { x.RoleId, x.UserId });

			builder.Entity<IdentityUserToken<Guid>>().ToTable("ApplicationUserTokens")
			   .HasKey(x => new { x.UserId });

			#endregion Identity Config

			builder.AddConfiguration(new TagConfiguration());
			builder.AddConfiguration(new BlogTagConfiguration());
			builder.AddConfiguration(new ContactDetailConfiguration());
			builder.AddConfiguration(new FooterConfiguration());
			builder.AddConfiguration(new PageConfiguration());
			builder.AddConfiguration(new FooterConfiguration());
			builder.AddConfiguration(new ProductTagConfiguration());
			builder.AddConfiguration(new SystemConfigConfiguration());
			builder.AddConfiguration(new AdvertistmentPositionConfiguration());

			//base.OnModelCreating(builder);
		}

		public override int SaveChanges()
		{
			var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

			foreach (EntityEntry item in modified)
			{
				var changedOrAddedItem = item.Entity as IDateTracking;
				if (changedOrAddedItem != null)
				{
					if (item.State == EntityState.Added)
					{
						changedOrAddedItem.DateCreated = DateTime.Now;
					}
					changedOrAddedItem.DateModified = DateTime.Now;
				}
			}
			return base.SaveChanges();
		}
	}

	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json").Build();
			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			builder.UseSqlServer(connectionString);
			return new ApplicationDbContext(builder.Options);
		}
	}
}