namespace HospitalSystem.Domain.Entities;

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
