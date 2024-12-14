using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities
{
    [Table(nameof(Carousel))]
    public class Carousel : Entity<int>
    {
        public required string ImageSrc { get; set; }
        public required string ImageAlt { get; set; }
    }
}