using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Event
{
    [Table("event")]
    public class EventEntity
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public List<string>? Tags { get; set; }

        public string? Link { get; set; }

        public long ConsultorId { get; set; }

        [Required]
        public DateTime Ocurrence { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<EventAttendantEntity> EventAttendants { get; set; }
    }
}
