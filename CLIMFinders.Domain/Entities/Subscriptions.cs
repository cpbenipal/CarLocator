using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLIMFinders.Domain.Entities
{
    public class Subscriptions: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }        
        public int TierId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        [ForeignKey("BusinessId")]
        public UserAddress Businesses { get; set; }
        [ForeignKey("TierId")]
        public UserAddress SubscriptionPlans { get; set; }
    }
}
