using TopOrder.Entitites;
using TopOrder.Models;

namespace TopOrder.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetOrders();

        public IEnumerable<Order> GetOrdersByFilters(FilterInputData filterInputData);

        public void CreateNewOrder(CreateOrderViewModel createOrderViewModel);

        public OrderDashboard GetDashboard();
    }
}
