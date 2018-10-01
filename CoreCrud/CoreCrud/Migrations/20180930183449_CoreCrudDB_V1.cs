using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCrud.Migrations
{
    public partial class CoreCrudDB_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LunchBoxManufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    IsSellingOnline = table.Column<bool>(nullable: true),
                    EstablishedOn = table.Column<DateTime>(nullable: false),
                    SalesRevenue = table.Column<decimal>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    CellPhone = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchBoxManufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LunchBox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LunchBoxName = table.Column<string>(nullable: false),
                    SoldDate = table.Column<DateTime>(nullable: true),
                    IsMicrowaveSafe = table.Column<bool>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ManufacturerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LunchBox_LunchBoxManufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "LunchBoxManufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LunchBox_ManufacturerId",
                table: "LunchBox",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LunchBox");

            migrationBuilder.DropTable(
                name: "LunchBoxManufacturer");
        }
    }
}
