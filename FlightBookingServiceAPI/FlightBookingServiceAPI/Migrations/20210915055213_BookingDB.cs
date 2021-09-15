using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightBookingServiceAPI.Migrations
{
    public partial class BookingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    PNR = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    TicketCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.PNR);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNR = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meals = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassengerDetails_Bookings_PNR",
                        column: x => x.PNR,
                        principalTable: "Bookings",
                        principalColumn: "PNR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDetails_PNR",
                table: "PassengerDetails",
                column: "PNR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerDetails");

            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
