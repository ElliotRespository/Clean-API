using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "animalID", "Name" },
                values: new object[,]
                {
                    { new Guid("89c8914f-9282-41b9-a8e2-cedcca405101"), "Sjöberg" },
                    { new Guid("bb4a9eb5-5f26-4697-b507-8692201ff4db"), "Berra" },
                    { new Guid("c3e58d7b-e7b7-4999-a5ed-34ca304ec5a1"), "Knugen" },
                    { new Guid("f8bc0cc4-a8db-4e1d-a435-e7b542aa12b5"), "Kenta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("89c8914f-9282-41b9-a8e2-cedcca405101"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("bb4a9eb5-5f26-4697-b507-8692201ff4db"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("c3e58d7b-e7b7-4999-a5ed-34ca304ec5a1"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("f8bc0cc4-a8db-4e1d-a435-e7b542aa12b5"));

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
    }
}
