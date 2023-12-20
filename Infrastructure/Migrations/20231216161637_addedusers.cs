using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "animalID", "Name" },
                values: new object[,]
                {
                    { new Guid("1ac66071-7f30-4c27-8f80-2874869d12e4"), "Kenta" },
                    { new Guid("414d5f8c-fe00-45b0-a495-306aa5b9f7d5"), "Sjöberg" },
                    { new Guid("771a02ee-ab37-48be-8d6e-d2bb4df6350e"), "Berra" },
                    { new Guid("b3e7bd9d-bf20-49b9-97c8-9be145a47d79"), "Knugen" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("3a113ecf-b3e6-48da-80ac-63a047697e81"), "$2a$11$B.6a6n6b24C5N1SS7MSy.uMtdpIqhty8DgBZjqUiBTTLe8oCHFbuC", "Admin", "admin" },
                    { new Guid("3d626a10-5e3c-46b4-8aef-aa4dc5a26adb"), "$2a$11$PA.0zfRDvtvPGG0uBO6NEem7dc7xWkNcpKMbW0xPEpkEmhpsHiPSi", "Normal", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("1ac66071-7f30-4c27-8f80-2874869d12e4"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("414d5f8c-fe00-45b0-a495-306aa5b9f7d5"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("771a02ee-ab37-48be-8d6e-d2bb4df6350e"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "animalID",
                keyValue: new Guid("b3e7bd9d-bf20-49b9-97c8-9be145a47d79"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a113ecf-b3e6-48da-80ac-63a047697e81"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d626a10-5e3c-46b4-8aef-aa4dc5a26adb"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

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
    }
}
