using BillApi.Domain.Entities;

namespace BillApi.Persistence.Repositories
{
    public interface IBillRepository : IRepository<Bill>
    {
        Task<List<Bill>> FindByIdClient(string clientId);
    }
}
