using Given.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIMFinders.Domain.Entities
{
    public class Searches
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string VIN { get; set; }
        public DateTime SearchDate { get; set; }
        public bool Paid { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } 

    }
}
