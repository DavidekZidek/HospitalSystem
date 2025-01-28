using HospitalSystem.Application.Abstraction;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HospitalSystem.Application.Implementation
{
    public class DoctorAppointmentService : IDoctorAppointmentService
    {
        private readonly HospitalSystemDbContext _dbContext;
        private readonly IUserManagementService _userManagementService;
        private readonly UserManager<User> _userManager;

        public DoctorAppointmentService(HospitalSystemDbContext dbContext, IUserManagementService userManagementService, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManagementService = userManagementService;
            _userManager = userManager;
        }

        public async Task<IList<Registration>> GetAllPatientAppointmentsAsync()
        {
            // Získání uživatelů s rolí "Patient"
            var patients = await _userManager.GetUsersInRoleAsync("Patient");

            // Získání seznamu ID pacientů
            var patientIds = patients.Select(p => p.Id).ToList();

            // Načtení registrací pouze pro pacienty
            var patientAppointments = await _dbContext.Registrations
                .Include(r => r.UserAccount) // Připojení uživatelských účtů
                .Where(r => patientIds.Contains(r.UserAccountId)) // Filtr pouze na pacienty
                .ToListAsync();

            return patientAppointments;
        }

        public async Task<IList<User>> GetAllPatientsAsync()
        {
            // Získání seznamu všech uživatelů s rolí "Patient"
            return await _userManager.GetUsersInRoleAsync("Patient");
        }
        
        public async Task<IList<User>> GetUsersInRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return users.ToList();
        }

        public async Task UpdateAppointmentDateAsync(int registrationId, DateTime newDate)
        {
            var registration = await _dbContext.Registrations.FindAsync(registrationId);
            if (registration == null)
                throw new Exception("Registration not found.");

            registration.ExecutionDate = newDate;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int registrationId)
        {
            var registration = await _dbContext.Registrations.FindAsync(registrationId);
            if (registration != null)
            {
                _dbContext.Registrations.Remove(registration);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task CompleteAppointmentAsync(int registrationId, string resultMessage)
        {
            var registration = await _dbContext.Registrations
                .Include(r => r.Results)
                .FirstOrDefaultAsync(r => r.Id == registrationId);

            if (registration == null)
                throw new Exception("Registration not found.");

            // Nastavení statusu na "completed"
            registration.Status = "completed";

            // Uložení výsledku do tabulky "Results"
            if (registration.Results == null)
            {
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

            await _dbContext.SaveChangesAsync();
        }
    }
}
