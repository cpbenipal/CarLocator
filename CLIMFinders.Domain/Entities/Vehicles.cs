using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIMFinders.Domain.Entities
{
    public class Vehicles: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Businesses Businesses { get; set; } 
    }
}
