using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD_POE_3.Data.Migrations
{
    /// <inheritdoc />
    public partial class cloud_poe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Car_Make = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Kilometres_Travelled = table.Column<int>(type: "int", nullable: true),
                    Service_kilometres = table.Column<int>(type: "int", nullable: true),
                    Avaliable = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarNo);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Driver_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverMobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Driver_ID);
                });

            migrationBuilder.CreateTable(
                name: "Inspector",
                columns: table => new
                {
                    Inspector_no = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    InspectorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InspectorEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InspectorMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspector", x => x.Inspector_no);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Rental_no = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    RentalFee = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CarNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Inspector_no = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Driver_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Rental_no);
                });

            migrationBuilder.CreateTable(
                name: "RentalReturn",
                columns: table => new
                {
                    Return_No = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Rental_no = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "date", nullable: false),
                    ElapsedDate = table.Column<int>(type: "int", nullable: false),
                    Fine = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalReturn", x => x.Return_No);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Inspector");

            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "RentalReturn");
        }
    }
}
