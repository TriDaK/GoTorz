using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Country", "Email", "Name", "Phone", "StreetName", "StreetNo", "Zipcode" },
                values: new object[,]
                {
                    { 1, "Paris", "France", "eiffel@hotel.com", "Eiffel Hotel", "+33 123456789", "Rue de Paris", "10", 75001 },
                    { 2, "Paris", "France", "louvre@hotel.com", "Louvre Inn", "+33 987654321", "Rue de Louvre", "22B", 75002 },
                    { 3, "London", "UK", "bigben@hotel.com", "Big Ben Hotel", "+44 123456789", "Westminster Rd", "5", 10001 },
                    { 4, "London", "UK", "thames@hotel.com", "Thames View Inn", "+44 987654321", "River St", "18A", 10002 },
                    { 5, "Berlin", "Germany", "central@hotel.com", "Berlin Central Hotel", "+49 123456789", "Hauptstrasse", "77", 10115 },
                    { 6, "Berlin", "Germany", "brandenburg@hotel.com", "Brandenburger Inn", "+49 987654321", "Torstrasse", "66B", 10117 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Capacity", "CheckIn", "CheckOut", "HotelID", "Price", "Rating", "Type" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), 1, 100.0, 4.2000000000000002, "Single" },
                    { 2, 2, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 1, 150.0, 4.5, "Double" },
                    { 3, 4, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 1, 300.0, 4.7999999999999998, "Suite" },
                    { 4, 1, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), 2, 90.0, 3.7999999999999998, "Single" },
                    { 5, 2, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 2, 140.0, 4.0, "Double" },
                    { 6, 4, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 2, 280.0, 4.5999999999999996, "Suite" },
                    { 7, 1, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), 3, 110.0, 4.0, "Single" },
                    { 8, 2, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 3, 160.0, 4.0999999999999996, "Double" },
                    { 9, 4, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 3, 310.0, 4.9000000000000004, "Suite" },
                    { 10, 1, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), 4, 95.0, 3.8999999999999999, "Single" },
                    { 11, 2, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 4, 145.0, 4.2000000000000002, "Double" },
                    { 12, 4, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 4, 295.0, 4.7000000000000002, "Suite" },
                    { 13, 1, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), 5, 105.0, 4.2999999999999998, "Single" },
                    { 14, 2, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 5, 155.0, 4.4000000000000004, "Double" },
                    { 15, 4, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 5, 320.0, 4.9000000000000004, "Suite" },
                    { 16, 1, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), 6, 98.0, 4.0999999999999996, "Single" },
                    { 17, 2, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 6, 142.0, 4.2999999999999998, "Double" },
                    { 18, 4, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 6, 305.0, 4.5999999999999996, "Suite" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelID",
                table: "Rooms",
                column: "HotelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
