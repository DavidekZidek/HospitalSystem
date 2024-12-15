using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Application.ViewModels;

public class PatientViewModel
{
    public IList<Patient>? Patients { get; set; }
}