using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Registration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Result_RegistrationId",
                table: "Result");

            migrationBuilder.DeleteData(
                table: "HealthAction",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HealthAction",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ID_Registration",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "ID_Results",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "ID_UserAccount",
                table: "Registration");

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 27, 10, 21, 52, 402, DateTimeKind.Local).AddTicks(6070), "Admin123" });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 27, 10, 21, 52, 402, DateTimeKind.Local).AddTicks(6160), "Doctor123" });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 27, 10, 21, 52, 402, DateTimeKind.Local).AddTicks(6160), "Patient123" });

            migrationBuilder.CreateIndex(
                name: "IX_Result_RegistrationId",
                table: "Result",
                column: "RegistrationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Result_RegistrationId",
                table: "Result");

            migrationBuilder.AddColumn<int>(
                name: "ID_Registration",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_Results",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_UserAccount",
                table: "Registration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "HealthAction",
                columns: new[] { "Id", "ProcedureName", "RegistrationId" },
                values: new object[,]
                {
                    { 1, "Blood Test", 1 },
                    { 2, "Vaccination", 2 }
                });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 18, 21, 6, 27, 161, DateTimeKind.Local).AddTicks(4481), "admin123" });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 18, 21, 6, 27, 161, DateTimeKind.Local).AddTicks(4529), "doctor123" });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 18, 21, 6, 27, 161, DateTimeKind.Local).AddTicks(4531), "patient123" });

            migrationBuilder.CreateIndex(
                name: "IX_Result_RegistrationId",
                table: "Result",
                column: "RegistrationId");
        }
    }
}
