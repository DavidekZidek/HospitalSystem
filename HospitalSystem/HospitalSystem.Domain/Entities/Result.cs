namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Result")]
public class Results
{
    public int ID_Results { get; set; }
    public string ResultsDescription { get; set; }
    public DateTime CreatedDate { get; set; }

    // Foreign Key
    public int ID_Registration { get; set; }
    public Registration Registration { get; set; }
}
