using bill_api.Application.Services;
using bill_api.Domain.Entities;
using bill_api.Persisntace.Repositories;

namespace client_api.Application.Services
{
    public class ClientService(IClientRepository clientRepository) : Service<Client>(clientRepository), IClientService
    {
    }
}
