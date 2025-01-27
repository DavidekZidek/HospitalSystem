namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Result")]
public class Results : Entity<int>
{
    public string ResultsDescription { get; set; }
    public DateTime CreatedDate { get; set; }

    // Foreign Key
    public int RegistrationId { get; set; }
    public Registration Registration { get; set; }
}
