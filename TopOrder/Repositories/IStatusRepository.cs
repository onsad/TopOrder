using TopOrder.Entitites;

namespace TopOrder.Repositories
{
    public interface IStatusRepository
    {
        Status? GetByStatusCode(StatusCode statusCode);
    }
}
