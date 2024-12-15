using HospitalSystem.Application.Abstraction;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database;

namespace HospitalSystem.Application.Implementation;

public class PatientAppService : IPatientAppService
{
    HospitalSystemDbContext _hospitalSystemDbContext;

    public PatientAppService(HospitalSystemDbContext hospitalSystemDbContext)
    {
        _hospitalSystemDbContext = hospitalSystemDbContext;
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