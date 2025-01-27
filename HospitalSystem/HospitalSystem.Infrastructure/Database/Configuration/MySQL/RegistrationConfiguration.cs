using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database.Configuration;


namespace HospitalSystem.Web.Models.Database.Configuration.MySQL
{
    internal class RegistrationConfiguration : RegistrationConfigurationBase
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            base.Configure(builder);
            
            builder.Property(nameof(Registration.CreationDate))
                .HasDefaultValueSql("NOW(6)");
        }
    }
}