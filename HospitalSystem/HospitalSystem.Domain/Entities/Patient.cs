namespace HospitalSystem.Domain.Entities;

public class Patient
{
    public int ID { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string BirthNumber { get; set; }
    public string HealthInsurance { get; set; }

    // Foreign Key
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
