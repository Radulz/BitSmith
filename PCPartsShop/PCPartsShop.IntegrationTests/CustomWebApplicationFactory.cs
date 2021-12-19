using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PCPartsShop.Infrastructure;
using PCPartsShop.IntegrationTests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private SqliteConnection _connection;

        public CustomWebApplicationFactory()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<PCPartsShopContext>));

                services.Remove(serviceDescriptor);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkSqlite().BuildServiceProvider();

                services.AddDbContext<PCPartsShopContext>(op =>
                {
                    op.UseSqlite(_connection);
                    op.UseInternalServiceProvider(serviceProvider);
                }, ServiceLifetime.Scoped);

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<PCPartsShopContext>();

                    db.Database.EnsureDeleted();

                    db.Database.EnsureCreated();

                    Utilities.InitializeDbForTests(db);
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _connection.Close();
            _connection.Dispose();
        }
    }
}
