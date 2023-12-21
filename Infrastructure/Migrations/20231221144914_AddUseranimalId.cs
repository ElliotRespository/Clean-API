using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUseranimalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("04588cbf-102e-4ac4-9dce-2cadb6085def"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("1cf91ef3-710a-4370-bb4c-0965f6407159"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("50eac6ac-14fe-447d-abeb-b30969cf3b15"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("8045ef54-6a45-4a7c-bbee-64d075b4738a"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("ae0ad98b-db69-446b-ae1b-61c3132c9213"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("d1164c2a-f987-4566-9c0b-3aec2e80fde4"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("d294bf91-7167-4726-95c2-7911c66d34f4"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "animalID",
                keyValue: new Guid("e3d8734f-031e-4d23-81e6-70b17c762508"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3bccd9fa-e28d-4304-91c4-65621bc0d37e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e64420c-a8f2-4a2a-a467-f3b87eaf6360"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserAnimalId",
                table: "UserAnimals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "UserAnimalId",
                table: "UserAnimals");

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("04588cbf-102e-4ac4-9dce-2cadb6085def"), "Dog", "Kenta" },
                    { new Guid("1cf91ef3-710a-4370-bb4c-0965f6407159"), "Dog", "Knugen" },
                    { new Guid("50eac6ac-14fe-447d-abeb-b30969cf3b15"), "Dog", "Berra" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("8045ef54-6a45-4a7c-bbee-64d075b4738a"), "Cat", false, "Fluffig" },
                    { new Guid("ae0ad98b-db69-446b-ae1b-61c3132c9213"), "Cat", false, "LedsenKatt" },
                    { new Guid("d1164c2a-f987-4566-9c0b-3aec2e80fde4"), "Cat", false, "Argjävel" },
                    { new Guid("d294bf91-7167-4726-95c2-7911c66d34f4"), "Cat", false, "Simba" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[] { new Guid("e3d8734f-031e-4d23-81e6-70b17c762508"), "Dog", "Sjöberg" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("3bccd9fa-e28d-4304-91c4-65621bc0d37e"), "$2a$11$6l9UEGVjmUxLx6tH.On/TOBY.oki9GIxAIg3TzMM/GS9swrcUBwvm", "Normal", "user" },
                    { new Guid("9e64420c-a8f2-4a2a-a467-f3b87eaf6360"), "$2a$11$f.6FfsZZNIQh6WvmCX.fteVQknmL3DYW5zfDN2e35/wfQOEkjYsaC", "Admin", "admin" }
                });
        }
    }
}
