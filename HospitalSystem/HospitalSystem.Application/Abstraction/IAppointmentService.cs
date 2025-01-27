using HospitalSystem.Domain.Entities;
using System.Collections.Generic;
using System;

namespace HospitalSystem.Application.Abstraction
{
    public interface IAppointmentService
    {
        // Získá všechna vyšetření (HealthActions) včetně jejich podrobností.
        IList<HealthAction> GetAllHealthActions();
        
        // Vytvoří nové vyšetření (HealthAction). 
        // Např. BloodTest, Vaccination, HealthExamination.
        void CreateHealthAction(HealthAction healthAction);

        // Smaže vyšetření podle jeho ID.
        void DeleteHealthAction(int healthActionId);

        
        // Získá všechny registrace (Registration) včetně navázaných vyšetření a uživatele.
        // IList<Registration> GetAllRegistrations();

        // Vytvoří novou registraci (obecně) – pokud chcete vytvořit samostatně záznam typu Registration.
        IList<Registration> GetRegistrationsForUser(int userId);
        
        // Umožní uživateli zaregistrovat se na konkrétní vyšetření.
        // Nastavuje status, datum a další údaje.
        void RegisterUserForHealthAction(int userId, string procedureType, DateTime executionDate);

        // Smaže registraci dle jejího ID (včetně navázaných vyšetření dle OnDelete nastavení).
        void DeleteRegistration(int registrationId);
    }
}