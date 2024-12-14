namespace HospitalSystem.Infrastructure.Database.Seeding;
using HospitalSystem.Domain.Entities;

public static class PatientInit
{
    public static IEnumerable<Patient> GetPatients()
    {
        return new List<Patient>
        {
            new Patient { Id = 1, DateOfBirth = new DateTime(1990, 1, 1), BirthNumber = "9001011234", HealthInsurance = "Company A", PersonId = 1 },
            new Patient { Id = 2, DateOfBirth = new DateTime(1985, 6, 15), BirthNumber = "8506156789", HealthInsurance = "Company B", PersonId = 2 },
            new Patient { Id = 3, DateOfBirth = new DateTime(2000, 3, 20), BirthNumber = "0003204567", HealthInsurance = "Company C", PersonId = 3 }
        };
    }
}