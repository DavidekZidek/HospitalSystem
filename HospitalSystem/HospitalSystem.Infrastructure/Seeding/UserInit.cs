using HospitalSystem.Infrastructure.Identity;

namespace HospitalSystem.Infrastructure.Database.Seeding;

internal class UserInit
{
    public User GetAdmin()
    {
        User admin = new User()
        {
            Id = 1,
            FirstName = "Jan",
            LastName = "Novák",
            UserName = "jan.novak",
            NormalizedUserName = "JAN.NOVAK",
            Email = "jan.novak@hospital.cz",
            NormalizedEmail = "JAN.NOVAK@HOSPITAL.CZ",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
            SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
            ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0
        };
        return admin;
    }
    public User GetDoctor()
    {
        User doctor = new User()
        {
            Id = 2,
            FirstName = "Petr",
            LastName = "Horák",
            UserName = "petr.horak",
            NormalizedUserName = "PETR.HORAK",
            Email = "petr.horak@hospital.cz",
            NormalizedEmail = "PETR.HORAK@HOSPITAL.CZ",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
            SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
            ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0
        };
        return doctor;
    }
}