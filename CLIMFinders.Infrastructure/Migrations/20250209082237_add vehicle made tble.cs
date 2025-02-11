using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addvehiclemadetble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleColors_ColorId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleMakes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "VehicleMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "MakeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "MDX" },
                    { 2, 1, "RDX" },
                    { 3, 1, "TLX" },
                    { 4, 2, "Giulia" },
                    { 5, 2, "Stelvio" },
                    { 6, 3, "DB11" },
                    { 7, 3, "Vantage" },
                    { 8, 4, "A3" },
                    { 9, 4, "A4" },
                    { 10, 4, "Q5" },
                    { 11, 4, "Q7" },
                    { 12, 5, "Continental GT" },
                    { 13, 5, "Bentayga" },
                    { 14, 6, "3 Series" },
                    { 15, 6, "5 Series" },
                    { 16, 6, "X5" },
                    { 17, 6, "X7" },
                    { 18, 7, "Chiron" },
                    { 19, 7, "Veyron" },
                    { 20, 8, "Enclave" },
                    { 21, 8, "Encore" },
                    { 22, 9, "Escalade" },
                    { 23, 9, "XT5" },
                    { 24, 10, "Silverado" },
                    { 25, 10, "Malibu" },
                    { 26, 10, "Camaro" },
                    { 27, 11, "300" },
                    { 28, 11, "Pacifica" },
                    { 29, 12, "Charger" },
                    { 30, 12, "Challenger" },
                    { 31, 13, "488" },
                    { 32, 13, "Roma" },
                    { 33, 14, "500" },
                    { 34, 14, "Panda" },
                    { 35, 15, "F-150" },
                    { 36, 15, "Mustang" },
                    { 37, 16, "G70" },
                    { 38, 16, "G90" },
                    { 39, 17, "Sierra" },
                    { 40, 17, "Yukon" },
                    { 41, 18, "Civic" },
                    { 42, 18, "Accord" },
                    { 43, 19, "Elantra" },
                    { 44, 19, "Santa Fe" },
                    { 45, 20, "Q50" },
                    { 46, 20, "QX80" },
                    { 47, 21, "F-PACE" },
                    { 48, 21, "XE" },
                    { 49, 22, "Wrangler" },
                    { 50, 22, "Grand Cherokee" },
                    { 51, 44, "Model S" },
                    { 52, 44, "Model 3" },
                    { 53, 44, "Model X" },
                    { 54, 44, "Model Y" },
                    { 55, 45, "Corolla" },
                    { 56, 45, "Camry" },
                    { 57, 45, "RAV4" },
                    { 58, 46, "Golf" },
                    { 59, 46, "Passat" },
                    { 60, 47, "XC90" },
                    { 61, 47, "S60" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_MakeId",
                table: "VehicleModels",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModels_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "VehicleModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModels_ModelId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
