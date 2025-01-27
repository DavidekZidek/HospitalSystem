using HospitalSystem.Application.Abstraction;
using HospitalSystem.Application.ViewModels;

namespace HospitalSystem.Application.Implementation;

public class HomeService : IHomeService
{
    private readonly IPatientAppService _patientAppService;

    public HomeService(IPatientAppService patientAppService)
    {
        _patientAppService = patientAppService;
    }

    public PatientViewModel GetPatientViewModel()
    {
        PatientViewModel viewModel = new PatientViewModel
        {
            Patients = _patientAppService.Select()
        };
        return viewModel;
    }

    public string GetRedirectUrlForAppointment(bool isAuthenticated, string procedureType, string returnUrl)
    {
        if (isAuthenticated)
        {
            return $"/User/Dashboard/Appointments?procedureType={procedureType}";
        }

        return $"/Security/Account/Login?returnUrl={returnUrl}";
    }
}