using TopOrder.DAL;
using TopOrder.Entitites;

namespace TopOrder.Repositories
{
    public class StatusRepository(TopOrderContext topOrderContext, ILogger<OrderRepository> logger) : IStatusRepository
    {
        public Status? GetByStatusCode(StatusCode statusCode)
        {
            return topOrderContext.Statuses.SingleOrDefault(s => s.Code == statusCode);
        }
    }
}
