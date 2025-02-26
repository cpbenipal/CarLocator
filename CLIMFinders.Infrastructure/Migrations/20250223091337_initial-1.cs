using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLIMFinders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlanServices_PlanId",
                table: "PlanServices");
             
            migrationBuilder.CreateIndex(
                name: "IX_PlanServices_PlanId",
                table: "PlanServices",
                column: "PlanId",
                unique: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlanServices_PlanId",
                table: "PlanServices");
             
            migrationBuilder.CreateIndex(
                name: "IX_PlanServices_PlanId",
                table: "PlanServices",
                column: "PlanId");
        }
    }
}
