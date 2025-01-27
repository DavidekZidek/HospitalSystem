using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Infrastructure.Database;

namespace HospitalSystem.Application.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HospitalSystemDbContext _dbContext;

        public AppointmentService(HospitalSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IList<HealthAction> GetAllHealthActions()
        {
            // Načte všechny HealthAction a rovnou i související tabulky
            return _dbContext.HealthActions
                             .Include(h => h.BloodTests)
                             .Include(h => h.Vaccinations)
                             .Include(h => h.HealthExaminations)
                             .ToList();
        }

        public void CreateHealthAction(HealthAction healthAction)
        {
            _dbContext.HealthActions.Add(healthAction);
            _dbContext.SaveChanges();
        }

        public void DeleteHealthAction(int healthActionId)
        {
            var healthAction = _dbContext.HealthActions.Find(healthActionId);
            if (healthAction != null)
            {
                _dbContext.HealthActions.Remove(healthAction);
                _dbContext.SaveChanges();
            }
        }
        

        public IList<Registration> GetRegistrationsForUser(int userId)
        {
            return _dbContext.Registrations
                .Where(r => r.UserAccountId == userId)
                .Include(r => r.HealthActions)
                .ToList();
        }

        public void CreateRegistration(Registration registration)
        {
            // Např. můžete nastavit výchozí status a creation date
            if (string.IsNullOrEmpty(registration.Status))
            {
                registration.Status = "proposal";
            }
            registration.CreationDate = DateTime.Now;

            _dbContext.Registrations.Add(registration);
            _dbContext.SaveChanges();
        }

        public void RegisterUserForHealthAction(int userId, string procedureType, DateTime executionDate)
        {
            // Vytvořte HealthAction (zatím není v DB)
            var healthAction = new HealthAction
            {
                ProcedureName = procedureType
            };

            // Vytvořte Registration a přidejte do ní new HealthAction
            var newRegistration = new Registration
            {
                UserAccountId   = userId,
                Status          = "proposal",
                CreationDate    = DateTime.Now,
                ExecutionDate   = executionDate,
                ProcedureDescription = procedureType,
                HealthActions   = new List<HealthAction> { healthAction }
            };

            // Uložíme najednou => EF nejprve založí Registration, následně HealthAction
            _dbContext.Registrations.Add(newRegistration);
            _dbContext.SaveChanges();
        }

        public void DeleteRegistration(int registrationId)
        {
            var registration = _dbContext.Registrations.Find(registrationId);
            if (registration != null)
            {
                _dbContext.Registrations.Remove(registration);
                _dbContext.SaveChanges();
            }
        }
    }
}
