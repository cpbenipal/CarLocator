using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changebiztbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Searches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Searches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Searches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Searches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Searches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "Amount", "Duration", "ModifiedOn", "Tier" },
                values: new object[] { new DateTime(2025, 2, 17, 17, 29, 34, 879, DateTimeKind.Local).AddTicks(1852), 10m, 1, new DateTime(2025, 2, 17, 17, 29, 34, 879, DateTimeKind.Local).AddTicks(1868), "User Tier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn", "Tier" },
                values: new object[] { new DateTime(2025, 2, 17, 17, 29, 34, 879, DateTimeKind.Local).AddTicks(1874), new DateTime(2025, 2, 17, 17, 29, 34, 879, DateTimeKind.Local).AddTicks(1875), "Business Tier" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedById", "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, new DateTime(2025, 2, 17, 17, 29, 34, 879, DateTimeKind.Local).AddTicks(2927), new DateTime(2025, 2, 17, 17, 29, 34, 879, DateTimeKind.Local).AddTicks(2931), new DateTime(2025, 2, 17, 17, 29, 34, 879, DateTimeKind.Local).AddTicks(2929), "vBO+SrV6bfQXxxNW5UPAIWGrNUOCSOlTb0EI2hfeuvw=", "315N8xDDaYzz3zjOUtuTtA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Matches");

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "Amount", "Duration", "ModifiedOn", "Tier" },
                values: new object[] { new DateTime(2025, 2, 16, 14, 39, 28, 239, DateTimeKind.Local).AddTicks(798), 0m, 0, new DateTime(2025, 2, 16, 14, 39, 28, 239, DateTimeKind.Local).AddTicks(815), "Free Tier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "ModifiedOn", "Tier" },
                values: new object[] { new DateTime(2025, 2, 16, 14, 39, 28, 239, DateTimeKind.Local).AddTicks(818), new DateTime(2025, 2, 16, 14, 39, 28, 239, DateTimeKind.Local).AddTicks(819), "Paid Tier" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedById", "AddedOn", "ConfirmedOn", "ModifiedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { 0, new DateTime(2025, 2, 16, 14, 39, 28, 239, DateTimeKind.Local).AddTicks(1816), new DateTime(2025, 2, 16, 14, 39, 28, 239, DateTimeKind.Local).AddTicks(1819), new DateTime(2025, 2, 16, 14, 39, 28, 239, DateTimeKind.Local).AddTicks(1818), "n3doZiu1rEik5By9L1dXD5HXKYGmNmeqvruwjL3twQU=", "zN5ZA8ngQHJ4EIUEw0xydw==" });
        }
    }
}
