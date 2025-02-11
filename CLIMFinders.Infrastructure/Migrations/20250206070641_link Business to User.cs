using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class linkBusinesstoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Businesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 6, 12, 36, 41, 57, DateTimeKind.Local).AddTicks(8092), new DateTime(2025, 2, 6, 12, 36, 41, 57, DateTimeKind.Local).AddTicks(8108) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 6, 12, 36, 41, 57, DateTimeKind.Local).AddTicks(8114), new DateTime(2025, 2, 6, 12, 36, 41, 57, DateTimeKind.Local).AddTicks(8114) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "Password", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 6, 12, 36, 41, 58, DateTimeKind.Local).AddTicks(3669), new DateTime(2025, 2, 6, 12, 36, 41, 58, DateTimeKind.Local).AddTicks(3681), new DateTime(2025, 2, 6, 12, 36, 41, 58, DateTimeKind.Local).AddTicks(3679), "MDAwMA==", new byte[] { 23, 149, 47, 251, 185, 187, 69, 49, 87, 169, 89, 205, 101, 130, 81, 140, 202, 62, 141, 189, 195, 208, 34, 215, 247, 68, 118, 213, 44, 216, 29, 9, 116, 116, 152, 13, 83, 114, 45, 144, 45, 210, 235, 170, 5, 245, 48, 154, 74, 69, 128, 32, 212, 182, 162, 229, 126, 190, 220, 113, 124, 188, 143, 175, 181, 220, 200, 116, 223, 205, 234, 103, 8, 133, 187, 136, 147, 16, 25, 37, 177, 31, 206, 158, 196, 104, 147, 38, 172, 234, 37, 221, 63, 197, 92, 251, 115, 124, 28, 209, 66, 127, 16, 154, 216, 188, 214, 117, 106, 26, 244, 234, 145, 94, 30, 140, 131, 110, 141, 150, 165, 154, 162, 248, 209, 48, 60, 12 }, new byte[] { 101, 123, 108, 231, 118, 187, 164, 204, 115, 192, 50, 94, 169, 114, 111, 185, 68, 229, 191, 125, 39, 239, 137, 88, 239, 191, 29, 155, 215, 8, 241, 153, 168, 91, 36, 201, 212, 164, 120, 45, 46, 39, 50, 236, 221, 152, 106, 215, 211, 113, 185, 23, 165, 135, 2, 236, 240, 161, 243, 201, 230, 72, 106, 241 } });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_UserId",
                table: "Businesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Users_UserId",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Businesses");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 4, 16, 28, 27, 506, DateTimeKind.Local).AddTicks(2074), new DateTime(2025, 2, 4, 16, 28, 27, 506, DateTimeKind.Local).AddTicks(2086) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 4, 16, 28, 27, 506, DateTimeKind.Local).AddTicks(2089), new DateTime(2025, 2, 4, 16, 28, 27, 506, DateTimeKind.Local).AddTicks(2089) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "Password", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 4, 16, 28, 27, 506, DateTimeKind.Local).AddTicks(9917), new DateTime(2025, 2, 4, 16, 28, 27, 506, DateTimeKind.Local).AddTicks(9926), new DateTime(2025, 2, 4, 16, 28, 27, 506, DateTimeKind.Local).AddTicks(9923), "123456", new byte[] { 67, 122, 143, 30, 42, 158, 105, 247, 69, 71, 5, 196, 1, 22, 33, 229, 105, 251, 180, 157, 138, 191, 222, 45, 225, 44, 20, 251, 52, 212, 166, 1, 20, 47, 81, 208, 232, 196, 73, 186, 237, 24, 47, 121, 37, 146, 2, 163, 150, 107, 163, 136, 168, 188, 253, 50, 52, 59, 90, 232, 246, 103, 145, 139, 239, 240, 43, 110, 19, 157, 127, 17, 178, 96, 6, 17, 37, 44, 21, 66, 203, 175, 126, 234, 235, 69, 218, 63, 63, 196, 143, 91, 117, 87, 19, 21, 42, 212, 218, 174, 52, 157, 252, 251, 26, 114, 232, 50, 12, 208, 142, 144, 95, 134, 89, 81, 199, 217, 59, 178, 233, 68, 188, 64, 164, 144, 22, 232 }, new byte[] { 123, 214, 218, 136, 62, 31, 45, 55, 91, 81, 19, 127, 38, 236, 123, 81, 235, 243, 187, 95, 119, 87, 149, 59, 117, 164, 156, 241, 6, 105, 218, 161, 48, 66, 183, 53, 81, 171, 197, 50, 141, 148, 118, 101, 157, 132, 231, 82, 127, 22, 92, 231, 11, 149, 51, 126, 128, 110, 250, 93, 218, 91, 231, 22 } });
        }
    }
}
