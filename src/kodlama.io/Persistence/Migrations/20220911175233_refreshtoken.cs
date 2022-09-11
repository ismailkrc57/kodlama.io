using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class refreshtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "RefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 98, 21, 130, 144, 177, 168, 63, 187, 108, 45, 184, 53, 161, 229, 91, 14, 23, 88, 161, 98, 11, 206, 106, 158, 251, 210, 50, 78, 8, 42, 215, 237, 49, 214, 159, 80, 52, 120, 210, 122, 146, 10, 214, 95, 137, 211, 20, 164, 19, 114, 142, 99, 108, 244, 162, 238, 180, 235, 164, 52, 130, 45, 197, 239 }, new byte[] { 227, 126, 99, 197, 73, 122, 27, 197, 228, 184, 6, 136, 143, 68, 39, 171, 87, 145, 55, 4, 85, 14, 57, 126, 64, 78, 226, 84, 150, 204, 222, 140, 21, 53, 30, 195, 128, 159, 110, 51, 243, 10, 224, 32, 122, 241, 121, 132, 152, 62, 147, 122, 248, 72, 37, 182, 139, 198, 59, 109, 113, 76, 223, 141, 230, 106, 63, 65, 148, 78, 134, 36, 156, 216, 167, 17, 79, 20, 117, 43, 60, 189, 128, 105, 119, 126, 1, 44, 137, 171, 19, 215, 235, 211, 94, 125, 29, 251, 28, 15, 107, 250, 185, 58, 212, 23, 75, 44, 198, 82, 55, 246, 248, 226, 188, 88, 238, 165, 120, 49, 193, 148, 26, 218, 217, 162, 122, 59 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 98, 21, 130, 144, 177, 168, 63, 187, 108, 45, 184, 53, 161, 229, 91, 14, 23, 88, 161, 98, 11, 206, 106, 158, 251, 210, 50, 78, 8, 42, 215, 237, 49, 214, 159, 80, 52, 120, 210, 122, 146, 10, 214, 95, 137, 211, 20, 164, 19, 114, 142, 99, 108, 244, 162, 238, 180, 235, 164, 52, 130, 45, 197, 239 }, new byte[] { 227, 126, 99, 197, 73, 122, 27, 197, 228, 184, 6, 136, 143, 68, 39, 171, 87, 145, 55, 4, 85, 14, 57, 126, 64, 78, 226, 84, 150, 204, 222, 140, 21, 53, 30, 195, 128, 159, 110, 51, 243, 10, 224, 32, 122, 241, 121, 132, 152, 62, 147, 122, 248, 72, 37, 182, 139, 198, 59, 109, 113, 76, 223, 141, 230, 106, 63, 65, 148, 78, 134, 36, 156, 216, 167, 17, 79, 20, 117, 43, 60, 189, 128, 105, 119, 126, 1, 44, 137, 171, 19, 215, 235, 211, 94, 125, 29, 251, 28, 15, 107, 250, 185, 58, 212, 23, 75, 44, 198, 82, 55, 246, 248, 226, 188, 88, 238, 165, 120, 49, 193, 148, 26, 218, 217, 162, 122, 59 } });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "RefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 22, 246, 168, 183, 197, 213, 139, 126, 58, 4, 55, 21, 13, 234, 253, 31, 135, 35, 200, 160, 172, 203, 20, 188, 190, 130, 223, 186, 205, 135, 222, 127, 135, 66, 133, 253, 25, 146, 203, 8, 135, 4, 139, 175, 73, 53, 237, 183, 216, 145, 211, 189, 234, 0, 140, 160, 142, 160, 135, 74, 105, 17, 64 }, new byte[] { 56, 30, 115, 77, 83, 2, 89, 35, 219, 74, 84, 66, 233, 6, 82, 190, 193, 200, 44, 78, 160, 208, 186, 165, 175, 50, 192, 134, 92, 151, 145, 157, 58, 150, 214, 143, 205, 131, 106, 205, 105, 111, 196, 148, 42, 50, 127, 123, 153, 195, 215, 49, 103, 112, 81, 182, 162, 228, 239, 24, 0, 73, 116, 189, 137, 169, 79, 62, 99, 38, 18, 44, 97, 62, 26, 206, 17, 68, 91, 158, 210, 24, 239, 248, 147, 57, 79, 208, 250, 112, 115, 156, 158, 247, 207, 20, 146, 25, 197, 26, 180, 132, 24, 17, 56, 65, 177, 88, 94, 45, 97, 249, 95, 222, 52, 163, 243, 110, 237, 40, 136, 128, 3, 201, 103, 27, 24, 130 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 22, 246, 168, 183, 197, 213, 139, 126, 58, 4, 55, 21, 13, 234, 253, 31, 135, 35, 200, 160, 172, 203, 20, 188, 190, 130, 223, 186, 205, 135, 222, 127, 135, 66, 133, 253, 25, 146, 203, 8, 135, 4, 139, 175, 73, 53, 237, 183, 216, 145, 211, 189, 234, 0, 140, 160, 142, 160, 135, 74, 105, 17, 64 }, new byte[] { 56, 30, 115, 77, 83, 2, 89, 35, 219, 74, 84, 66, 233, 6, 82, 190, 193, 200, 44, 78, 160, 208, 186, 165, 175, 50, 192, 134, 92, 151, 145, 157, 58, 150, 214, 143, 205, 131, 106, 205, 105, 111, 196, 148, 42, 50, 127, 123, 153, 195, 215, 49, 103, 112, 81, 182, 162, 228, 239, 24, 0, 73, 116, 189, 137, 169, 79, 62, 99, 38, 18, 44, 97, 62, 26, 206, 17, 68, 91, 158, 210, 24, 239, 248, 147, 57, 79, 208, 250, 112, 115, 156, 158, 247, 207, 20, 146, 25, 197, 26, 180, 132, 24, 17, 56, 65, 177, 88, 94, 45, 97, 249, 95, 222, 52, 163, 243, 110, 237, 40, 136, 128, 3, 201, 103, 27, 24, 130 } });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
