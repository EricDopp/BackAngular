using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularProject.Migrations
{
    public partial class initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.eventId);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    favoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    eventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.favoriteId);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "eventId", "description", "location", "name", "time" },
                values: new object[,]
                {
                    { 1, "Enjoy live music in the open air.", "City Park", "Concert in the Park", new DateTime(2023, 12, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Explore the latest trends in technology.", "Conference Center", "Tech Conference", new DateTime(2023, 12, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "A celebration of diverse cuisines.", "Downtown Square", "Food Festival", new DateTime(2023, 12, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Cheer for your favorite teams.", "Sports Complex", "Sports Tournament", new DateTime(2023, 12, 15, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Explore the world of contemporary art.", "Art Gallery", "Art Exhibition", new DateTime(2023, 12, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Watch a blockbuster under the stars.", "Community Park", "Movie Night", new DateTime(2023, 12, 25, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Hands-on experiments and demonstrations.", "Science Museum", "Science Fair", new DateTime(2023, 12, 30, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Discuss the latest literary masterpiece.", "Local Library", "Book Club Meeting", new DateTime(2024, 1, 5, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Get fit with intense workouts.", "Fitness Studio", "Fitness Bootcamp", new DateTime(2024, 1, 10, 6, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Join hands for a cleaner neighborhood.", "Various Locations", "Community Cleanup", new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Favorites");
        }
    }
}
