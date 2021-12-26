using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Models;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Infrastructure
{
    public class PCPartsShopContext : DbContext
    {
        //public DbSet<Component> Components { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<MOBO> MOBOs { get; set; }
        public DbSet<PSU> PSUs { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public PCPartsShopContext(DbContextOptions<PCPartsShopContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CPU>().HasKey(p => p.ComponentId);
            modelBuilder.Entity<GPU>().HasKey(p => p.ComponentId);
            modelBuilder.Entity<MOBO>().HasKey(p => p.ComponentId);
            modelBuilder.Entity<PSU>().HasKey(p => p.ComponentId);
            modelBuilder.Entity<RAM>().HasKey(p => p.ComponentId);
            modelBuilder.Entity<User>().HasKey(p => p.UserId);
            modelBuilder.Entity<Order>().HasKey(p => p.OrderId);
        }
    }
}
