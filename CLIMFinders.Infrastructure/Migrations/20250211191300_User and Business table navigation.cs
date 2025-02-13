using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserandBusinesstablenavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 12, 0, 43, 0, 350, DateTimeKind.Local).AddTicks(2645), new DateTime(2025, 2, 12, 0, 43, 0, 350, DateTimeKind.Local).AddTicks(2660) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 12, 0, 43, 0, 350, DateTimeKind.Local).AddTicks(2663), new DateTime(2025, 2, 12, 0, 43, 0, 350, DateTimeKind.Local).AddTicks(2663) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 12, 0, 43, 0, 350, DateTimeKind.Local).AddTicks(7632), new DateTime(2025, 2, 12, 0, 43, 0, 350, DateTimeKind.Local).AddTicks(7641), new DateTime(2025, 2, 12, 0, 43, 0, 350, DateTimeKind.Local).AddTicks(7638), new byte[] { 145, 71, 163, 111, 162, 218, 166, 20, 178, 116, 24, 145, 31, 225, 101, 108, 124, 128, 175, 166, 130, 170, 22, 178, 227, 110, 177, 251, 126, 222, 220, 93, 233, 212, 190, 255, 206, 117, 189, 17, 72, 62, 187, 83, 180, 163, 95, 27, 53, 147, 114, 142, 5, 179, 77, 50, 113, 93, 118, 187, 114, 71, 133, 229, 16, 105, 97, 90, 26, 29, 90, 252, 55, 79, 98, 168, 13, 93, 68, 93, 35, 130, 117, 26, 78, 155, 135, 117, 252, 57, 83, 64, 249, 101, 81, 52, 66, 2, 99, 242, 114, 104, 94, 223, 193, 252, 174, 217, 16, 122, 93, 202, 72, 180, 27, 216, 46, 113, 23, 212, 112, 149, 173, 83, 47, 162, 60, 109 }, new byte[] { 102, 66, 188, 109, 63, 203, 87, 58, 75, 100, 72, 140, 131, 113, 133, 103, 222, 245, 244, 34, 181, 239, 202, 201, 125, 253, 179, 208, 29, 72, 50, 117, 233, 138, 113, 11, 42, 46, 132, 84, 232, 57, 12, 112, 76, 213, 29, 85, 132, 236, 221, 196, 72, 205, 215, 201, 22, 235, 75, 36, 110, 151, 52, 123 } });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 9, 13, 52, 37, 281, DateTimeKind.Local).AddTicks(4863), new DateTime(2025, 2, 9, 13, 52, 37, 281, DateTimeKind.Local).AddTicks(4876) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 9, 13, 52, 37, 281, DateTimeKind.Local).AddTicks(4879), new DateTime(2025, 2, 9, 13, 52, 37, 281, DateTimeKind.Local).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 9, 13, 52, 37, 281, DateTimeKind.Local).AddTicks(5944), new DateTime(2025, 2, 9, 13, 52, 37, 281, DateTimeKind.Local).AddTicks(5949), new DateTime(2025, 2, 9, 13, 52, 37, 281, DateTimeKind.Local).AddTicks(5947), new byte[] { 179, 151, 254, 60, 117, 180, 141, 225, 186, 242, 115, 59, 253, 111, 226, 159, 198, 68, 93, 150, 248, 1, 118, 254, 126, 236, 181, 222, 32, 197, 235, 189, 11, 194, 234, 225, 205, 120, 40, 36, 118, 179, 5, 164, 61, 140, 200, 31, 156, 190, 148, 32, 21, 28, 202, 1, 236, 25, 131, 82, 136, 162, 252, 1, 7, 115, 201, 49, 224, 159, 232, 179, 210, 210, 208, 81, 86, 244, 174, 4, 117, 8, 169, 4, 200, 20, 121, 89, 218, 99, 154, 151, 26, 21, 21, 208, 219, 44, 76, 31, 0, 22, 24, 89, 149, 87, 89, 39, 211, 162, 117, 148, 99, 74, 69, 122, 158, 116, 77, 100, 255, 194, 16, 125, 1, 77, 11, 184 }, new byte[] { 159, 2, 167, 254, 55, 233, 244, 232, 76, 83, 18, 28, 25, 79, 175, 247, 225, 6, 52, 212, 160, 207, 180, 158, 15, 177, 156, 142, 41, 85, 175, 67, 168, 141, 181, 145, 162, 138, 94, 134, 5, 207, 110, 137, 208, 157, 62, 233, 25, 134, 29, 141, 199, 222, 145, 147, 133, 17, 21, 146, 24, 44, 241, 251 } });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses",
                column: "UserId");
        }
    }
}
