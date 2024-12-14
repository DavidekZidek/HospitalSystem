namespace HospitalSystem.Infrastructure.Database.Seeding;
using HospitalSystem.Domain.Entities;

public static class DoctorInit
{
    public static IEnumerable<Doctor> GetDoctors()
    {
        return new List<Doctor>
        {
            new Doctor { Id = 1, Specialization = "Cardiology", YearsOfExperience = 10, PersonId = 4 },
            new Doctor { Id = 2, Specialization = "Neurology", YearsOfExperience = 8, PersonId = 5 },
            new Doctor { Id = 3, Specialization = "Orthopedics", YearsOfExperience = 12, PersonId = 6 }
        };
    }
}