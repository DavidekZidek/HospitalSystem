namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("HealthAction")]
public class HealthAction
{
    public int ID_Procedure { get; set; }
    public string ProcedureName { get; set; }

    // Foreign Key
    public int ID_Registration { get; set; }
    public Registration Registration { get; set; }

    // Navigation Properties
    public ICollection<BloodTest> BloodTests { get; set; }
    public ICollection<Vaccination> Vaccinations { get; set; }
    public ICollection<HealthExamination> HealthExaminations { get; set; }
}
