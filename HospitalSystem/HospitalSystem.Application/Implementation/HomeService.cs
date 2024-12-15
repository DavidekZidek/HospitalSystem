using HospitalSystem.Application.Abstraction;
using HospitalSystem.Application.ViewModels;

namespace HospitalSystem.Application.Implementation;

public class HomeService : IHomeService
{
    IPatientAppService _patientAppService;

    public HomeService(IPatientAppService patientAppService)
    {
        _patientAppService = patientAppService;
    }

    public PatientViewModel GetPatientViewModel()
    {
        PatientViewModel viewModel = new PatientViewModel();
        viewModel.Patients = _patientAppService.Select();
        
        return viewModel;
    }
}