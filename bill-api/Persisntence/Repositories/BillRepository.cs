using bill_api.Domain.Entities;
using MongoDB.Driver;
namespace bill_api.Persisntace.Repositories
{
    public class BillRepository(IMongoDatabase database) : Repository<Bill>(database, "Bills"), IBillRepository
    {

    }
}
