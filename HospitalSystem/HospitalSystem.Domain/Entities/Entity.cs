using HospitalSystem.Domain.Entities.Interfaces;

namespace HospitalSystem.Domain.Entities
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public required TKey Id { get; set; }
    }
}