using HospitalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalSystem.Infrastructure.Identity;

namespace HospitalSystem.Application.Abstraction
{
    public interface IDoctorAppointmentService
    {
        // Vrátí všechna vyšetření (registrace), která vytvořili pacienti.
        Task<IList<Registration>> GetAllPatientAppointmentsAsync();

        // Vrátí všechny uživatele s rolí "Patient".
        Task<IList<User>> GetAllPatientsAsync();
        
        // Doktor aktualizuje termín (ExecutionDate).
        Task UpdateAppointmentDateAsync(int registrationId, DateTime newDate);

        // Doktor označí appointment za dokončený.
        Task CompleteAppointmentAsync(int registrationId, string resultMessage);

        // Doktor smaže (zruší) appointment.
        Task DeleteAppointmentAsync(int registrationId);
        
        Task<IList<User>> GetUsersInRoleAsync(string role);

    }
}