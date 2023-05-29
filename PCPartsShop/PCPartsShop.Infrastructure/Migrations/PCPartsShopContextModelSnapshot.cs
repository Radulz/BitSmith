﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCPartsShop.Infrastructure;

namespace PCPartsShop.Infrastructure.Migrations
{
    [DbContext(typeof(PCPartsShopContext))]
    partial class PCPartsShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PCPartsShop.Domain.Models.Case", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoolerMaximumHeight")
                        .HasColumnType("int");

                    b.Property<int>("GPUMaximumLength")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PSUPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<bool>("RadiatorSupport")
                        .HasColumnType("bit");

                    b.Property<int>("RadiatorSupportLength")
                        .HasColumnType("int");

                    b.HasKey("ComponentId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("PCPartsShop.Domain.Models.Cooler", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoolingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfHeatPipes")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RadiatorLength")
                        .HasColumnType("int");

                    b.HasKey("ComponentId");

                    b.ToTable("Coolers");
                });

            modelBuilder.Entity("PCPartsShop.Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsShipped")
                        .HasColumnType("bit");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCounty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PCPartsShop.Domain.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ComponentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComponentImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComponentMake")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComponentModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ComponentPrice")
                        .HasColumnType("float");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("OrderItemQuantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PCPartsShop.Domain.Models.SSD", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Connector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ComponentId");

                    b.ToTable("SSDs");
                });

            modelBuilder.Entity("PCPartsShop.Domain.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PCPartsShop_WebAPI.Models.CPU", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<double>("Freq")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MFreq")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Socket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TDP")
                        .HasColumnType("int");

                    b.Property<int>("Tech")
                        .HasColumnType("int");

                    b.HasKey("ComponentId");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("PCPartsShop_WebAPI.Models.GPU", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Freq")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Memory")
                        .HasColumnType("int");

                    b.Property<string>("MemoryType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PowerC")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Tech")
                        .HasColumnType("int");

                    b.HasKey("ComponentId");

                    b.ToTable("GPUs");
                });

            modelBuilder.Entity("PCPartsShop_WebAPI.Models.MOBO", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Chipset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemoryFreqInf")
                        .HasColumnType("int");

                    b.Property<int>("MemoryFreqSup")
                        .HasColumnType("int");

                    b.Property<string>("MemoryType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Socket")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComponentId");

                    b.ToTable("MOBOs");
                });

            modelBuilder.Entity("PCPartsShop_WebAPI.Models.PSU", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComponentId");

                    b.ToTable("PSUs");
                });

            modelBuilder.Entity("PCPartsShop_WebAPI.Models.RAM", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("ComponentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Freq")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Voltage")
                        .HasColumnType("float");

                    b.HasKey("ComponentId");

                    b.ToTable("RAMs");
                });

            modelBuilder.Entity("PCPartsShop.Domain.Models.OrderItem", b =>
                {
                    b.HasOne("PCPartsShop.Domain.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCPartsShop.Domain.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
