using HospitalSystem.Application.Abstraction;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalSystem.Infrastructure.Identity;
using HospitalSystem.Infrastructure.Identity.Enums;

namespace HospitalSystem.Application.Implementation
{
    public class DoctorAppointmentService : IDoctorAppointmentService
    {
        private readonly HospitalSystemDbContext _dbContext;

        public DoctorAppointmentService(HospitalSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Registration> GetAllPatientAppointments()
        {
            return _dbContext.Registrations
                .Include(r => r.UserAccount)      
                .Where(r => r.UserAccount.RoleId == (int)Capacitys.Patient)
                .ToList();
        }

        public void UpdateAppointmentDate(int registrationId, DateTime newDate)
        {
            var registration = _dbContext.Registrations.Find(registrationId);
            if (registration == null)
                throw new Exception("Registration not found.");

            registration.ExecutionDate = newDate;
            _dbContext.SaveChanges();
        }

        public void DeleteAppointment(int registrationId)
        {
            var registration = _dbContext.Registrations.Find(registrationId);
            if (registration != null)
            {
                _dbContext.Registrations.Remove(registration);
                _dbContext.SaveChanges();
            }
        }

        public void CompleteAppointment(int registrationId, string resultMessage)
        {
            var registration = _dbContext.Registrations
                .Include(r => r.Results)
                .FirstOrDefault(r => r.Id == registrationId);

            if (registration == null)
                throw new Exception("Registration not found.");

            // Nastavíme status na "completed"
            registration.Status = "completed";

            // Pokud v DB existuje tabulka "Results" vázaná 1:1 na Registration,
            // můžeme do ní uložit text. Pokud neexistuje, je potřeba ji vytvořit.
            if (registration.Results == null)
            {
                // Vytvoříme novou instanci
                registration.Results = new Results
                {
                    RegistrationId = registration.Id,
                    ResultsDescription = resultMessage
                };
            }
            else
            {
                registration.Results.ResultsDescription = resultMessage;
            }

            _dbContext.SaveChanges();
        }
    }
}
