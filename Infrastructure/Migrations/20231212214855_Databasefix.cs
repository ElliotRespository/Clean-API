using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Databasefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "animalID", "Name" },
                values: new object[,]
                {
                    { new Guid("5e41ca41-d37c-410e-a323-ebdcdf6a7c95"), "Knugen" },
                    { new Guid("70f25c4b-3db1-49f9-9686-f7b32b978dd1"), "Sjöberg" },
                    { new Guid("9739d76e-90c8-4ad5-92ce-21a6bbb7004b"), "Berra" },
                    { new Guid("f5506f95-cd5a-4d60-8d59-5e6af39da8de"), "Kenta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("5e41ca41-d37c-410e-a323-ebdcdf6a7c95"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("70f25c4b-3db1-49f9-9686-f7b32b978dd1"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("9739d76e-90c8-4ad5-92ce-21a6bbb7004b"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("f5506f95-cd5a-4d60-8d59-5e6af39da8de"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "animalID", "Name" },
                values: new object[,]
                {
                    { new Guid("2eedb312-671c-41d2-9793-dd89aa6a4758"), "Berra" },
                    { new Guid("8edbd1b8-c7a5-40b8-86e1-b210d079532a"), "Knugen" },
                    { new Guid("e8ff02d8-8cbf-443a-930b-bdc10b835b68"), "Sjöberg" },
                    { new Guid("ee431950-8515-497d-aafd-309c521f132d"), "Kenta" }
                });
        }
    }
}
