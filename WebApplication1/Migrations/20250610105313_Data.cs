using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Racers",
                columns: new[] { "RacerId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Anna", "Nowak" },
                    { 2, "Jan", "Kowal" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "RaceId", "Date", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Here and there", "Big race" },
                    { 2, new DateTime(1980, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "England", "Small race" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "TrackId", "LengthInKm", "Name" },
                values: new object[,]
                {
                    { 1, 123m, "TEST1" },
                    { 2, 200m, "TEST2" }
                });

            migrationBuilder.InsertData(
                table: "Track_Race",
                columns: new[] { "TrackRaceId", "BestTimeInSeconds", "Laps", "RaceId", "TrackId" },
                values: new object[,]
                {
                    { 1, 2500, 10, 1, 1 },
                    { 2, 2500, 15, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Race_Participation",
                columns: new[] { "RacerId", "TrackRaceId", "FinishTimeInSeconds", "Position" },
                values: new object[,]
                {
                    { 1, 1, 2000, 1 },
                    { 2, 1, 2500, 2 },
                    { 1, 2, 2500, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Race_Participation",
                keyColumns: new[] { "RacerId", "TrackRaceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Race_Participation",
                keyColumns: new[] { "RacerId", "TrackRaceId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Race_Participation",
                keyColumns: new[] { "RacerId", "TrackRaceId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Racers",
                keyColumn: "RacerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Racers",
                keyColumn: "RacerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track_Race",
                keyColumn: "TrackRaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track_Race",
                keyColumn: "TrackRaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 1);
        }
    }
}
