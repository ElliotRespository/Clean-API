using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Lagttillkatter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    animalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.animalID);
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "animalID", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("737309b9-6bc7-4410-a236-2eef0e4cb0cb"), false, "LedsenKatt" },
                    { new Guid("74f28898-2461-4da1-898f-b329433eb737"), false, "Fluffig" },
                    { new Guid("b1e285e7-2432-4ee7-8b4b-33247a8cb9f1"), false, "Argjävel" },
                    { new Guid("fca3371f-b7da-4158-a071-4c2ba7cbc62e"), false, "Simba" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "animalID", "Name" },
                values: new object[,]
                {
                    { new Guid("1a1af0e1-606d-4108-9459-55d27d1dc5de"), "Kenta" },
                    { new Guid("58213449-2379-4f48-b8e4-208e605e1591"), "Sjöberg" },
                    { new Guid("c4abeb61-102e-4c10-8823-89b2b49a1939"), "Knugen" },
                    { new Guid("f3b16b92-d629-478c-87e6-21c4ff920dfa"), "Berra" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("8488cd98-79ff-472d-a81d-c450bc0d93bd"), "$2a$11$nnCH3mln7nstoJuzg4OGAu0tTUVSAX7U8jbQZeiRlATIm1jh.Jopu", "Normal", "user" },
                    { new Guid("86b61042-9569-43e5-8524-0a64e504e83b"), "$2a$11$2BT66s/l4Z4LJGjmGOzky.7th2QbSumP3H5YT4ylzJqipMZDfuEIS", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("1a1af0e1-606d-4108-9459-55d27d1dc5de"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("58213449-2379-4f48-b8e4-208e605e1591"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("c4abeb61-102e-4c10-8823-89b2b49a1939"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("f3b16b92-d629-478c-87e6-21c4ff920dfa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8488cd98-79ff-472d-a81d-c450bc0d93bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86b61042-9569-43e5-8524-0a64e504e83b"));

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
    }
}
