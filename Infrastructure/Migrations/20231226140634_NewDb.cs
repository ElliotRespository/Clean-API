using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalID);
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
                    UserAnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => x.UserAnimalId);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalID",
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
                columns: new[] { "AnimalID", "Breed", "Color", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("0c4e6e32-0773-4b10-877e-0955afa5b110"), null, null, "Cat", false, "LedsenKatt", 0 },
                    { new Guid("0ffc0988-8dfb-433f-b5dc-44b140230976"), null, null, "Cat", false, "Simba", 0 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalID", "Breed", "Color", "Discriminator", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345671"), null, null, "Dog", "DogTest1", 0 },
                    { new Guid("12345678-1234-5678-1234-567812345672"), null, null, "Dog", "DogTest2", 0 },
                    { new Guid("12345678-1234-5678-1234-567812345673"), null, null, "Dog", "DogTest3", 0 },
                    { new Guid("12345678-1234-5678-1234-567812345674"), null, null, "Dog", "DogTest4", 0 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalID", "Breed", "Color", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("27b5f033-1709-4d2b-bf9d-bca1acf20b9a"), null, null, "Cat", false, "Argjävel", 0 },
                    { new Guid("472b8d1b-e558-48ab-a8a4-a2a2f5d32f81"), null, null, "Cat", false, "Fluffig", 0 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalID", "Breed", "Color", "Discriminator", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("7164111f-9594-446b-8276-8e06054a56be"), null, null, "Dog", "Kenta", 0 },
                    { new Guid("a5d9c37c-2487-4368-a044-02aea47f0be5"), null, null, "Dog", "Berra", 0 },
                    { new Guid("bfd1f6dc-bb27-43bc-abc3-cd94e03cf1e6"), null, null, "Dog", "Knugen", 0 },
                    { new Guid("bffe3342-bf51-48cc-a5b6-a8a8cd9653be"), null, null, "Dog", "Sjöberg", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("bc2026d5-2b92-4d98-b3df-47793e851bf8"), "$2a$11$wf8/M5gi2nCDr/0uwcIWFedJU2xlHVvO07J2cdSGq4Xmw0j5WBUUq", "Normal", "user" },
                    { new Guid("cf9e669e-cdbd-4356-8c0d-63554904b139"), "$2a$11$/BmTucWkJ4.XrdRbWoAOh.T2GVBwGzEtBW2Y3un0F/5yEpcvawYtK", "Admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_AnimalId",
                table: "UserAnimals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_UserId",
                table: "UserAnimals",
                column: "UserId");
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
