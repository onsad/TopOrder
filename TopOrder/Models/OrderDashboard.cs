using System.ComponentModel.DataAnnotations;

namespace TopOrder.Models
{
    public class OrderDashboard
    {
        [Display(Name = "Total amount")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Average amount")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal AverageAmount { get; set; }

        [Display(Name = "Best customer")]
        public string BestCustomer { get; set; } = string.Empty;
    }
}
