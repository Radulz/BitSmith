using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCPartsShop.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Freq = table.Column<double>(type: "float", nullable: true),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tech = table.Column<int>(type: "int", nullable: true),
                    MFreq = table.Column<int>(type: "int", nullable: true),
                    TDP = table.Column<int>(type: "int", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    GPU_Freq = table.Column<int>(type: "int", nullable: true),
                    Memory = table.Column<int>(type: "int", nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPU_Tech = table.Column<int>(type: "int", nullable: true),
                    PowerC = table.Column<int>(type: "int", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: true),
                    MOBO_Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryFreqInf = table.Column<int>(type: "int", nullable: true),
                    MemoryFreqSup = table.Column<int>(type: "int", nullable: true),
                    MOBO_MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    RAM_Freq = table.Column<int>(type: "int", nullable: true),
                    Voltage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Components");
        }
    }
}
