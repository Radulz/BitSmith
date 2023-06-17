using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PCPartsShop.Application.Commands.CPUCommands.CreateCPU;
using PCPartsShop.Infrastructure;
using PCPartsShop.WebAPI;
using PCPartsShop.Application.Abstract;
using PCPartsShop.Application.Services;
using PCPartsShop.Domain.ConfigurationDtos;

namespace PCPartsShop_WebAPI
{
    public class Startup
    {
        public string ConnectionString { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString(Constants.DatabaseConnections.PCPartsShopDatabase);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BitSmith_WebAPI", Version = "v1" });
            });
            services.AddDbContext<PCPartsShopContext>(options => options.UseSqlServer(ConnectionString));
            services.AddMediatR(typeof(CreateCPUCommand));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ICompatibilityChecker, CompatibilityChecker>();
            services.Configure<AzureBlobStorageConfig>(Configuration.GetSection(nameof(AzureBlobStorageConfig)));
            services.AddSingleton<IFileService, FileService>();
            services.Configure<BrevoConfig>(Configuration.GetSection(nameof(BrevoEmailProvider)));
            services.AddHttpClient<IEmailProvider, BrevoEmailProvider>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PCPartsShop_WebAPI v1"));
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
