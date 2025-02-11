using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeduplicaseinbiztable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Businesses");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 6, 12, 44, 5, 590, DateTimeKind.Local).AddTicks(3165), new DateTime(2025, 2, 6, 12, 44, 5, 590, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 6, 12, 44, 5, 590, DateTimeKind.Local).AddTicks(3183), new DateTime(2025, 2, 6, 12, 44, 5, 590, DateTimeKind.Local).AddTicks(3184) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 6, 12, 44, 5, 590, DateTimeKind.Local).AddTicks(4284), new DateTime(2025, 2, 6, 12, 44, 5, 590, DateTimeKind.Local).AddTicks(4290), new DateTime(2025, 2, 6, 12, 44, 5, 590, DateTimeKind.Local).AddTicks(4287), new byte[] { 2, 196, 42, 15, 171, 43, 96, 7, 114, 200, 16, 145, 109, 83, 58, 33, 26, 82, 8, 84, 29, 174, 38, 189, 97, 224, 252, 83, 200, 8, 46, 142, 95, 5, 217, 117, 174, 187, 17, 130, 226, 233, 129, 225, 110, 189, 58, 16, 243, 227, 121, 136, 54, 193, 147, 103, 233, 17, 206, 188, 40, 69, 72, 16, 186, 125, 175, 69, 113, 148, 47, 108, 120, 57, 226, 167, 78, 210, 118, 85, 215, 214, 206, 251, 19, 212, 244, 195, 227, 156, 189, 37, 5, 228, 222, 10, 176, 107, 60, 221, 86, 255, 48, 37, 131, 147, 159, 154, 160, 239, 221, 73, 70, 60, 223, 74, 185, 78, 131, 221, 118, 255, 79, 207, 2, 96, 92, 249 }, new byte[] { 85, 55, 91, 105, 6, 189, 194, 107, 81, 79, 189, 116, 180, 235, 39, 5, 63, 222, 30, 184, 184, 63, 234, 177, 186, 191, 205, 202, 127, 84, 212, 203, 185, 81, 123, 11, 153, 110, 211, 28, 30, 226, 218, 182, 180, 135, 153, 202, 186, 62, 102, 133, 223, 35, 2, 122, 9, 23, 126, 184, 29, 49, 19, 186 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 6, 12, 36, 41, 58, DateTimeKind.Local).AddTicks(3669), new DateTime(2025, 2, 6, 12, 36, 41, 58, DateTimeKind.Local).AddTicks(3681), new DateTime(2025, 2, 6, 12, 36, 41, 58, DateTimeKind.Local).AddTicks(3679), new byte[] { 23, 149, 47, 251, 185, 187, 69, 49, 87, 169, 89, 205, 101, 130, 81, 140, 202, 62, 141, 189, 195, 208, 34, 215, 247, 68, 118, 213, 44, 216, 29, 9, 116, 116, 152, 13, 83, 114, 45, 144, 45, 210, 235, 170, 5, 245, 48, 154, 74, 69, 128, 32, 212, 182, 162, 229, 126, 190, 220, 113, 124, 188, 143, 175, 181, 220, 200, 116, 223, 205, 234, 103, 8, 133, 187, 136, 147, 16, 25, 37, 177, 31, 206, 158, 196, 104, 147, 38, 172, 234, 37, 221, 63, 197, 92, 251, 115, 124, 28, 209, 66, 127, 16, 154, 216, 188, 214, 117, 106, 26, 244, 234, 145, 94, 30, 140, 131, 110, 141, 150, 165, 154, 162, 248, 209, 48, 60, 12 }, new byte[] { 101, 123, 108, 231, 118, 187, 164, 204, 115, 192, 50, 94, 169, 114, 111, 185, 68, 229, 191, 125, 39, 239, 137, 88, 239, 191, 29, 155, 215, 8, 241, 153, 168, 91, 36, 201, 212, 164, 120, 45, 46, 39, 50, 236, 221, 152, 106, 215, 211, 113, 185, 23, 165, 135, 2, 236, 240, 161, 243, 201, 230, 72, 106, 241 } });
        }
    }
}
