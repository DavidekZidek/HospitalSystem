namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Doctor")]
public class Doctor
{
    public int ID_Doctor { get; set; }
    public string Specialization { get; set; }
    public int YearsOfExperience { get; set; }

    // Foreign Key
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
