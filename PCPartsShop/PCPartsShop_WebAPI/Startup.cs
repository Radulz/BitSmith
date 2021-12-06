using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PCPartsShop.Application.Commands.CPUCommands.CreateCPU;
using PCPartsShop.Application.Commands.CPUCommands.RemoveCPU;
using PCPartsShop.Application.Commands.CPUCommands.UpdateCPU;
using PCPartsShop.Application.Commands.GPUCommands.CreateGPU;
using PCPartsShop.Application.Commands.GPUCommands.RemoveGPU;
using PCPartsShop.Application.Commands.GPUCommands.UpdateGPU;
using PCPartsShop.Application.Commands.MOBOCommands.CreateMOBO;
using PCPartsShop.Application.Commands.MOBOCommands.RemoveMOBO;
using PCPartsShop.Application.Commands.MOBOCommands.UpdateMOBO;
using PCPartsShop.Application.Commands.PSUCommands.CreatePSU;
using PCPartsShop.Application.Commands.PSUCommands.RemovePSU;
using PCPartsShop.Application.Commands.PSUCommands.UpdatePSU;
using PCPartsShop.Application.Commands.RAMCommands.CreateRAM;
using PCPartsShop.Application.Commands.RAMCommands.RemoveRAM;
using PCPartsShop.Application.Commands.RAMCommands.UpdateRAM;
using PCPartsShop.Application.Queries.CPUQueries.GetAllCPUs;
using PCPartsShop.Application.Queries.CPUQueries.GetCPUById;
using PCPartsShop.Application.Queries.GPUQueries.GetAllGPUs;
using PCPartsShop.Application.Queries.GPUQueries.GetGPUById;
using PCPartsShop.Application.Queries.MOBOQueries.GetAllMOBOs;
using PCPartsShop.Application.Queries.MOBOQueries.GetMOBOById;
using PCPartsShop.Application.Queries.PSUQueries.GetAllPSUs;
using PCPartsShop.Application.Queries.PSUQueries.GetPSUById;
using PCPartsShop.Application.Queries.RAMQueries.GetAllRAMs;
using PCPartsShop.Application.Queries.RAMQueries.GetRAMById;
using PCPartsShop.Infrastructure;

namespace PCPartsShop_WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PCPartsShop_WebAPI", Version = "v1" });
            });
            services.AddDbContext<PCPartsShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PCPartsShopConnection")));
            services.AddMediatR(typeof(CreateCPUCommand));

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
