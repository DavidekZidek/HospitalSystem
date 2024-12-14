using Microsoft.EntityFrameworkCore;
using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Infrastructure.Database
{
    public class HospitalSystemDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<HealthAction> HealthActions { get; set; }

        public HospitalSystemDbContext(DbContextOptions<HospitalSystemDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nastavení relací (volitelné)
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