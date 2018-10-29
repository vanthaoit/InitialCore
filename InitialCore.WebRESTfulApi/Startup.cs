using AutoMapper;
using InitialCore.Data.EF;
using InitialCore.Data.Entities;
using InitialCore.Data.Settings.Settings;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Service.Implementation;
using InitialCore.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace InitialCore.WebRESTfulApi
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
                   options.UseSqlServer(Configuration.GetConnectionString("AppDbConnection"),
                       b => b.MigrationsAssembly("InitialCore.Data.EF")));
            //services.AddDbContext<Neo4JDriverDbContext>();
            services.AddCors(o => o.AddPolicy("KASCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddAutoMapper();

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IKASService, KASService>();
            services.AddTransient<IRepository<ProductCategory, int>, EFRepository<ProductCategory, int>>();
            services.AddTransient<IRepository<Product, int>, EFRepository<Product, int>>();
            services.AddTransient<IRepository<Data.Entities.Tag, string>, EFRepository<Data.Entities.Tag, string>>();
            services.AddTransient<IRepository<ProductTag, int>, EFRepository<ProductTag, int>>();
            services.AddTransient<IRepository<ProductQuantity, int>, EFRepository<ProductQuantity, int>>();
            services.AddTransient<IRepository<ProductImage, int>, EFRepository<ProductImage, int>>();
            services.AddTransient<IRepository<WholePrice, int>, EFRepository<WholePrice, int>>();
            services.AddTransient<INeo4JDbInitializer, Neo4JDbInitializer>();
            services.AddTransient<IConnectionSettings, ConnectionSettings>();

            services.AddMvc().
                AddJsonOptions(options =>
                options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "InitialCore Project",
                    Description = "KAS API Swagger surface",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "ThaoJohan", Email = "vietnamthaotranvan@gmail.com" },
                    License = new License { Name = "MIT", Url = "https://github.com/vanthaoit/InitialCore" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCors("KASCorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Project API v1.1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}