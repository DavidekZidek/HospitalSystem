using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Application.Abstraction;

public interface IPatientAppService
{
    IList<Patient> Select();
    void Create(Patient patient);
    bool Delete(int id);
}