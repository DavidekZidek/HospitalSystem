using Microsoft.EntityFrameworkCore;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HospitalSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using HospitalSystem.Infrastructure.Database.Seeding;

namespace HospitalSystem.Infrastructure.Database
{
    public class HospitalSystemDbContext : IdentityDbContext<User, Capacity, int>
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
            
            //Identity - User and Role initialization
            //roles must be added first
            CapacityInit rolesInit = new CapacityInit();
            modelBuilder.Entity<Role>().HasData(CapacityInit.GetRolesAMC());
            
            //then, create users ..
            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            User doctor = userInit.GetDoctor();
            
            //.. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, doctor);
            
            //and finally, connect the users with the roles
            UserCapacityInit userRolesInit = new UserCapacityInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> doctorUserRoles = userRolesInit.GetRolesForDoctor();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(doctorUserRoles);

            base.OnModelCreating(modelBuilder);
        }

       
    }
}