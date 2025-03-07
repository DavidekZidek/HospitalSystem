using HospitalSystem.Application.ViewModels;

namespace HospitalSystem.Application.Abstraction;

public interface IHomeService
{
    PatientViewModel GetPatientViewModel();
    string GetRedirectUrlForAppointment(bool isAuthenticated, string procedureType, string returnUrl);
}