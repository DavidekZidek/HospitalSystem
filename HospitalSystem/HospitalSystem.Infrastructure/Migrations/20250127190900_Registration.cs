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

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3160), "Admin123" });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3210), "Doctor123" });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3210), "Patient123" });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "CreatedAt", "Name", "Password", "PersonalID", "RoleId" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3210), "PatientJane", "Patient123", 0, 3 },
                    { 5, new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3220), "PatientJane", "Patient123", 0, 3 },
                    { 6, new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3220), "PatientJane", "Patient123", 0, 3 },
                    { 7, new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3220), "PatientJane", "Patient123", 0, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 7);

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

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 16, 12, 9, 57, 685, DateTimeKind.Local).AddTicks(5800), "admin123" });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 16, 12, 9, 57, 685, DateTimeKind.Local).AddTicks(5840), "doctor123" });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 16, 12, 9, 57, 685, DateTimeKind.Local).AddTicks(5840), "patient123" });

            migrationBuilder.CreateIndex(
                name: "IX_Result_RegistrationId",
                table: "Result",
                column: "RegistrationId");
        }
    }
}
