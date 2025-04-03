using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Asp.NetCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<int>(type: "int", nullable: false),
                    FlightStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeArrival = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
