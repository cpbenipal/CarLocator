using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Businesses Businesses { get; set; }
        [ForeignKey("TierId")]
        public Businesses SubscriptionPlans { get; set; }
    }
}
