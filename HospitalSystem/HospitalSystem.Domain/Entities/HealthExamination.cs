namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("HealthExamination")]
public class HealthExamination : Entity<int>
{
    public string Results { get; set; }
    public string Notes { get; set; }

    // Foreign Key
    public int ProcedureId { get; set; }
    public HealthAction HealthAction { get; set; }
}