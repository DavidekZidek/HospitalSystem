using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Identity;

namespace HospitalSystem.Infrastructure.Database.Configuration
{
    internal class RegistrationConfigurationBase : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            // One-to-Many: Registration ↔ UserAccount (Patient)
            builder.HasOne(r => r.UserAccount)
                .WithMany(u => u.Registrations)
                .HasForeignKey(r => r.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Registration ↔ HealthActions
            builder.HasMany(r => r.HealthActions)
                .WithOne(h => h.Registration)
                .HasForeignKey(h => h.RegistrationId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-One: Registration ↔ Results
            builder.HasOne(r => r.Results)
                .WithOne(res => res.Registration)
                .HasForeignKey<Results>(res => res.RegistrationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}