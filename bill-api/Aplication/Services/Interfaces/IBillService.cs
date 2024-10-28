using bill_api.Domain.Entities;

namespace bill_api.Application.Services
{
    public interface IBillService : IService<Bill>
    {
        Task<List<Bill>> GetByClientId(string clientId);
        Task<Boolean> UpdateStatus(string clientId);

    }
}
