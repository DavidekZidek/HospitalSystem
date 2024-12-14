namespace HospitalSystem.Infrastructure.Database.Seeding;
using HospitalSystem.Domain.Entities;

public static class PersonInit
{
    public static IEnumerable<Person> GetPersons()
    {
        return new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", Gender = "Male", Mail = "john.doe@example.com", Phone = "123456789" },
            new Person { Id = 2, FirstName = "Jane", LastName = "Smith", Gender = "Female", Mail = "jane.smith@example.com", Phone = "987654321" },
            new Person { Id = 3, FirstName = "Michael", LastName = "Brown", Gender = "Male", Mail = "michael.brown@example.com", Phone = "555123456" },
            new Person { Id = 4, FirstName = "Emily", LastName = "White", Gender = "Female", Mail = "emily.white@example.com", Phone = "555654321" },
            new Person { Id = 5, FirstName = "Chris", LastName = "Green", Gender = "Male", Mail = "chris.green@example.com", Phone = "444123456" },
            new Person { Id = 6, FirstName = "Anna", LastName = "Black", Gender = "Female", Mail = "anna.black@example.com", Phone = "444654321" }
        };
    }
}