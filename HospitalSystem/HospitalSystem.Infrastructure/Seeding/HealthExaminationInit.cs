using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Infrastructure.Database.Seeding;

public static class HealthExaminationInit
{
    public static IEnumerable<HealthExamination> GetHealthExaminations()
    {
        return new List<HealthExamination>
        {
            new HealthExamination { Id = 1, Results = "Normal", Notes = "No issues detected", ProcedureId = 1 },
            new HealthExamination { Id = 2, Results = "High cholesterol", Notes = "Diet change recommended", ProcedureId = 2 }
        };
    }
}