using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addVehicleMaketable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Make",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Acura" },
                    { 2, "Alfa Romeo" },
                    { 3, "Aston Martin" },
                    { 4, "Audi" },
                    { 5, "Bentley" },
                    { 6, "BMW" },
                    { 7, "Bugatti" },
                    { 8, "Buick" },
                    { 9, "Cadillac" },
                    { 10, "Chevrolet" },
                    { 11, "Chrysler" },
                    { 12, "Dodge" },
                    { 13, "Ferrari" },
                    { 14, "Fiat" },
                    { 15, "Ford" },
                    { 16, "Genesis" },
                    { 17, "GMC" },
                    { 18, "Honda" },
                    { 19, "Hyundai" },
                    { 20, "Infiniti" },
                    { 21, "Jaguar" },
                    { 22, "Jeep" },
                    { 23, "Kia" },
                    { 24, "Lamborghini" },
                    { 25, "Land Rover" },
                    { 26, "Lexus" },
                    { 27, "Lincoln" },
                    { 28, "Lotus" },
                    { 29, "Maserati" },
                    { 30, "Mazda" },
                    { 31, "McLaren" },
                    { 32, "Mercedes-Benz" },
                    { 33, "Mini" },
                    { 34, "Mitsubishi" },
                    { 35, "Nissan" },
                    { 36, "Peugeot" },
                    { 37, "Porsche" },
                    { 38, "Ram" },
                    { 39, "Renault" },
                    { 40, "Rolls-Royce" },
                    { 41, "Saab" },
                    { 42, "Subaru" },
                    { 43, "Suzuki" },
                    { 44, "Tesla" },
                    { 45, "Toyota" },
                    { 46, "Volkswagen" },
                    { 47, "Volvo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MakeId",
                table: "Vehicles",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleMakes_MakeId",
                table: "Vehicles",
                column: "MakeId",
                principalTable: "VehicleMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleMakes_MakeId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleMakes");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_MakeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
