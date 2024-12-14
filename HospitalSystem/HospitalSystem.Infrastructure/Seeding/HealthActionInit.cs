using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Infrastructure.Database.Seeding;

public static class HealthActionInit
{
    public static IEnumerable<HealthAction> GetHealthActions()
    {
        return new List<HealthAction>
        {
            new HealthAction { Id = 1, ProcedureName = "Blood Test", RegistrationId = 1 },
            new HealthAction { Id = 2, ProcedureName = "Vaccination", RegistrationId = 2 }
        };
    }
}