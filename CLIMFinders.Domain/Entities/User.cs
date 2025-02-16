using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLIMFinders.Domain.Entities
{
    public partial class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }  
        public string Email { get; set; }
       // public string Password { get; set; }
        public int RoleId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool? IsConfirmed { get; set; } = false;
        public DateTime? ConfirmedOn { get; set; }         
        public byte[]? Photo { get; set; }
        [ForeignKey("RoleId")]
        public Roles Roles { get; set; }
        public Businesses? Businesses { get; set; }

    }
}
