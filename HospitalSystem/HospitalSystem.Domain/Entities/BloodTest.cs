namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BloodTest")]
public class BloodTest : Entity<int>
{
    public string BloodType { get; set; }
    public string ProcedureNotes { get; set; }

    // Foreign Key
    public int ProcedureId { get; set; }
    public HealthAction HealthAction { get; set; }
}