namespace HospitalSystem.Domain.Entities;

public class Vaccination
{
    public int ID_Vaccination { get; set; }
    public string SideEffects { get; set; }
    public string VaccinationType { get; set; }

    // Foreign Key
    public int ID_Procedure { get; set; }
    public HealthAction HealthAction { get; set; }
}
