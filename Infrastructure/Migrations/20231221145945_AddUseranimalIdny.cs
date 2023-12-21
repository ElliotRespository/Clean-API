using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUseranimalIdny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnimals",
                table: "UserAnimals");

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("0287feff-4fc0-4952-bb93-5bc83156bc9e"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("030a88e4-925b-450b-b52a-f909331ae632"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("1807c69a-84d3-451f-b501-71b0d396d8e6"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("1a699173-cce9-4027-84b9-757a810ae5e7"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("1a6cb673-b380-46e8-827e-7a13f606479a"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("5206eda5-7498-4c16-8c63-a5c7c0dfd90f"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("9cfa300c-6b20-408b-a86b-5f5d05b84177"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("dfeea36b-6c50-4ca0-9a45-ef34acb08a20"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66bcd304-e665-450a-b5a8-7b4ec74aab07"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a9925df5-f507-438c-a158-5944b05842c1"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnimals",
                table: "UserAnimals",
                column: "UserAnimalId");

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("0dfaf499-11e3-465d-abba-f757871161fe"), "Cat", false, "Argjävel" },
                    { new Guid("11d504b8-6549-421a-9b76-4bf0099c3c4f"), "Cat", false, "Simba" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[] { new Guid("4c3ce220-fd70-4f70-8ca6-abbcf626e3ab"), "Dog", "Sjöberg" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("4cd3091d-0473-4ae7-a242-377b0ad521ed"), "Cat", false, "Fluffig" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("5828f472-b940-4dd0-a869-d08bfd959d95"), "Dog", "Berra" },
                    { new Guid("c05de278-e58c-44f0-acab-03b34de88ff5"), "Dog", "Kenta" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("e5fdc5b2-ee1b-4d31-9b4b-dda03febf6b2"), "Cat", false, "LedsenKatt" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[] { new Guid("e7232a2b-ff59-4c77-b1b3-853bec44f6bf"), "Dog", "Knugen" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("21bd659d-8a93-4b30-acee-ac646b20f7ea"), "$2a$11$LneT/sEKeGA2Ehzl7gBS2.gucC5Mx1UqEk0Uy8lccpXru2H8BXHSy", "Admin", "admin" },
                    { new Guid("5855f6f6-f435-4dd3-bac4-8e5cf506024d"), "$2a$11$h6hXWZlYLXZYExpav5AoiuKNQ.7AVhHxPUkImwU9jybO5TFNn7rIW", "Normal", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_UserId",
                table: "UserAnimals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnimals",
                table: "UserAnimals");

            migrationBuilder.DropIndex(
                name: "IX_UserAnimals_UserId",
                table: "UserAnimals");

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("0dfaf499-11e3-465d-abba-f757871161fe"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("11d504b8-6549-421a-9b76-4bf0099c3c4f"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("4c3ce220-fd70-4f70-8ca6-abbcf626e3ab"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("4cd3091d-0473-4ae7-a242-377b0ad521ed"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("5828f472-b940-4dd0-a869-d08bfd959d95"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("c05de278-e58c-44f0-acab-03b34de88ff5"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("e5fdc5b2-ee1b-4d31-9b4b-dda03febf6b2"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("e7232a2b-ff59-4c77-b1b3-853bec44f6bf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("21bd659d-8a93-4b30-acee-ac646b20f7ea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5855f6f6-f435-4dd3-bac4-8e5cf506024d"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnimals",
                table: "UserAnimals",
                columns: new[] { "UserId", "AnimalId" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("0287feff-4fc0-4952-bb93-5bc83156bc9e"), "Cat", false, "Argjävel" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[] { new Guid("030a88e4-925b-450b-b52a-f909331ae632"), "Dog", "Sjöberg" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("1807c69a-84d3-451f-b501-71b0d396d8e6"), "Cat", false, "Fluffig" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[] { new Guid("1a699173-cce9-4027-84b9-757a810ae5e7"), "Dog", "Kenta" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("1a6cb673-b380-46e8-827e-7a13f606479a"), "Cat", false, "LedsenKatt" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[] { new Guid("5206eda5-7498-4c16-8c63-a5c7c0dfd90f"), "Dog", "Berra" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("9cfa300c-6b20-408b-a86b-5f5d05b84177"), "Cat", false, "Simba" });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[] { new Guid("dfeea36b-6c50-4ca0-9a45-ef34acb08a20"), "Dog", "Knugen" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("66bcd304-e665-450a-b5a8-7b4ec74aab07"), "$2a$11$C1xh/TFG5EGkgFLfkg3zdOhBMG1s138wofcio8vAZdnzl7t9vzS9.", "Admin", "admin" },
                    { new Guid("a9925df5-f507-438c-a158-5944b05842c1"), "$2a$11$52tMneAu9QN.a1hCDb21sOus5oziVZtG3mN/JpdmS3g1NFbSd1FTO", "Normal", "user" }
                });
        }
    }
}
