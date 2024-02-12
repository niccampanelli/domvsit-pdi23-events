using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Event
{
    [Table("event_attendant")]
    public class EventAttendantEntity
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public long? EventId { get; set; }

        [Required]
        public long AttendantId { get; set; }
    }
}
