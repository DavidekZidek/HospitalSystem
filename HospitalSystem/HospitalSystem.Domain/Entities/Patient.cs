namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Patient")]
public class Patient : Entity<int>
{
    public DateTime DateOfBirth { get; set; }
    public string BirthNumber { get; set; }
    public string HealthInsurance { get; set; }

    // Foreign Key
    public int PersonId { get; set; }
    public Person Person { get; set; }
}