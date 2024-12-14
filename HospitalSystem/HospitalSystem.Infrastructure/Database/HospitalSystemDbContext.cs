using HospitalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Infrastructure.Database
{
    public class HospitalSystemDbContext : DbContext
    {
        public HospitalSystemDbContext(DbContextOptions<HospitalSystemDbContext> options)
            : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<HealthAction> HealthActions { get; set; }
        public DbSet<BloodTest> BloodTests { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<HealthExamination> HealthExaminations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Person)
                .WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.PersonId);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Person)
                .WithOne(p => p.Patient)
                .HasForeignKey<Patient>(p => p.PersonId);

            base.OnModelCreating(modelBuilder);
        }
    }
}