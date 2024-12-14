using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Specialization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BirthNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HealthInsurance = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProcedureDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ID_UserAccount = table.Column<int>(type: "int", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registration_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HealthAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProcedureName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthAction_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_Results = table.Column<int>(type: "int", nullable: false),
                    ResultsDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ID_Registration = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BloodTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BloodType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcedureNotes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    HealthActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodTest_HealthAction_HealthActionId",
                        column: x => x.HealthActionId,
                        principalTable: "HealthAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HealthExamination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Results = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    HealthActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthExamination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthExamination_HealthAction_HealthActionId",
                        column: x => x.HealthActionId,
                        principalTable: "HealthAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SideEffects = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VaccinationType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    HealthActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_HealthAction_HealthActionId",
                        column: x => x.HealthActionId,
                        principalTable: "HealthAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTest_HealthActionId",
                table: "BloodTest",
                column: "HealthActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PersonId",
                table: "Doctor",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthAction_RegistrationId",
                table: "HealthAction",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthExamination_HealthActionId",
                table: "HealthExamination",
                column: "HealthActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PersonId",
                table: "Patient",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registration_UserAccountId",
                table: "Registration",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_RegistrationId",
                table: "Result",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_RoleId",
                table: "UserAccounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_HealthActionId",
                table: "Vaccinations",
                column: "HealthActionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTest");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "HealthExamination");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "HealthAction");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
