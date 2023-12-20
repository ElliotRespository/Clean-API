using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Testrunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("2cf59e0f-94e0-44b6-84c5-f3d98c45f1c2"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("2d12a821-096f-4ead-913e-30f6d1d85761"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("b896c2e8-bba2-4984-a693-bfea9bf9611c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("fe149300-5fed-4d0e-8772-73bd1175d0fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6e81fdc5-a601-4fe3-afa6-36ee973ea0ed"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("79ef209d-4e4b-40f8-9108-6c9d64dd41a0"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "animalID", "Name" },
                values: new object[,]
                {
                    { new Guid("0c1d83a6-81e5-487d-8fa9-7edf7746a1a9"), "Berra" },
                    { new Guid("243fe082-dccf-4af2-bd16-66603ea38248"), "Sjöberg" },
                    { new Guid("2ac657d5-25f7-4835-a7d3-dc7753119a32"), "Knugen" },
                    { new Guid("cd001fa8-682f-422b-aefa-d42ee41e1128"), "Kenta" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("dc45328b-24da-457a-b2e5-b82be78afc73"), "$2a$11$z7KK/Snmtq5tZ5cZvmlEqe1gsNSzox5sAKn8CJvbLzkF2nuxdVbTu", "Admin", "admin" },
                    { new Guid("f3ca0e5d-0f9e-44e1-8247-d0d9b1585b52"), "$2a$11$nBU6sTSkpPv3..s9Z5dTjewTyGC.8QcgsSeimeTnJ7m2s6985d8Gu", "Normal", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("0c1d83a6-81e5-487d-8fa9-7edf7746a1a9"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("243fe082-dccf-4af2-bd16-66603ea38248"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("2ac657d5-25f7-4835-a7d3-dc7753119a32"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("cd001fa8-682f-422b-aefa-d42ee41e1128"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dc45328b-24da-457a-b2e5-b82be78afc73"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f3ca0e5d-0f9e-44e1-8247-d0d9b1585b52"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "animalID", "Name" },
                values: new object[,]
                {
                    { new Guid("2cf59e0f-94e0-44b6-84c5-f3d98c45f1c2"), "Sjöberg" },
                    { new Guid("2d12a821-096f-4ead-913e-30f6d1d85761"), "Berra" },
                    { new Guid("b896c2e8-bba2-4984-a693-bfea9bf9611c"), "Kenta" },
                    { new Guid("fe149300-5fed-4d0e-8772-73bd1175d0fb"), "Knugen" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("6e81fdc5-a601-4fe3-afa6-36ee973ea0ed"), "$2a$11$Qmak8YI/vaOaCglddn4Nbu5GYaEE/60Kw8nD5F5/pr6MotnBaJNDG", "Admin", "admin" },
                    { new Guid("79ef209d-4e4b-40f8-9108-6c9d64dd41a0"), "$2a$11$0lp.mpcEimZe0wV2.fLUUeFjs6ynlOjyUxJhVPcxzUj04ulhxUhBu", "Normal", "user" }
                });
        }
    }
}
