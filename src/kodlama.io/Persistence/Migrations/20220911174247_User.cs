using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GithubAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GithubAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => new { x.UserId, x.OperationClaimId });
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[,]
                {
                    { 1, 0, "", "Admin", "Admin", new byte[] { 230, 22, 246, 168, 183, 197, 213, 139, 126, 58, 4, 55, 21, 13, 234, 253, 31, 135, 35, 200, 160, 172, 203, 20, 188, 190, 130, 223, 186, 205, 135, 222, 127, 135, 66, 133, 253, 25, 146, 203, 8, 135, 4, 139, 175, 73, 53, 237, 183, 216, 145, 211, 189, 234, 0, 140, 160, 142, 160, 135, 74, 105, 17, 64 }, new byte[] { 56, 30, 115, 77, 83, 2, 89, 35, 219, 74, 84, 66, 233, 6, 82, 190, 193, 200, 44, 78, 160, 208, 186, 165, 175, 50, 192, 134, 92, 151, 145, 157, 58, 150, 214, 143, 205, 131, 106, 205, 105, 111, 196, 148, 42, 50, 127, 123, 153, 195, 215, 49, 103, 112, 81, 182, 162, 228, 239, 24, 0, 73, 116, 189, 137, 169, 79, 62, 99, 38, 18, 44, 97, 62, 26, 206, 17, 68, 91, 158, 210, 24, 239, 248, 147, 57, 79, 208, 250, 112, 115, 156, 158, 247, 207, 20, 146, 25, 197, 26, 180, 132, 24, 17, 56, 65, 177, 88, 94, 45, 97, 249, 95, 222, 52, 163, 243, 110, 237, 40, 136, 128, 3, 201, 103, 27, 24, 130 }, true },
                    { 2, 0, "", "User", "User", new byte[] { 230, 22, 246, 168, 183, 197, 213, 139, 126, 58, 4, 55, 21, 13, 234, 253, 31, 135, 35, 200, 160, 172, 203, 20, 188, 190, 130, 223, 186, 205, 135, 222, 127, 135, 66, 133, 253, 25, 146, 203, 8, 135, 4, 139, 175, 73, 53, 237, 183, 216, 145, 211, 189, 234, 0, 140, 160, 142, 160, 135, 74, 105, 17, 64 }, new byte[] { 56, 30, 115, 77, 83, 2, 89, 35, 219, 74, 84, 66, 233, 6, 82, 190, 193, 200, 44, 78, 160, 208, 186, 165, 175, 50, 192, 134, 92, 151, 145, 157, 58, 150, 214, 143, 205, 131, 106, 205, 105, 111, 196, 148, 42, 50, 127, 123, 153, 195, 215, 49, 103, 112, 81, 182, 162, 228, 239, 24, 0, 73, 116, 189, 137, 169, 79, 62, 99, 38, 18, 44, 97, 62, 26, 206, 17, 68, 91, 158, 210, 24, 239, 248, 147, 57, 79, 208, 250, 112, 115, 156, 158, 247, 207, 20, 146, 25, 197, 26, 180, 132, 24, 17, 56, 65, 177, 88, 94, 45, 97, 249, 95, 222, 52, 163, 243, 110, 237, 40, 136, 128, 3, 201, 103, 27, 24, 130 }, true }
                });

            migrationBuilder.InsertData(
                table: "GithubAccounts",
                columns: new[] { "Id", "Url", "UserId", "Username" },
                values: new object[,]
                {
                    { 1, "", 1, "admin" },
                    { 2, "", 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "OperationClaimId", "UserId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GithubAccounts_UserId",
                table: "GithubAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GithubAccounts");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
