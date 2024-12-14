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
            // Explicitní nastavení klíče (volitelné)
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<UserAccount>().HasKey(u => u.Id);
            modelBuilder.Entity<HealthAction>().HasKey(h => h.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}