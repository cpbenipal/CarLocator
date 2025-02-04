using CLIMFinders.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Given.DataContext.Entities
{
    public partial class SubscriptionPlans: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Tier { get; set; }
        public decimal Amount { get; set; } 
        public int Duration { get; set; }
    } 
}
