namespace HospitalSystem.Domain.Entities;

public class Registration
{
    public int ID { get; set; }
    public string Status { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExecutionDate { get; set; }
    public string ProcedureDescription { get; set; }

    // Foreign Keys
    public int ID_UserAccount { get; set; }
    public UserAccount UserAccount { get; set; }

    // Navigation Properties
    public ICollection<HealthAction> HealthActions { get; set; }
    public ICollection<Results> Results { get; set; }
}
