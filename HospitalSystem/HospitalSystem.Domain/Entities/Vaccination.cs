namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Vaccinations")]
public class Vaccination : Entity<int>
{
    public string SideEffects { get; set; }
    public string VaccinationType { get; set; }

    // Foreign Key
    public int ProcedureId { get; set; } // Přeznačeno podle konvencí
    public HealthAction HealthAction { get; set; }
}