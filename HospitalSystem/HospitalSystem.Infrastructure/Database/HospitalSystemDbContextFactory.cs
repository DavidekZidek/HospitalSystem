using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HospitalSystem.Infrastructure.Database
{
    public class HospitalSystemDbContextFactory : IDesignTimeDbContextFactory<HospitalSystemDbContext>
    {
        public HospitalSystemDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HospitalSystemDbContext>();

            // Váš připojovací řetězec (přizpůsobte)
            optionsBuilder.UseMySql(
                "server=localhost;database=HospitalSystem;user=root;password=yourpassword;",
                new MySqlServerVersion(new Version(8, 0, 30))
            );

            return new HospitalSystemDbContext(optionsBuilder.Options);
        }
    }
}