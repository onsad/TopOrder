using TopOrder.Entitites;

namespace TopOrder.Models
{
    public class OrderViewModel
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        public OrderDashboard Dashboard { get; set; } = new OrderDashboard();

        public string SelectedOrderStatus { get; set; }
    }
}
