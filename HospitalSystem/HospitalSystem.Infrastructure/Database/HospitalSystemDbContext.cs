using Microsoft.EntityFrameworkCore;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HospitalSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using HospitalSystem.Infrastructure.Database.Seeding;
using HospitalSystem.Web.Models.Database.Configuration.MySQL;

namespace HospitalSystem.Infrastructure.Database
{
    public class HospitalSystemDbContext : IdentityDbContext<User, Capacity, int>
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<HealthAction> HealthActions { get; set; }
        public DbSet<Registration> Registrations { get; set; } 
        public DbSet<Results> Results { get; set; }
        public DbSet<BloodTest> BloodTests { get; set; }  
        public DbSet<Vaccination> Vaccinations { get; set; } 
        public DbSet<HealthExamination> HealthExaminations { get; set; } 

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
            modelBuilder.Entity<Capacity>().HasData(CapacityInit.GetRolesAMC());
            
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
            
            modelBuilder.ApplyConfiguration<Registration>(new RegistrationConfiguration());

            base.OnModelCreating(modelBuilder);
        }

       
    }
}