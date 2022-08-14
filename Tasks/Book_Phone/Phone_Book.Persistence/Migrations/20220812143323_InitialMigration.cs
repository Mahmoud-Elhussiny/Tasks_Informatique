using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phone_Book.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phone_Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone_Number",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phones_BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone_Number", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Number_Phone_Books_Phones_BookId",
                        column: x => x.Phones_BookId,
                        principalTable: "Phone_Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { new Guid("6b305129-ac8a-4a31-9107-ecb8c2c3dc2d"), "Mahmoud", "Hussein", "987654321", "hussein98" });

            migrationBuilder.InsertData(
                table: "Phone_Books",
                columns: new[] { "Id", "Address", "Name", "UserId" },
                values: new object[] { new Guid("5ccdaab9-8b91-42b0-aede-51d42810d2d8"), "assiut", "Ali", new Guid("6b305129-ac8a-4a31-9107-ecb8c2c3dc2d") });

            migrationBuilder.InsertData(
                table: "Phone_Number",
                columns: new[] { "Id", "Number", "Phones_BookId" },
                values: new object[] { new Guid("eab8db3e-5749-4dc5-a877-312216df4c6b"), "01065232323", new Guid("5ccdaab9-8b91-42b0-aede-51d42810d2d8") });

            migrationBuilder.InsertData(
                table: "Phone_Number",
                columns: new[] { "Id", "Number", "Phones_BookId" },
                values: new object[] { new Guid("eab8db99-5749-4dc5-a877-312216df4c6b"), "01065232323", new Guid("5ccdaab9-8b91-42b0-aede-51d42810d2d8") });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_Books_UserId",
                table: "Phone_Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_Number_Phones_BookId",
                table: "Phone_Number",
                column: "Phones_BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phone_Number");

            migrationBuilder.DropTable(
                name: "Phone_Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
