using TopOrder.Entitites;
using TopOrder.Models;
using TopOrder.Repositories;

namespace TopOrder.Services
{
    public class OrderService(IOrderRepository orderRepository, IStatusRepository statusRepository) : IOrderService
    {
        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetAll();
        }

        public void CreateNewOrder(CreateOrderViewModel createOrderViewModel)
        {
            var code = statusRepository.GetByStatusCode(StatusCode.Processing);

            if (code != null)
            {
                var order = new Order
                {
                    CustomerName = createOrderViewModel.CustomerName,
                    Date = DateTime.Now,
                    StatusId = code.Id,
                    Amount = createOrderViewModel.Amount
                };

                orderRepository.SaveOrder(order);
            }
        }

        public IEnumerable<Order> GetOrdersByFilters(FilterInputData filterInputData)
        {
            var filterParamaters = new FilterParamaters();
            filterParamaters.CustomerName = filterInputData.CustomerName;

            if (!string.IsNullOrEmpty(filterInputData.StatusCode))
            {
                var code = int.Parse(filterInputData.StatusCode);
                filterParamaters.StatusCode = (StatusCode)code;
            }

            return orderRepository.GetByFitlerParametes(filterParamaters);
        }

        public OrderDashboard GetDashboard()
        {
            return orderRepository.GetDashboard();
        }
    }
}
