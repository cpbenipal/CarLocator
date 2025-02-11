using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CLIMFinders.Application.DTOs
{
    public class VehicleDto: EntityDto
    {
        public int Id { get; set; } 
        [RegularExpression(@"^[A-HJ-NPR-Za-hj-npr-z\d]{8}[\dX][A-HJ-NPR-Za-hj-npr-z\d]{2}\d{6}$",
        ErrorMessage = "Invalid VIN number format.")]
        [DisplayName("Vehicle Identification Number")]
        public string VIN { get; set; }
        [DisplayName("Make")]
        public int MakeId { get; set; }
        [DisplayName("Model")]
        public int ModelId { get; set; }
        [DisplayName("Year")]
        public int Year { get; set; }
        [DisplayName("Color")]
        public int ColorId { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [DisplayName("Vehicle Pickup Date & Time")]
        public DateTime PickedOn { get; set; } = DateTime.Now;
        public int BusinessId { get; set; }
    }
    public class VehicleTypeDto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class VehicleListDto
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [DisplayName("Picked Date")]
        public DateTime PickedOn { get; set; }
        [DisplayName("Last Updated")]
        public DateTime ModifiedOn { get; set; }
        public int Year { get; set; }
        public int Status { get; set; }
        [DisplayName("Status")]
        public string BoundStatus { get; set; }

    }

}
