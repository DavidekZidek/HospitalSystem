using Microsoft.EntityFrameworkCore;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database.Seeding;

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
            // Seeding v pořadí závislostí
            modelBuilder.Entity<Role>().HasData(RoleInit.GetRoles());
            modelBuilder.Entity<Person>().HasData(PersonInit.GetPersons()); // Přidejte PersonInit, pokud je potřeba
            modelBuilder.Entity<UserAccount>().HasData(UserAccountInit.GetUserAccounts());
            modelBuilder.Entity<Patient>().HasData(PatientInit.GetPatients());

            base.OnModelCreating(modelBuilder);
        }


    }
}