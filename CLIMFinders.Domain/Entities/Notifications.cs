using Given.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIMFinders.Domain.Entities
{
    public class Notifications
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
