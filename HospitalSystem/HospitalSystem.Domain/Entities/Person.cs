namespace HospitalSystem.Domain.Entities;

public class Person
{
    public int ID { get; set; }
    public string Gender { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Navigation Properties
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
}
