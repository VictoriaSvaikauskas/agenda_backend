using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaAPI.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public long CelularNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public string Description { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; } 
    }
}
