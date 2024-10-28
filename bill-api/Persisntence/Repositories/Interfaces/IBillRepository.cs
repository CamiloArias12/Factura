using bill_api.Domain.Entities;

namespace bill_api.Persisntace.Repositories
{
    public interface IBillRepository : IRepository<Bill>
    {
        Task<List<Bill>> FindByIdClient(string clientId);
    }
}
