using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newdbwithmanytomany : Migration
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
                    { new Guid("02ae31e5-db39-4223-ae00-0fd407126c20"), "Dog", "Kenta" },
                    { new Guid("02af390f-9fe3-4e87-8009-8cb222d747b7"), "Dog", "Berra" },
                    { new Guid("12345678-1234-5678-1234-567812345671"), "Dog", "DogTest1" },
                    { new Guid("12345678-1234-5678-1234-567812345672"), "Dog", "DogTest2" },
                    { new Guid("12345678-1234-5678-1234-567812345673"), "Dog", "DogTest3" },
                    { new Guid("12345678-1234-5678-1234-567812345674"), "Dog", "DogTest4" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("37166ea3-fa1d-44f5-9daf-690515506bc5"), "Cat", false, "Simba" },
                    { new Guid("72da4950-5c22-4ccd-930e-f52f47a56c90"), "Cat", false, "Fluffig" },
                    { new Guid("8a83a254-f33b-4cb5-90f9-b28e3eb71dd3"), "Cat", false, "Argjävel" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("9175b0af-a242-41c8-ab3d-1be9153b9db3"), "Dog", "Knugen" },
                    { new Guid("ef978b71-3d71-420c-86a3-507ce0a9e3ce"), "Dog", "Sjöberg" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "animalID", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("fdb85896-a9f4-440d-9b79-2e8e1fb94bd7"), "Cat", false, "LedsenKatt" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("7724643a-88ad-412a-942f-104f44e966df"), "$2a$11$4CrndVSz87CzmfQX8MYWZuJYf1wgX3yB3a8Ot.1Sc8HckCQxP7WaW", "Admin", "admin" },
                    { new Guid("e77426c2-0789-4fd4-967d-978e1cf1ed4a"), "$2a$11$kT.jpWNvyeIC/lMQVeBvi.CSrXzsLEdIwKyWu.7Bm4WhljSHjO0XC", "Normal", "user" }
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
