using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedbstructv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Payments",
                newName: "TotalAmount");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 3, 1, 0, 4, 39, 596, DateTimeKind.Local).AddTicks(9087), new DateTime(2025, 3, 1, 0, 4, 39, 596, DateTimeKind.Local).AddTicks(9105), new DateTime(2025, 3, 1, 0, 4, 39, 596, DateTimeKind.Local).AddTicks(9100), "/eRUx4u6bQaxuGKHUAq08tkr5ucg3DTd6zREQN4RHFw=", "566ToC/uzFC9Ft8XEL0jqg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Payments",
                newName: "Amount");

            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 28, 23, 53, 1, 498, DateTimeKind.Local).AddTicks(7759), new DateTime(2025, 2, 28, 23, 53, 1, 498, DateTimeKind.Local).AddTicks(7773), new DateTime(2025, 2, 28, 23, 53, 1, 498, DateTimeKind.Local).AddTicks(7771), "EczldNH5CjZd7TEhQepM+1z1Cyc8BN2ov0O5I+GtJtU=", "zC8yfV5d5MBZLHSr533nRA==" });
        }
    }
}
