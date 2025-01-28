using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Reg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "CreatedAt", "Name", "Password", "PersonalID", "RoleId" },
                values: new object[,]
                {
                    { 8, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(810), "PatientJames", "Patient123", 0, 3 },
                    { 9, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(810), "PatientLily", "Patient123", 0, 3 },
                    { 10, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(810), "PatientOliver", "Patient123", 0, 3 },
                    { 11, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(810), "PatientEmma", "Patient123", 0, 3 },
                    { 12, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(810), "PatientLucas", "Patient123", 0, 3 },
                    { 13, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(820), "PatientAva", "Patient123", 0, 3 },
                    { 14, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(820), "PatientEthan", "Patient123", 0, 3 },
                    { 15, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(820), "PatientMia", "Patient123", 0, 3 },
                    { 16, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(820), "PatientNoah", "Patient123", 0, 3 },
                    { 17, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(820), "PatientIsabella", "Patient123", 0, 3 },
                    { 18, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(830), "PatientMason", "Patient123", 0, 3 },
                    { 19, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(830), "PatientAmelia", "Patient123", 0, 3 },
                    { 20, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(830), "PatientAlexander", "Patient123", 0, 3 },
                    { 21, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(830), "PatientCharlotte", "Patient123", 0, 3 },
                    { 22, new DateTime(2025, 1, 28, 9, 20, 22, 775, DateTimeKind.Local).AddTicks(830), "PatientBenjamin", "Patient123", 0, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 20, 8, 59, 817, DateTimeKind.Local).AddTicks(3220));
        }
    }
}
