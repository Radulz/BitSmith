using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCPartsShop.Infrastructure.Migrations
{
    public partial class Added_Case_Cooler_SSD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GPUMaximumLength = table.Column<int>(type: "int", nullable: false),
                    CoolerMaximumHeight = table.Column<int>(type: "int", nullable: false),
                    RadiatorSupport = table.Column<bool>(type: "bit", nullable: false),
                    RadiatorSupportLength = table.Column<int>(type: "int", nullable: false),
                    CaseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSUPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.ComponentId);
                });

            migrationBuilder.CreateTable(
                name: "Coolers",
                columns: table => new
                {
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    CoolingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadiatorLength = table.Column<int>(type: "int", nullable: false),
                    NumberOfHeatPipes = table.Column<int>(type: "int", nullable: false),
                    ComponentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coolers", x => x.ComponentId);
                });

            migrationBuilder.CreateTable(
                name: "SSDs",
                columns: table => new
                {
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Connector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDs", x => x.ComponentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Coolers");

            migrationBuilder.DropTable(
                name: "SSDs");
        }
    }
}
