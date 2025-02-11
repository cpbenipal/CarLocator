using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyVehiclecolortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColors", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "VehicleColors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "White" },
                    { 3, "Gray" },
                    { 4, "Silver" },
                    { 5, "Red" },
                    { 6, "Blue" },
                    { 7, "Green" },
                    { 8, "Yellow" },
                    { 9, "Orange" },
                    { 10, "Brown" },
                    { 11, "Gold" },
                    { 12, "Beige" },
                    { 13, "Purple" },
                    { 14, "Pink" },
                    { 15, "Turquoise" }
                });

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

            migrationBuilder.DropTable(
                name: "VehicleColors");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
