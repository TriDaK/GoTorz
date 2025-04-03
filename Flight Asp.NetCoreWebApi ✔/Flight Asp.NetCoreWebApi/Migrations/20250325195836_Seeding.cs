using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Flight_Asp.NetCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "TimeArrival", "TimeDeparture" },
                values: new object[,]
                {
                    { 1, "Oslo", "Paris", 1234, "On Time", new DateTime(2024, 3, 25, 22, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 16, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "London", "Berlin", 5678, "Delayed", new DateTime(2024, 3, 25, 23, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 17, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Madrid", "Rome", 9101, "Cancelled", new DateTime(2024, 3, 26, 0, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Bergen", "Oslo", 1121, "Arrived", new DateTime(2024, 3, 26, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Paris", "London", 3141, "On Time", new DateTime(2024, 3, 26, 2, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 20, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
