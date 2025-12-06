using TopOrder.Entitites;
using TopOrder.Models;
using TopOrder.Services;

namespace TopOrder.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetAll();

        /// <summary>
        /// Get order by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order? GetById(int id);

        public IEnumerable<Order> GetByFitlerParametes(FilterParamaters filterParamaters);

        public Order SaveOrder(Order order);

        public OrderDashboard GetDashboard();
    }
}
