using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyVehicleMaketable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 7, 2, 36, 13, 836, DateTimeKind.Local).AddTicks(4025), new DateTime(2025, 2, 7, 2, 36, 13, 836, DateTimeKind.Local).AddTicks(4038) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 7, 2, 36, 13, 836, DateTimeKind.Local).AddTicks(4041), new DateTime(2025, 2, 7, 2, 36, 13, 836, DateTimeKind.Local).AddTicks(4042) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 7, 2, 36, 13, 836, DateTimeKind.Local).AddTicks(5044), new DateTime(2025, 2, 7, 2, 36, 13, 836, DateTimeKind.Local).AddTicks(5049), new DateTime(2025, 2, 7, 2, 36, 13, 836, DateTimeKind.Local).AddTicks(5045), new byte[] { 16, 15, 213, 191, 235, 218, 103, 253, 1, 135, 103, 159, 171, 137, 32, 138, 108, 83, 176, 88, 0, 60, 198, 80, 106, 122, 193, 223, 36, 84, 157, 129, 47, 247, 191, 87, 152, 201, 5, 119, 201, 233, 111, 167, 204, 128, 105, 55, 204, 47, 196, 208, 127, 21, 15, 214, 184, 158, 198, 41, 82, 69, 185, 26, 126, 175, 179, 207, 72, 200, 62, 30, 23, 190, 252, 114, 232, 138, 106, 137, 231, 193, 98, 30, 23, 207, 199, 233, 80, 7, 74, 101, 240, 63, 170, 138, 222, 90, 236, 200, 2, 106, 209, 210, 69, 118, 242, 219, 65, 105, 153, 160, 104, 185, 118, 79, 29, 186, 206, 71, 62, 106, 189, 249, 78, 184, 213, 217 }, new byte[] { 206, 141, 94, 126, 47, 227, 251, 130, 238, 214, 143, 145, 72, 106, 98, 114, 177, 119, 11, 124, 28, 94, 75, 107, 226, 159, 235, 3, 18, 206, 240, 64, 175, 155, 8, 186, 121, 218, 6, 158, 189, 9, 16, 248, 179, 18, 15, 227, 44, 209, 165, 198, 112, 56, 37, 180, 203, 62, 79, 223, 60, 16, 20, 88 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 7, 2, 29, 42, 480, DateTimeKind.Local).AddTicks(6188), new DateTime(2025, 2, 7, 2, 29, 42, 480, DateTimeKind.Local).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 7, 2, 29, 42, 480, DateTimeKind.Local).AddTicks(6203), new DateTime(2025, 2, 7, 2, 29, 42, 480, DateTimeKind.Local).AddTicks(6204) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 7, 2, 29, 42, 481, DateTimeKind.Local).AddTicks(6038), new DateTime(2025, 2, 7, 2, 29, 42, 481, DateTimeKind.Local).AddTicks(6048), new DateTime(2025, 2, 7, 2, 29, 42, 481, DateTimeKind.Local).AddTicks(6046), new byte[] { 235, 21, 184, 42, 63, 197, 132, 124, 211, 41, 35, 11, 32, 212, 36, 76, 58, 62, 107, 126, 89, 88, 15, 1, 104, 124, 118, 108, 111, 9, 232, 3, 156, 179, 61, 13, 6, 181, 219, 76, 24, 146, 152, 120, 238, 70, 255, 97, 96, 15, 10, 194, 158, 6, 127, 166, 154, 154, 122, 74, 97, 144, 105, 251, 61, 73, 151, 174, 38, 189, 84, 110, 163, 202, 49, 73, 199, 44, 85, 14, 170, 59, 204, 92, 36, 88, 42, 44, 128, 68, 67, 230, 129, 2, 121, 126, 28, 45, 171, 203, 12, 140, 147, 139, 30, 116, 174, 162, 93, 9, 210, 120, 39, 14, 137, 120, 66, 208, 159, 37, 202, 229, 33, 118, 233, 226, 138, 220 }, new byte[] { 122, 214, 109, 237, 23, 62, 161, 140, 74, 43, 180, 51, 72, 54, 13, 185, 119, 14, 113, 184, 176, 84, 74, 197, 149, 131, 39, 115, 197, 47, 160, 173, 250, 199, 176, 60, 64, 214, 164, 136, 207, 25, 11, 196, 51, 6, 83, 183, 27, 97, 78, 234, 137, 198, 108, 106, 71, 179, 92, 20, 54, 30, 209, 162 } });
        }
    }
}
