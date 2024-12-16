using HospitalSystem.Application.Abstraction;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database;

namespace HospitalSystem.Application.Implementation;

public class PatientAppService : IPatientAppService
{
    HospitalSystemDbContext _hospitalSystemDbContext;
    IFileUploadService _fileUploadService;

    public PatientAppService(HospitalSystemDbContext hospitalSystemDbContext, IFileUploadService fileUploadService)
    {
        _hospitalSystemDbContext = hospitalSystemDbContext;
        _fileUploadService = fileUploadService;
    }

    public IList<Patient> Select()
    {
        return _hospitalSystemDbContext.Patients.ToList();
    }

    public void Create(Patient patient)
    {
        _hospitalSystemDbContext.Patients.Add(patient);
        _hospitalSystemDbContext.SaveChanges();
    }

    public bool Delete(int id)
    {
        bool deleted = false;
        
        Patient? patient
            = _hospitalSystemDbContext.Patients.FirstOrDefault(p => p.Id == id);

        if (patient != null)
        {
            _hospitalSystemDbContext.Patients.Remove(patient);
            _hospitalSystemDbContext.SaveChanges();
            deleted = true;
        }

        return deleted;
    }
}