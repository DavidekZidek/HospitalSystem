namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BloodTest")]
public class BloodTest
{
    public int ID_BloodTests { get; set; }
    public string BloodType { get; set; }
    public string ProcedureNotes { get; set; }

    // Foreign Key
    public int ID_Procedure { get; set; }
    public HealthAction HealthAction { get; set; }
}
