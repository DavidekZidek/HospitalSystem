namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("HealthExamination")]
public class HealthExamination
{
    public int ID_HealthExamination { get; set; }
    public string Results { get; set; }
    public string Notes { get; set; }

    // Foreign Key
    public int ID_Procedure { get; set; }
    public HealthAction HealthAction { get; set; }
}
