using Microsoft.EntityFrameworkCore;
using TopOrder.DAL;
using TopOrder.Entitites;
using TopOrder.Models;
using TopOrder.Services;

namespace TopOrder.Repositories
{
    public class OrderRepository(TopOrderContext topOrderContext, ILogger<OrderRepository> logger) : IOrderRepository
    {
        public IEnumerable<Order> GetAll()
        {
            return topOrderContext.Orders.Include(o => o.Status).ToList();
        }

        public IEnumerable<Order> GetByFitlerParametes(FilterParamaters filterParamaters)
        {
            IQueryable<Order> query = topOrderContext.Set<Order>();

            if (!string.IsNullOrEmpty(filterParamaters.CustomerName))
            {
                query = topOrderContext.Orders.Where(o => o.CustomerName.Contains(filterParamaters.CustomerName, StringComparison.InvariantCultureIgnoreCase));
            }

            if (filterParamaters.StatusCode != null)
            {
                query = query.Where(o => o.Status.Code == filterParamaters.StatusCode);
            }

            return query.Include(q => q.Status).ToList();
        }

        public Order? GetById(int id)
        {
            return topOrderContext.Orders.Find(id);
        }

        public OrderDashboard GetDashboard()
        {
            var dash = new OrderDashboard();

            if (topOrderContext.Orders.Any())
            {
                dash.TotalAmount = topOrderContext.Orders.Sum(o => o.Amount);
                dash.AverageAmount = topOrderContext.Orders.Sum(o => o.Amount) / topOrderContext.Orders.Count();
                dash.BestCustomer = topOrderContext.Orders
                    .GroupBy(o => o.CustomerName)
                    .Select(group => new
                    {
                        CustomerName = group.Key,
                        TotalAmount = group.Sum(o => o.Amount)
                    })
                    .OrderByDescending(g => g.TotalAmount)
                    .First().CustomerName;
            }

            return dash;
        }

        public Order SaveOrder(Order order)
        {
            try
            {
                topOrderContext.Add(order);
                topOrderContext.SaveChanges();

                return order;
            }
            catch (DbUpdateException exception)
            {
                logger.LogError(exception.Message);

                throw;
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);

                throw;
            }
        }
    }
}
