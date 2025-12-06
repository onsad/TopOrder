using System.ComponentModel.DataAnnotations;

namespace TopOrder.Models
{
    public class CreateOrderViewModel
    {
        [Required]
        [Display(Name = "Customer name")]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Order amount")]
        public decimal Amount { get; set; }
    }
}
