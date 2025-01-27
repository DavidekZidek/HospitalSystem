namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Registration")]
public class Registration : Entity<int>
{
    public string Status { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExecutionDate { get; set; }
    public string ProcedureDescription { get; set; }

    // Foreign Keys
    public int UserAccountId { get; set; }
    public UserAccount UserAccount { get; set; }

    // Navigation Properties
    public ICollection<HealthAction> HealthActions { get; set; }
    public Results Results { get; set; }
}   