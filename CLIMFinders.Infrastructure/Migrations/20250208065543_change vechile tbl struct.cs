using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changevechiletblstruct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 8, 12, 25, 42, 911, DateTimeKind.Local).AddTicks(2858), new DateTime(2025, 2, 8, 12, 25, 42, 911, DateTimeKind.Local).AddTicks(2874) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 8, 12, 25, 42, 911, DateTimeKind.Local).AddTicks(2877), new DateTime(2025, 2, 8, 12, 25, 42, 911, DateTimeKind.Local).AddTicks(2877) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 8, 12, 25, 42, 911, DateTimeKind.Local).AddTicks(3972), new DateTime(2025, 2, 8, 12, 25, 42, 911, DateTimeKind.Local).AddTicks(3977), new DateTime(2025, 2, 8, 12, 25, 42, 911, DateTimeKind.Local).AddTicks(3974), new byte[] { 78, 175, 165, 82, 128, 227, 210, 20, 132, 137, 62, 128, 4, 180, 42, 104, 104, 80, 71, 12, 53, 253, 204, 145, 16, 162, 153, 66, 190, 75, 128, 184, 200, 135, 186, 248, 224, 13, 98, 103, 32, 158, 178, 251, 26, 183, 59, 237, 138, 215, 96, 67, 244, 103, 55, 186, 230, 153, 17, 7, 4, 115, 125, 0, 195, 212, 36, 240, 225, 132, 111, 228, 152, 235, 57, 236, 253, 17, 245, 143, 219, 185, 61, 17, 141, 231, 66, 29, 250, 17, 101, 215, 197, 34, 187, 138, 207, 134, 12, 221, 130, 14, 237, 225, 224, 226, 162, 211, 255, 46, 37, 162, 143, 178, 201, 146, 233, 94, 143, 62, 212, 246, 124, 34, 222, 40, 179, 136 }, new byte[] { 156, 76, 71, 67, 96, 150, 130, 48, 193, 2, 175, 27, 175, 72, 91, 255, 245, 251, 137, 55, 230, 143, 132, 181, 86, 214, 226, 129, 55, 79, 208, 242, 62, 181, 227, 47, 218, 14, 69, 192, 203, 3, 55, 247, 174, 96, 119, 107, 67, 79, 135, 119, 137, 222, 143, 113, 30, 88, 166, 228, 198, 163, 146, 101 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickedOn",
                table: "Vehicles");

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
                values: new object[] { new DateTime(2025, 2, 7, 3, 15, 34, 303, DateTimeKind.Local).AddTicks(7356), new DateTime(2025, 2, 7, 3, 15, 34, 303, DateTimeKind.Local).AddTicks(7373) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 7, 3, 15, 34, 303, DateTimeKind.Local).AddTicks(7376), new DateTime(2025, 2, 7, 3, 15, 34, 303, DateTimeKind.Local).AddTicks(7377) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 7, 3, 15, 34, 303, DateTimeKind.Local).AddTicks(8388), new DateTime(2025, 2, 7, 3, 15, 34, 303, DateTimeKind.Local).AddTicks(8392), new DateTime(2025, 2, 7, 3, 15, 34, 303, DateTimeKind.Local).AddTicks(8389), new byte[] { 239, 170, 80, 166, 166, 113, 58, 196, 118, 35, 169, 32, 58, 45, 18, 116, 219, 205, 45, 199, 104, 63, 53, 93, 121, 122, 108, 240, 140, 233, 252, 185, 2, 221, 11, 107, 16, 125, 241, 13, 225, 225, 16, 103, 82, 77, 4, 24, 123, 192, 41, 153, 103, 125, 64, 129, 195, 54, 21, 186, 48, 83, 242, 10, 174, 96, 60, 13, 94, 199, 129, 248, 35, 238, 154, 117, 220, 117, 61, 17, 95, 75, 220, 122, 213, 49, 30, 43, 177, 200, 176, 204, 157, 103, 249, 43, 185, 138, 198, 120, 15, 191, 79, 13, 236, 166, 199, 253, 56, 75, 169, 12, 156, 98, 252, 36, 195, 142, 249, 220, 40, 52, 115, 170, 80, 21, 109, 120 }, new byte[] { 63, 140, 203, 142, 49, 90, 109, 127, 166, 96, 124, 49, 116, 92, 22, 228, 13, 238, 3, 93, 134, 108, 59, 230, 23, 72, 30, 228, 211, 249, 45, 153, 37, 85, 243, 116, 94, 47, 188, 227, 119, 30, 167, 101, 13, 207, 224, 19, 245, 252, 41, 61, 161, 11, 132, 112, 193, 115, 80, 237, 105, 153, 42, 236 } });
        }
    }
}
