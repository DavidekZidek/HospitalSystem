using System.ComponentModel.DataAnnotations.Schema;
using HospitalSystem.Domain.Validations;

namespace HospitalSystem.Domain.Entities;

[Table("Person")]
public class Person : Entity<int>
{
    public string Gender { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    [FirstLetterCapitalizedCZ]
    public string FirstName { get; set; }
    [FirstLetterCapitalizedCZ]
    public string LastName { get; set; }

    // Navigation Properties
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
}