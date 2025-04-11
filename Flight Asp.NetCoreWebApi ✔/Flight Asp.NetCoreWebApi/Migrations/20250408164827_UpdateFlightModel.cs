using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Asp.NetCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlightModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AirportFrom",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AirportTo",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "FlightNumber", "price" },
                values: new object[] { "OSL", "CDG", 150, "1234", 200 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "FlightNumber", "price" },
                values: new object[] { "LHR", "BER", 120, "5678", 180 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "FlightNumber", "price" },
                values: new object[] { "MAD", "FCO", 100, "9101", 150 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "FlightNumber", "price" },
                values: new object[] { "BGO", "OSL", 130, "1121", 170 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AirportFrom", "AirportTo", "AvailableSeats", "FlightNumber", "price" },
                values: new object[] { "CDG", "LHR", 140, "3141", 190 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirportFrom",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirportTo",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "FlightNumber",
                table: "Flights",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                column: "FlightNumber",
                value: 1234);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                column: "FlightNumber",
                value: 5678);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                column: "FlightNumber",
                value: 9101);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                column: "FlightNumber",
                value: 1121);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                column: "FlightNumber",
                value: 3141);
        }
    }
}
