using HospitalSystem.Application.ViewModels;

namespace HospitalSystem.Application.Abstraction;

public interface IHomeService
{
    PatientViewModel GetPatientViewModel();
}