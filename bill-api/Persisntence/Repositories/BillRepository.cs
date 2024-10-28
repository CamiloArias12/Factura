using bill_api.Domain.Entities;
using MongoDB.Driver;
namespace bill_api.Persisntace.Repositories
{
    public class BillRepository(IMongoDatabase database) : Repository<Bill>(database, "Bills"), IBillRepository
    {
        public async Task<List<Bill>> FindByIdClient(string clientId)
        {
            return await _collection.Find(b => b.ClientId == clientId).ToListAsync();
        }

    }
}
