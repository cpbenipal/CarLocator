using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLIMFinders.Domain.Entities
{
    public class Businesses: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string? ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string? Description { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
