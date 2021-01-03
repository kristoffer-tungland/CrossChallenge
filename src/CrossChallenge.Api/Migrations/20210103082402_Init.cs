using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrossChallenge.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AthleteID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityID);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    AthleteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.AthleteID);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityID", "ActivityType", "AthleteID", "EndTime", "Name", "Score", "StartTime", "Value" },
                values: new object[] { 1, 8, 1, new DateTime(2021, 1, 3, 9, 24, 2, 499, DateTimeKind.Local).AddTicks(7815), "Afternoon walk", 50, new DateTime(2021, 1, 3, 9, 24, 2, 496, DateTimeKind.Local).AddTicks(6650), 10.0 });

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "AthleteID", "Email", "Firstname", "Gender", "Lastname" },
                values: new object[] { 1, "donald@duck.com", "Donald", 1, "Duck" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Athletes");
        }
    }
}
