using HospitalSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HospitalSystem.Application.Abstraction
{
    public interface IDoctorAppointmentService
    {
        // Vrátí všechna vyšetření (registrace), která vytvořili pacienti.
        IList<Registration> GetAllPatientAppointments();

        // Doktor aktualizuje termín (ExecutionDate).
        void UpdateAppointmentDate(int registrationId, DateTime newDate);

        // Doktor označí appointment za dokončený
        void CompleteAppointment(int registrationId, string resultMessage);

        // Doktor smaže (zruší) appointment.
        void DeleteAppointment(int registrationId);
    }
}