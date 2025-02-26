using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLIMFinders.Application.DTOs
{
    public class PaymentRequestDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
    }
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int TierId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
    public class PaymentResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }         
    }
    public class SubscriptionPlansDto
    {
        public int Id { get; set; }
        public string Tier { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; } 
        public List<PlanServicesDto> PlanServicesDto { get; set; }
    }
    public class PlanServicesDto
    { 
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string Name { get; set; } 
    }
}
