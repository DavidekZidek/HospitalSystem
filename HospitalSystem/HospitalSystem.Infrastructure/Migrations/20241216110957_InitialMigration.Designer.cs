﻿// <auto-generated />
using System;
using HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalSystem.Infrastructure.Migrations
{
    [DbContext(typeof(HospitalSystemDbContext))]
    [Migration("20241216110957_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HospitalSystem.Domain.Entities.BloodTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("HealthActionId")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<string>("ProcedureNotes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HealthActionId");

                    b.ToTable("BloodTest");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.HealthAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProcedureName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RegistrationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationId");

                    b.ToTable("HealthAction");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.HealthExamination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HealthActionId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<string>("Results")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HealthActionId");

                    b.ToTable("HealthExamination");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BirthNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HealthInsurance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthNumber = "9001011234",
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HealthInsurance = "Company A",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthNumber = "8506156789",
                            DateOfBirth = new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HealthInsurance = "Company B",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            BirthNumber = "0003204567",
                            DateOfBirth = new DateTime(2000, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HealthInsurance = "Company C",
                            PersonId = 3
                        });
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            Gender = "Male",
                            LastName = "Doe",
                            Mail = "john.doe@example.com",
                            Phone = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jane",
                            Gender = "Female",
                            LastName = "Smith",
                            Mail = "jane.smith@example.com",
                            Phone = "987654321"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Michael",
                            Gender = "Male",
                            LastName = "Brown",
                            Mail = "michael.brown@example.com",
                            Phone = "555123456"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Emily",
                            Gender = "Female",
                            LastName = "White",
                            Mail = "emily.white@example.com",
                            Phone = "555654321"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Chris",
                            Gender = "Male",
                            LastName = "Green",
                            Mail = "chris.green@example.com",
                            Phone = "444123456"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Anna",
                            Gender = "Female",
                            LastName = "Black",
                            Mail = "anna.black@example.com",
                            Phone = "444654321"
                        });
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ID_UserAccount")
                        .HasColumnType("int");

                    b.Property<string>("ProcedureDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Results", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ID_Registration")
                        .HasColumnType("int");

                    b.Property<int>("ID_Results")
                        .HasColumnType("int");

                    b.Property<int>("RegistrationId")
                        .HasColumnType("int");

                    b.Property<string>("ResultsDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationId");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Doctor"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Patient"
                        });
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PersonalID")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("UserAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 16, 12, 9, 57, 685, DateTimeKind.Local).AddTicks(5800),
                            Name = "Admin",
                            Password = "admin123",
                            PersonalID = 0,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 12, 16, 12, 9, 57, 685, DateTimeKind.Local).AddTicks(5840),
                            Name = "DoctorJohn",
                            Password = "doctor123",
                            PersonalID = 0,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 12, 16, 12, 9, 57, 685, DateTimeKind.Local).AddTicks(5840),
                            Name = "PatientJane",
                            Password = "patient123",
                            PersonalID = 0,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Vaccination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HealthActionId")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<string>("SideEffects")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VaccinationType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HealthActionId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("HospitalSystem.Infrastructure.Identity.Capacity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        });
                });

            modelBuilder.Entity("HospitalSystem.Infrastructure.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                            Email = "jan.novak@hospital.cz",
                            EmailConfirmed = true,
                            FirstName = "Jan",
                            LastName = "Novák",
                            LockoutEnabled = true,
                            NormalizedEmail = "JAN.NOVAK@HOSPITAL.CZ",
                            NormalizedUserName = "JAN.NOVAK",
                            PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                            TwoFactorEnabled = false,
                            UserName = "jan.novak"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                            Email = "petr.horak@hospital.cz",
                            EmailConfirmed = true,
                            FirstName = "Petr",
                            LastName = "Horák",
                            LockoutEnabled = true,
                            NormalizedEmail = "PETR.HORAK@HOSPITAL.CZ",
                            NormalizedUserName = "PETR.HORAK",
                            PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                            TwoFactorEnabled = false,
                            UserName = "petr.horak"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.BloodTest", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.HealthAction", "HealthAction")
                        .WithMany("BloodTests")
                        .HasForeignKey("HealthActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthAction");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.Person", "Person")
                        .WithOne("Doctor")
                        .HasForeignKey("HospitalSystem.Domain.Entities.Doctor", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.HealthAction", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.Registration", "Registration")
                        .WithMany("HealthActions")
                        .HasForeignKey("RegistrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.HealthExamination", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.HealthAction", "HealthAction")
                        .WithMany("HealthExaminations")
                        .HasForeignKey("HealthActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthAction");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Patient", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.Person", "Person")
                        .WithOne("Patient")
                        .HasForeignKey("HospitalSystem.Domain.Entities.Patient", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Registration", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.UserAccount", "UserAccount")
                        .WithMany("Registrations")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Results", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.Registration", "Registration")
                        .WithMany("Results")
                        .HasForeignKey("RegistrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.UserAccount", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.Role", "Role")
                        .WithMany("UserAccounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Vaccination", b =>
                {
                    b.HasOne("HospitalSystem.Domain.Entities.HealthAction", "HealthAction")
                        .WithMany("Vaccinations")
                        .HasForeignKey("HealthActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthAction");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("HospitalSystem.Infrastructure.Identity.Capacity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("HospitalSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("HospitalSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("HospitalSystem.Infrastructure.Identity.Capacity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("HospitalSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.HealthAction", b =>
                {
                    b.Navigation("BloodTests");

                    b.Navigation("HealthExaminations");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Person", b =>
                {
                    b.Navigation("Doctor")
                        .IsRequired();

                    b.Navigation("Patient")
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Registration", b =>
                {
                    b.Navigation("HealthActions");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserAccounts");
                });

            modelBuilder.Entity("HospitalSystem.Domain.Entities.UserAccount", b =>
                {
                    b.Navigation("Registrations");
                });
#pragma warning restore 612, 618
        }
    }
}
