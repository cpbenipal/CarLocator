using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLIMFinders.Application.DTOs
{
    public class SubscriptionRequest
    {
        public string Plan { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;  
    }
    public class StripeSettings
    {
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }
        public string StandardPriceId { get; set; }
        public string PremiumPriceId { get; set; }
    }

    public class AddressDto : PersonInfoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("Contact Person")]
        public string? ContactPerson { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        public string? Description { get; set; }
        [Required]
        [DisplayName("Registered As:")]
        public int RoleId { get; set; }
    }

    public class BusinessCreditDto : AddressDto
    {
        public int Id { get; set; }
        [DisplayName("New Password")]
        [DataType(DataType.Password)]
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{10,}", ErrorMessage = "Password must be atleast 10 characters with one at least one lower case, one upper case, one number and one special character ")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password does not match")]
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{10,}", ErrorMessage = "Password must be atleast 10 characters with one at least one lower case, one upper case, one number and one special character ")]
        [DisplayName("Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
    public class PersonInfoDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
    public class ChangePasswordDto
    {
         
        [DisplayName("Old Password")]
        [DataType(DataType.Password)]
        [Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{10,}", ErrorMessage = "Password must be atleast 10 characters with one at least one lower case, one upper case, one number and one special character ")]
        public string OldPassword { get; set; }

        [DisplayName("New Password")]
        [DataType(DataType.Password)]
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{10,}", ErrorMessage = "Password must be atleast 10 characters with one at least one lower case, one upper case, one number and one special character ")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password does not match")]
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{10,}", ErrorMessage = "Password must be atleast 10 characters with one at least one lower case, one upper case, one number and one special character ")]
        [DisplayName("Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
    public class ForgotPasswordDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [DisplayName("New Password")]
        [DataType(DataType.Password)]
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{10,}", ErrorMessage = "Password must be atleast 10 characters with one at least one lower case, one upper case, one number and one special character ")]
        public string NewPassword { get; set; }
         
    }
}