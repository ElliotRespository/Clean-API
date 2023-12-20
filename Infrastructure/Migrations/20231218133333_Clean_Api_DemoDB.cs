using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Clean_Api_DemoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
