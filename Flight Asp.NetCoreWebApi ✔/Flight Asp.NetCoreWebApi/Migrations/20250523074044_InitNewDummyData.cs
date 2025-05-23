using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Flight_Asp.NetCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitNewDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Flights",
                newName: "Price");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "Price", "TimeArrival", "TimeDeparture" },
                values: new object[] { "BLL", "BER", 80, "Billund", "Berlin", "SK1234", "Scheduled", 750, new DateTime(2025, 6, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AirportFrom", "AvailableSeats", "DestinationFrom", "FlightNumber", "FlightStatus", "Price", "TimeArrival", "TimeDeparture" },
                values: new object[] { "BLL", 65, "Billund", "LH5678", "Scheduled", 790, new DateTime(2025, 6, 1, 19, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "Price", "TimeArrival", "TimeDeparture" },
                values: new object[] { "BLL", "LHR", 72, "Billund", "London", "BA4321", "Scheduled", 950, new DateTime(2025, 6, 1, 10, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "Price", "TimeArrival", "TimeDeparture" },
                values: new object[] { "BLL", "LHR", 90, "Billund", "London", "DY7654", "Scheduled", 910, new DateTime(2025, 6, 1, 18, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "Price", "TimeArrival", "TimeDeparture" },
                values: new object[] { "BLL", "CDG", 85, "Billund", "Paris", "AF2468", "Scheduled", 870, new DateTime(2025, 6, 1, 9, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 7, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "Price", "TimeArrival", "TimeDeparture" },
                values: new object[,]
                {
                    { 6, "BLL", "CDG", 60, "Billund", "Paris", "SK1357", "Scheduled", 890, new DateTime(2025, 6, 1, 17, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "BER", "BLL", 70, "Berlin", "Billund", "SK4321", "Scheduled", 770, new DateTime(2025, 6, 8, 11, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "BER", "BLL", 66, "Berlin", "Billund", "LH8765", "Scheduled", 800, new DateTime(2025, 6, 8, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "LHR", "BLL", 77, "London", "Billund", "BA8765", "Scheduled", 970, new DateTime(2025, 6, 8, 12, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "LHR", "BLL", 92, "London", "Billund", "DY4321", "Scheduled", 940, new DateTime(2025, 6, 8, 20, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "CDG", "BLL", 82, "Paris", "Billund", "AF8642", "Scheduled", 880, new DateTime(2025, 6, 8, 10, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "CDG", "BLL", 69, "Paris", "Billund", "SK7531", "Scheduled", 900, new DateTime(2025, 6, 8, 19, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Flights",
                newName: "price");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "TimeArrival", "TimeDeparture", "price" },
                values: new object[] { "OSL", "CDG", 150, "Oslo", "Paris", "1234", "On Time", new DateTime(2024, 3, 25, 22, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 16, 45, 0, 0, DateTimeKind.Unspecified), 200 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AirportFrom", "AvailableSeats", "DestinationFrom", "FlightNumber", "FlightStatus", "TimeArrival", "TimeDeparture", "price" },
                values: new object[] { "LHR", 120, "London", "5678", "Delayed", new DateTime(2024, 3, 25, 23, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), 180 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "TimeArrival", "TimeDeparture", "price" },
                values: new object[] { "MAD", "FCO", 100, "Madrid", "Rome", "9101", "Cancelled", new DateTime(2024, 3, 26, 0, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 18, 15, 0, 0, DateTimeKind.Unspecified), 150 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "TimeArrival", "TimeDeparture", "price" },
                values: new object[] { "BGO", "OSL", 130, "Bergen", "Oslo", "1121", "Arrived", new DateTime(2024, 3, 26, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), 170 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "DestinationFrom", "DestinationTo", "FlightNumber", "FlightStatus", "TimeArrival", "TimeDeparture", "price" },
                values: new object[] { "CDG", "LHR", 140, "Paris", "London", "3141", "On Time", new DateTime(2024, 3, 26, 2, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 20, 30, 0, 0, DateTimeKind.Unspecified), 190 });
        }
    }
}
