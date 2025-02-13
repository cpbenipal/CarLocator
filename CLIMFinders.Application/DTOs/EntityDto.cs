using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIMFinders.Application.DTOs
{
    public class EntityDto
    {
        public int LoginId { get; set; }
        public int BusinessId { get; set; } 
    }
    public static class CustomClaimTypes
    { 
        public const string BusinessId = "custom:BusinessId";        
    }
}
