using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDbmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    animalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.animalID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => new { x.UserId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_UserAnimals_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "animalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("04588cbf-102e-4ac4-9dce-2cadb6085def"), "Dog", "Kenta" },
                    { new Guid("12345678-1234-5678-1234-567812345671"), "Dog", "DogTest1" },
                    { new Guid("12345678-1234-5678-1234-567812345672"), "Dog", "DogTest2" },
                    { new Guid("12345678-1234-5678-1234-567812345673"), "Dog", "DogTest3" },
                    { new Guid("12345678-1234-5678-1234-567812345674"), "Dog", "DogTest4" },
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

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_AnimalId",
                table: "UserAnimals",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
