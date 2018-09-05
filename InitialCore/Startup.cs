using System;
using AutoMapper;
using InitialCore.Data.EF;
using InitialCore.Data.EF.Repositories;
using InitialCore.Data.Entities;
using InitialCore.Data.IRepositories;
using InitialCore.Service.Implementation;
using InitialCore.Service.Interfaces;
using InitialCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InitialCore
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
				o => o.MigrationsAssembly("InitialApp.Data.EF")));

			services.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			// Configure Identity
			services.Configure<IdentityOptions>(options =>
			{
				// Password settings
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;

				// Lockout settings
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
				options.Lockout.MaxFailedAccessAttempts = 10;

				// User settings
				options.User.RequireUniqueEmail = true;
			});

			services.AddAutoMapper();
			// Add application services.
			services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
			services.AddScoped<RoleManager<ApplicationRole>, RoleManager<ApplicationRole>>();

			services.AddSingleton(Mapper.Configuration);
			services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

			services.AddTransient<IEmailSender, EmailSender>();
			services.AddTransient<DbInitializer>();

			services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

			services.AddTransient<IProductCategoryService, ProductCategoryService>();

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInitializer dbInitializer)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
			dbInitializer.Seed().Wait();
		}
	}
}