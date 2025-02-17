using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamebusinessestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Users_UserId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Businesses_BusinessId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Businesses_TierId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Businesses_BusinessId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Businesses",
                newName: "UserAddress",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Businesses_UserId",
                schema: "dbo",
                table: "UserAddress",
                newName: "IX_UserAddress_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddress",
                schema: "dbo",
                table: "UserAddress",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 17, 17, 36, 50, 100, DateTimeKind.Local).AddTicks(5617), new DateTime(2025, 2, 17, 17, 36, 50, 100, DateTimeKind.Local).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 17, 17, 36, 50, 100, DateTimeKind.Local).AddTicks(5638), new DateTime(2025, 2, 17, 17, 36, 50, 100, DateTimeKind.Local).AddTicks(5639) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 17, 17, 36, 50, 100, DateTimeKind.Local).AddTicks(6728), new DateTime(2025, 2, 17, 17, 36, 50, 100, DateTimeKind.Local).AddTicks(6732), new DateTime(2025, 2, 17, 17, 36, 50, 100, DateTimeKind.Local).AddTicks(6730), "sfLBRvxo4RsHW+9+4Egq4jdgOFQZa2J6Mw++7yGj/wM=", "+wHOn2amuARAdRaRH0/+yg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_UserAddress_BusinessId",
                table: "Subscriptions",
                column: "BusinessId",
                principalSchema: "dbo",
                principalTable: "UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_UserAddress_TierId",
                table: "Subscriptions",
                column: "TierId",
                principalSchema: "dbo",
                principalTable: "UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_UserId",
                schema: "dbo",
                table: "UserAddress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_UserAddress_BusinessId",
                table: "Vehicles",
                column: "BusinessId",
                principalSchema: "dbo",
                principalTable: "UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_UserAddress_BusinessId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_UserAddress_TierId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId",
                schema: "dbo",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_UserAddress_BusinessId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddress",
                schema: "dbo",
                table: "UserAddress");

            migrationBuilder.RenameTable(
                name: "UserAddress",
                schema: "dbo",
                newName: "Businesses");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_UserId",
                table: "Businesses",
                newName: "IX_Businesses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 17, 17, 34, 14, 176, DateTimeKind.Local).AddTicks(8929), new DateTime(2025, 2, 17, 17, 34, 14, 176, DateTimeKind.Local).AddTicks(8940) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 2, 17, 17, 34, 14, 176, DateTimeKind.Local).AddTicks(8946), new DateTime(2025, 2, 17, 17, 34, 14, 176, DateTimeKind.Local).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 17, 17, 34, 14, 177, DateTimeKind.Local).AddTicks(272), new DateTime(2025, 2, 17, 17, 34, 14, 177, DateTimeKind.Local).AddTicks(275), new DateTime(2025, 2, 17, 17, 34, 14, 177, DateTimeKind.Local).AddTicks(273), "B+/jSmRSnPMoUdqtKS2aB6jqQC6hYIRi1bBmj8LhPgA=", "n7czNNxtj1TO/Dwy+A9Yfg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_UserId",
                table: "Businesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Businesses_BusinessId",
                table: "Subscriptions",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Businesses_TierId",
                table: "Subscriptions",
                column: "TierId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Businesses_BusinessId",
                table: "Vehicles",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
