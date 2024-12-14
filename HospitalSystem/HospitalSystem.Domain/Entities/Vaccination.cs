namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Vaccinations")]
public class Vaccination
{
    public int ID_Vaccination { get; set; }
    public string SideEffects { get; set; }
    public string VaccinationType { get; set; }

    // Foreign Key
    public int ID_Procedure { get; set; }
    public HealthAction HealthAction { get; set; }
}
