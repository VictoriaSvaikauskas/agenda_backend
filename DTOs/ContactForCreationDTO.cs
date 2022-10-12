using System.ComponentModel.DataAnnotations;

namespace AgendaAPI.DTOs
{
    public class ContactForCreationDTO
    {
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
        public long CelularNumber { get; set; }
        public long TelephoneNumber { get; set; }
        public string Description { get; set; }
    }
}
