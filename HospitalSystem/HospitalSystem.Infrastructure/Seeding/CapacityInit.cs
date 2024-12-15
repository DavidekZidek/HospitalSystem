using HospitalSystem.Infrastructure.Identity;

namespace HospitalSystem.Infrastructure.Database.Seeding;

internal class CapacityInit
{
    public static List<Capacity> GetRolesAMC()
    {
        List<Capacity> roles = new List<Capacity>();
        
        Capacity roleAdmin = new Capacity()
        {
            Id = 1,
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
        };
        
        Capacity roleDoctor = new Capacity()
        {
            Id = 2,
            Name = "Doctor",
            NormalizedName = "DOCTOR",
            ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
        };
        
        Capacity rolePatient = new Capacity()
        {
            Id = 3,
            Name = "Patient",
            NormalizedName = "PATIENT",
            ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
        };
        
        roles.Add(roleAdmin);
        roles.Add(roleDoctor);
        roles.Add(rolePatient);
        
        return roles;
    }
}