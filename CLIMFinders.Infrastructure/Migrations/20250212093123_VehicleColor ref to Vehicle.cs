using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VehicleColorreftoVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 12, 15, 1, 23, 144, DateTimeKind.Local).AddTicks(2721), new DateTime(2025, 2, 12, 15, 1, 23, 144, DateTimeKind.Local).AddTicks(2734) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 12, 15, 1, 23, 144, DateTimeKind.Local).AddTicks(2737), new DateTime(2025, 2, 12, 15, 1, 23, 144, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 12, 15, 1, 23, 144, DateTimeKind.Local).AddTicks(3785), new DateTime(2025, 2, 12, 15, 1, 23, 144, DateTimeKind.Local).AddTicks(3789), new DateTime(2025, 2, 12, 15, 1, 23, 144, DateTimeKind.Local).AddTicks(3786), new byte[] { 28, 175, 105, 236, 37, 188, 192, 237, 28, 119, 135, 18, 176, 236, 92, 76, 68, 148, 119, 166, 199, 215, 235, 210, 104, 151, 224, 146, 83, 247, 90, 216, 254, 158, 25, 225, 131, 227, 197, 232, 233, 133, 90, 159, 185, 249, 224, 118, 121, 113, 205, 43, 183, 108, 220, 67, 42, 5, 221, 190, 11, 245, 124, 240, 179, 213, 115, 105, 202, 11, 99, 107, 191, 217, 214, 143, 5, 93, 239, 234, 151, 121, 9, 242, 215, 234, 189, 125, 85, 67, 137, 70, 243, 189, 8, 119, 118, 42, 42, 219, 205, 123, 242, 4, 29, 180, 93, 103, 20, 0, 53, 152, 118, 239, 45, 21, 216, 14, 41, 239, 5, 73, 29, 58, 227, 177, 253, 144 }, new byte[] { 224, 123, 183, 47, 137, 172, 238, 85, 34, 196, 127, 134, 167, 111, 143, 118, 96, 126, 114, 42, 82, 152, 17, 91, 196, 25, 6, 48, 10, 198, 245, 6, 57, 53, 50, 47, 28, 108, 101, 72, 209, 41, 59, 172, 56, 95, 6, 27, 230, 107, 208, 151, 124, 33, 89, 187, 84, 175, 28, 157, 75, 124, 201, 229 } });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleColors_ColorId",
                table: "Vehicles",
                column: "ColorId",
                principalTable: "VehicleColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleColors_ColorId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles");

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
        }
    }
}
