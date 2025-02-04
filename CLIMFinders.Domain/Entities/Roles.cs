using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Given.DataContext.Entities
{ 
    public partial class Roles 
    { 
        public int Id { get; set; }
        public string RoleNanme { get; set; }   
    } 
}
