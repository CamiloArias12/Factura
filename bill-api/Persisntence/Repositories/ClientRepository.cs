using bill_api.Domain.Entities;
using MongoDB.Driver;
namespace bill_api.Persisntace.Repositories
{
    public class ClientRepository(IMongoDatabase database) : Repository<Client>(database, "Clients"), IClientRepository
    {

    }
}
