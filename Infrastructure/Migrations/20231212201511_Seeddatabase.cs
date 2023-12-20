using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "animalID", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345671"), "DogTest1" },
                    { new Guid("12345678-1234-5678-1234-567812345672"), "DogTest2" },
                    { new Guid("12345678-1234-5678-1234-567812345673"), "DogTest3" },
                    { new Guid("12345678-1234-5678-1234-567812345674"), "DogTest4" },
                    { new Guid("2eedb312-671c-41d2-9793-dd89aa6a4758"), "Berra" },
                    { new Guid("8edbd1b8-c7a5-40b8-86e1-b210d079532a"), "Knugen" },
                    { new Guid("e8ff02d8-8cbf-443a-930b-bdc10b835b68"), "Sjöberg" },
                    { new Guid("ee431950-8515-497d-aafd-309c521f132d"), "Kenta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("12345678-1234-5678-1234-567812345671"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("12345678-1234-5678-1234-567812345672"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("12345678-1234-5678-1234-567812345673"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("12345678-1234-5678-1234-567812345674"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("2eedb312-671c-41d2-9793-dd89aa6a4758"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("8edbd1b8-c7a5-40b8-86e1-b210d079532a"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("e8ff02d8-8cbf-443a-930b-bdc10b835b68"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("ee431950-8515-497d-aafd-309c521f132d"));
        }
    }
}
