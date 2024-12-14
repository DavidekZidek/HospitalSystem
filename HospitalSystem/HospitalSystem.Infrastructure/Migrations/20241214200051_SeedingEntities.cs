using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "Mail", "Phone" },
                values: new object[,]
                {
                    { 1, "John", "Male", "Doe", "john.doe@example.com", "123456789" },
                    { 2, "Jane", "Female", "Smith", "jane.smith@example.com", "987654321" },
                    { 3, "Michael", "Male", "Brown", "michael.brown@example.com", "555123456" },
                    { 4, "Emily", "Female", "White", "emily.white@example.com", "555654321" },
                    { 5, "Chris", "Male", "Green", "chris.green@example.com", "444123456" },
                    { 6, "Anna", "Female", "Black", "anna.black@example.com", "444654321" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Doctor" },
                    { 3, "Patient" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthNumber", "DateOfBirth", "HealthInsurance", "PersonId" },
                values: new object[,]
                {
                    { 1, "9001011234", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company A", 1 },
                    { 2, "8506156789", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company B", 2 },
                    { 3, "0003204567", new DateTime(2000, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company C", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "CreatedAt", "Name", "Password", "PersonalID", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 14, 21, 0, 50, 797, DateTimeKind.Local).AddTicks(9400), "Admin", "admin123", 0, 1 },
                    { 2, new DateTime(2024, 12, 14, 21, 0, 50, 797, DateTimeKind.Local).AddTicks(9420), "DoctorJohn", "doctor123", 0, 2 },
                    { 3, new DateTime(2024, 12, 14, 21, 0, 50, 797, DateTimeKind.Local).AddTicks(9420), "PatientJane", "patient123", 0, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
